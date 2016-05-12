using UnityEngine;
using System.Collections;

public class Pusher : MonoBehaviour {
	public int onState;
	private bool isOn = false;
	public GameObject particleEffect;
	public AudioSource audio;
	public GameObject pointer;
	public Vector3 forceDirection;

	int audioTimeout = 0;

	// Use this for initialization
	void Start () {
		if (onState == 0)
			pointer.transform.rotation = Quaternion.Euler (new Vector3 (90, 0, 0));
		if (onState == 1)
			pointer.transform.rotation = Quaternion.Euler (new Vector3 (90, 90, 0));
		if (onState == 2)
			pointer.transform.rotation = Quaternion.Euler (new Vector3 (90, 180, 0));
		if (onState == 3)
			pointer.transform.rotation = Quaternion.Euler (new Vector3 (90, -90, 0));
	}

	// Update is called once per frame
	void Update () {
		if (GameController.rotateState == onState) {
			isOn = true;
			particleEffect.SetActive (true);
		} else {
			isOn = false;
			particleEffect.SetActive (false);
		}

		if (audioTimeout > 0)
			audioTimeout--;
	}

	void OnTriggerEnter(Collider other) {
	}

	void OnTriggerStay(Collider other) {
		if (isOn) {
			other.attachedRigidbody.velocity = forceDirection * 10;
			if (audioTimeout == 0) {
				audio.Play ();
				audioTimeout = 50;
			}
		}
	}

	void OnTriggerExit(Collider other) {
		if (isOn)
			other.attachedRigidbody.velocity = new Vector3 (0, 0, 0);
	}
}
