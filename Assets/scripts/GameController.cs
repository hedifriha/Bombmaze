using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.Advertisements;

public class GameController : MonoBehaviour {
	public static int rotateState = 0;
	public static int pickupCount = 0;

	private static float scoreff;


	static int levelIndex = 0;
	static bool isDead = false;
	static bool hasWon = false;
	static bool replayPressed = false;
	static bool homePressed = false;
	static int rotateOffset = 0;

	bool isFalling = false;
	bool isTransitioning = false;

	public GameObject player;
	public GameObject bomb;
	public GameObject camera;
	public GameObject gameOver;
	public GameObject win;
	public GameObject transition;
	public float gravityFactor;
	public GameObject[] levels;

	// Use this for initialization
	void Start () {
		Time.timeScale=1;
		for (int i = 0; i < levels.Length; i++) {
			levels [i].SetActive (false);
		}
		levels [levelIndex].SetActive (true);

		bomb.SetActive (false);
		win.SetActive (false);

        Advertisement.Initialize("1069118");
		loadLevel (0);


    }

	public static void Die() {
		isDead = true;
	}

	public void nextLevel() {
		if (levelIndex + 1 < levels.Length) {
			
			/*levels [levelIndex].SetActive (false);
			levels [levelIndex + 1].SetActive (true);
			levelIndex++;*/

			if (Advertisement.IsReady())
			{
				Advertisement.Show();
			}
			isTransitioning = true;
		} else if(scoreff<0) {
			scoreff = 0;
			Time.timeScale = 0;
			hasWon = false;
			isDead = true;
			gameOver.SetActive (true);
			player.SetActive (false);
			replayPressed = false;
		} 



		else {

            if (Advertisement.IsReady())
            {
                Advertisement.Show();
            }
            hasWon = true;
			win.SetActive (true);
			player.SetActive (false);
			replayPressed = false;
		}

	}
	public void MoveLeft()
	{
		rotateState++;
		rotateOffset = 90;
		isFalling = true;
	}
	public void re(){

		replayPressed = true;
	}
	public void home(){

		homePressed = true;
	}
	public void MoveRight()
	{
		rotateState--;
		rotateOffset = -90;
		isFalling = true;
	}
	void loadLevel(int index) {
		Level level = levels [index].GetComponent<Level> ();

		player.SetActive (true);
		Rigidbody playerRb = player.GetComponent<Rigidbody> ();
		playerRb.position = level.getPlayerSpawn ();
		playerRb.velocity = new Vector3 (0, 0, 0);

		if (level.hasBombSpawn ()) {
			bomb.SetActive (true);
			Rigidbody bombRb = bomb.GetComponent<Rigidbody> ();
			bombRb.position = level.getBombSpawn ();
			bombRb.velocity = new Vector3 (0, 0, 0);
		} else {
			bomb.SetActive (false);
		}

		rotateOffset = 0;
		rotateState = 0;
	}

	public void restart() {
		this.loadLevel (levelIndex);
		isDead = false;
		rotateOffset = 0;
		rotateState = 0;
		if (Advertisement.IsReady())
		{
			Advertisement.Show();
		}
	}

	void Update() {
		if (!isTransitioning) {
			if (isDead) {
				
				gameOver.SetActive (true);
				Time.timeScale = 0;
				if (homePressed) {
					hasWon = false;
					levelIndex = 0;
					SceneManager.LoadScene (0);
				}
				if (replayPressed) {
					Time.timeScale = 1;
					isDead = false;
					gameOver.SetActive (false);
					restart ();
					replayPressed = false;
				}
			} else if (hasWon) {
				Time.timeScale = 0;
				isDead = false;
				if (homePressed) {
					hasWon = false;
					levelIndex = 0;
					SceneManager.LoadScene (0);
				}
				if (replayPressed) {
					
					hasWon = false;
					levelIndex = 0;
					SceneManager.LoadScene (1);
					replayPressed = false;
				}
			} else if (rotateOffset == 0) {
				if (Input.GetKeyDown ("a")) {
					rotateState++;
					rotateOffset = 90;
					isFalling = true;
				} else if (Input.GetKeyDown ("d")) {
					rotateState--;
					rotateOffset = -90;
					isFalling = true;
				}
			}


		} else {

			isTransitioning = false;
			levels [levelIndex].SetActive (false);
			levels [levelIndex + 1].SetActive (true);
			levelIndex++;

			loadLevel (levelIndex);
		}


	}

	void moveObjects() {
		if (player != null) {
			Rigidbody playerRb = player.GetComponent<Rigidbody> ();

			if (rotateState == 0) {
				playerRb.AddForce (new Vector3 (0, 0, -gravityFactor));
			}
			if (rotateState == 1) {
				playerRb.AddForce (new Vector3 (-gravityFactor, 0, 0));
			}
			if (rotateState == 2) {
				playerRb.AddForce (new Vector3 (0, 0, gravityFactor));
			}
			if (rotateState == 3) {
				playerRb.AddForce (new Vector3 (gravityFactor, 0, 0));
			}
		}
		if (bomb != null) {
			Rigidbody bombRb = bomb.GetComponent<Rigidbody> ();

			if (rotateState == 0) {
				bombRb.AddForce(new Vector3(0, 0, -gravityFactor));
			}
			if (rotateState == 1) {
				bombRb.AddForce(new Vector3(-gravityFactor, 0, 0));
			}
			if (rotateState == 2) {
				bombRb.AddForce(new Vector3(0, 0, gravityFactor));
			}
			if (rotateState == 3) {
				bombRb.AddForce (new Vector3 (gravityFactor, 0, 0));
			}
		}
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (!isTransitioning) {
			if (!isDead && !hasWon) {
				if (rotateState == 4)
					rotateState = 0;
				if (rotateState == -1)
					rotateState = 3;

				camera.transform.rotation = Quaternion.Euler (new Vector3 (90, rotateState * 90 - rotateOffset, 0));
				if (rotateOffset > 0)
					rotateOffset -= 3;
				if (rotateOffset < 0)
					rotateOffset += 3;

				moveObjects ();
			}
		}
	}
}
