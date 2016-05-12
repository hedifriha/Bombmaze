using UnityEngine;
using System.Collections;

public class Doorway : MonoBehaviour {
	public GameController controller;
    void Start()
    {
        controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }
	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") {
			this.GetComponent<AudioSource> ().Play ();
			controller.nextLevel ();
		}
	}
}
