using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
	// configuration paramerters
	[SerializeField] Paddle paddle1;
	[SerializeField] Vector2 ballVelocity = new Vector2(0f, 10f);

	bool gameHasStarted = false;

	// state
	Vector2 paddleToBallVector;

    // Start is called before the first frame update
    void Start() {
		paddleToBallVector = transform.position - paddle1.transform.position;
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
}
