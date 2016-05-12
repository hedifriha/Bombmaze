using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour {
	public bool destroySelf;
	public GameObject explosion;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") {
			Instantiate (explosion, this.transform.position, Quaternion.identity);
			if (destroySelf) {
				this.gameObject.SetActive (false);
			}
			other.gameObject.SetActive (false);
			GameController.Die ();
		}
	}
}
