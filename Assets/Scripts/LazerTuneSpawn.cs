using UnityEngine;
using System.Collections;

public class LazerTuneSpawn : MonoBehaviour, Spawnable {

	private PlayerID owner;
	private bool crit;

	public void Crit (bool crit)
	{
		this.crit = crit;	
	}

	public void Owner (PlayerID owner)
	{
		this.owner = owner;
	}

	// Use this for initialization
	void Start () {
		if (crit) {
			Destroy (transform.root.gameObject, 1f);
		} else {
			Destroy (transform.root.gameObject, 0.1f);
		}
	}

	void Update() {
		if (crit) {
			transform.Rotate (new Vector3 (0f, 5f * Time.deltaTime, 0f));
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.GetComponent<PlayerControl>() != null) {
			if (other.GetComponent<PlayerControl>().player != this.owner) {
				if (crit) {
					other.GetComponent<PlayerLife>().DealDamage(1f);
				} else {
					other.GetComponent<PlayerLife>().DealDamage(0.1f);
				}
			}
		}
	}
}
