using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {
	public GameObject light;

	public float rotX;
	public float rotY;
	public float rotZ;
	
	// Update is called once per frame
	void Update () {
		this.transform.Rotate(new Vector3(rotX, rotY, rotZ));
		light.transform.position = this.transform.position + new Vector3 (0, 1, 0);
	}
}
