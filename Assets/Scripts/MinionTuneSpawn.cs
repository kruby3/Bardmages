using UnityEngine;
using System.Collections;

public class MinionTuneSpawn : MonoBehaviour, Spawnable {

    public PlayerID owner;
    private bool crit;

    public void Crit (bool crit)
    {
        this.crit = crit;
    }
    public void Owner (PlayerID owner)
    {
        this.owner = owner;

        // Switch the minion's robe color to the color of its owner.
        Transform[] robes = new Transform[2];
        robes[0] = transform.FindChild("bardmage_export").FindChild("pCube2");
        robes[1] = transform.FindChild("bardmage_export").FindChild("pCube3");

        Material robeMaterial = LevelManager.instance.playerDict[owner].transform.FindChild("bardmage_export").FindChild("pCube2").GetComponent<Renderer>().material;
        foreach (Transform robe in robes) {
            robe.GetComponent<Renderer>().material = robeMaterial;
        }
    }

    // Use this for initialization
    void Start () {
        if (crit) {
            Destroy (this.gameObject, 20f);
        } else {
            Destroy (this.gameObject, 10f);
        }
    }

    // Update is called once per frame
    void Update () {

    }
}