using UnityEngine;
using System.Collections;

public class LandSlideSpawn : MonoBehaviour, Spawnable {

	private PlayerID owner;
	private bool crit;


	public void Crit (bool crit) {
		this.crit = crit;
		if (crit) {
			transform.localScale = new Vector3 (1.4f, 1f, 1f);
		}
	}
	public void Owner (PlayerID owner) {
		this.owner = owner;
	}

	// Use this for initialization
	void Start () {
		Destroy (transform.root.gameObject, .8f);
	}

	void OnTriggerEnter(Collider other) {
		if (other.GetComponent<PlayerControl> () != null) {
			if (other.GetComponent<PlayerControl> ().player != this.owner) {
				if (crit) {
					other.GetComponent<PlayerLife> ().DealDamage (.4f);
				} else {
					other.GetComponent<PlayerLife> ().DealDamage (.2f);
				}
			}
		}

	}
	void Update() {
		transform.Translate (0, 0, 50f * Time.deltaTime, Space.Self);
	}
}