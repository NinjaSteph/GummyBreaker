using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
	// configuration paramerters
	[SerializeField] Paddle paddle1;
	[SerializeField] Vector2 ballVelocity = new Vector2(0f, 10f);
	[SerializeField] AudioClip[] ballSounds;

	// state
	Vector2 paddleToBallVector;
	bool gameHasStarted = false;

	// Cached component references
	AudioSource myAudioSource;

    // Start is called before the first frame update
    void Start() {
		paddleToBallVector = transform.position - paddle1.transform.position;
		myAudioSource = GetComponent<AudioSource>();
	}

    // Update is called once per frame
    void Update() {
		if (!gameHasStarted) {
			LockBallToPaddle();
			LaunchBallOnMouseClick();
		}
	}

	private void LaunchBallOnMouseClick() {
		if (Input.GetMouseButtonDown(0)) {
			GetComponent<Rigidbody2D>().velocity = ballVelocity;
			gameHasStarted = true;
		}
	}

	private void LockBallToPaddle() {
		Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
		transform.position = paddlePos + paddleToBallVector;
	}

	private void OnCollisionEnter2D(Collision2D collision) {
		if (gameHasStarted) {
			AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
			myAudioSource.PlayOneShot(clip);
		}
	}
}
