using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
	public Text counterText;
	public float seconds,minutes; 

	// Use this for initialization
	void Start () {
		counterText = GetComponent<Text>() as Text;
	}
	
	// Update is called once per frame
	void Update () {
		minutes =(int)(Time.time/60f);
		seconds =(int)(Time.time % 60f);
		counterText.text =("Time:")+ minutes.ToString("")+":"+seconds.ToString("00");

	}
}
