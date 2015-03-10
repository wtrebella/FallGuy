using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	public static GameManager instance;

	public Text scoreText;

	public int score {get; private set;}

	void Awake() {
		Application.targetFrameRate = 60;
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
		if (Input.GetKeyDown(KeyCode.R)) RestartGame();
	}

	public void RestartGame() {
		Application.LoadLevel("GameScene");
	}
}
