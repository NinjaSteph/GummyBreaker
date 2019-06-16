using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour{

	// configuration parameters
	[Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f;
	[SerializeField] int pointsPerBlock = 15;
	[SerializeField] TextMeshProUGUI scoreText;

	// state variables
	[SerializeField] int currentScore = 0;

	private void Awake() {
		int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
		if (gameStatusCount > 1) {
			gameObject.SetActive(false);
			DestroyGameStatus();
		}
		else {
			DontDestroyOnLoad(gameObject);
		}
	}

	// Start is called before the first frame update
	void Start() {
		Time.timeScale = gameSpeed;
		scoreText.text = currentScore.ToString();
	}

    // Update is called once per frame
    void Update() {
		
    }

	public void AddToScore() {
		currentScore += pointsPerBlock;
		scoreText.text = currentScore.ToString();
	}

	public void DestroyGameStatus() {
		Destroy(gameObject);
	}
}
