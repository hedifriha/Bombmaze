using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") {
			GameController.pickupCount++;
			Destroy (this.gameObject);
		}
	}
}
