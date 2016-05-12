using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Score : MonoBehaviour {
	public Text counterText;
	public static float score; 
	public float scoref; 
	// Use this for initialization
	void Start () {
		counterText = GetComponent<Text>() as Text;
	}
	
	// Update is called once per frame
	void Update () {
		score=(int)(Time.time % 60f*165);
	
		counterText.text = ("score :")+score.ToString ("");
	}

}




