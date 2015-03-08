using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	public static GameManager instance;

	public Text scoreText;

	public int score {get; private set;}

	void Awake() {
		score = 0;
		instance = this;
	}
	
	void Start () {
	
	}

	public void AddToScore(int points) {
		score += points;
		scoreText.text = score.ToString();
	}
	
	void Update () {
		if (Input.GetKeyDown(KeyCode.R)) Application.LoadLevel("GameScene");
	}
}
