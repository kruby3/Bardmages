using UnityEngine;
using System.Collections;

public class Tune_Heal : Tune {

    public override void TuneComplete(bool crit)
    {
        base.TuneComplete(crit);

        GameObject temp = (GameObject)GameObject.Instantiate(spawnObject, ownerTransform.position, ownerTransform.rotation);
        temp.GetComponent<Heal>().agressor = ownerTransform.GetComponent<BaseControl>().player;
        temp.GetComponent<TrailRenderer>().material.color = Color.green;
        temp.transform.GetChild(1).GetComponent<ParticleSystem>().startColor = Color.green;
        temp.transform.GetChild(0).GetComponent<ParticleSystem>().startColor = Color.green;
        if (crit)
        {
            temp.GetComponent<TrailRenderer>().material.color = Color.yellow;
            temp.transform.GetChild(1).GetComponent<ParticleSystem>().startColor = Color.yellow;
            temp.transform.GetChild(0).GetComponent<ParticleSystem>().startColor = Color.yellow;
            temp.GetComponent<Heal>().damage *= 2f;
        }
        Destroy(temp.transform.GetChild(0).gameObject, 2f);
        Destroy(temp.transform.GetChild(1).gameObject, 2f);

        temp.transform.GetChild(0).parent = null;
        temp.transform.GetChild(0).parent = null;
    }

}
