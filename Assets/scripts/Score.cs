using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Score : MonoBehaviour {
	public Text counterText;
	public static float score; 
	public static float scoref; 
	public float startTime;
	// Use this for initialization
	void Start () {
		counterText = GetComponent<Text>() as Text;
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		score=(int)((startTime-Time.time) % 60f*95+500000);
		scoref = score;
		counterText.text = ("score :")+score.ToString ("");
	}

}




