using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {
	// Configuration Parameters
	[SerializeField] float screenWidth = 16f;
	[SerializeField] float maxPaddleX = 15f;
	[SerializeField] float minPaddleX = 1f;
	// configuration parameters
	[SerializeField] AudioClip paddleSound;

	// cached references
	AudioSource myAudioSource;
	GameSession gameSession;
	Ball ball;

    // Start is called before the first frame update
    void Start() {
		gameSession = FindObjectOfType<GameSession>();
		ball = FindObjectOfType<Ball>();
		myAudioSource = GetComponent<AudioSource>();
	}

    // Update is called once per frame
    void Update() {
		Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
		paddlePos.x = Mathf.Clamp(GetXPos(), minPaddleX, maxPaddleX);
		transform.position = paddlePos;
    }

	private float GetXPos() {
		if (gameSession.IsAutoPlayEnabled()) {
			return ball.transform.position.x;
		}
		else {
			return Input.mousePosition.x / Screen.width * screenWidth;
		}
	}

	private void OnCollisionEnter2D(Collision2D collision) {
		if (ball.HasGameStarted()) {
			myAudioSource.PlayOneShot(paddleSound);
		}
	}
}
