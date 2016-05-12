using UnityEngine;
using System.Collections;

public class Fade : MonoBehaviour {
	TextMesh tm;
	int stayTimer = 0;
	public int stayTime;

	// Use this for initialization
	void Start () {
		tm = this.GetComponent<TextMesh> ();
		Color color = tm.color;
		color.a = 0;
		tm.color = color;
	}
	
	// Update is called once per frame
	void Update () {
		Color color = tm.color;
		if (stayTimer != stayTime) {
			if (color.a < 1) {
				color.a += 0.01f;
			} else {
				if (stayTimer < stayTime) {
					stayTimer++;
				}
			}
		}

		if (stayTimer == stayTime) {
			if (color.a > 0) {
				color.a -= 0.01f;
			}
		}
		tm.color = color;
	}
}
