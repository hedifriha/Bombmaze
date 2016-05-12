using UnityEngine;
using System.Collections;

public class Level : MonoBehaviour {
	public GameObject playerSpawn;
	public GameObject bombSpawn;

	public Vector3 getPlayerSpawn() {
		return playerSpawn.transform.position;
	}

	public bool hasBombSpawn() {
		return bombSpawn != null;
	}

	public Vector3 getBombSpawn() {
		return bombSpawn.transform.position;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
