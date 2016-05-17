using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class EventHandler : MonoBehaviour {
	


	public void startGame() {
		
		SceneManager.LoadScene (1);
	
	}

	public void restartGame() {
		
		GameController a=new GameController();

		SceneManager.LoadScene (1);

	}
}
