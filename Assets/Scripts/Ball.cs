using UnityEngine;

public class Ball : MonoBehaviour {
	// configuration paramerters
	[SerializeField] Paddle paddle1;
	[SerializeField] Vector2 ballVelocity = new Vector2(0f, 10f);
	[SerializeField] AudioClip[] ballSounds;
	[SerializeField] float randomFactor = 0.2f;

	// state
	Vector2 paddleToBallVector;
	bool gameHasStarted = false;

	// Cached references
	AudioSource myAudioSource;
	Rigidbody2D myRigidbody2D;

    // Start is called before the first frame update
    void Start() {
		paddleToBallVector = transform.position - paddle1.transform.position;
		myAudioSource = GetComponent<AudioSource>();
		myRigidbody2D = GetComponent<Rigidbody2D>();
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
			myRigidbody2D.velocity = ballVelocity;
			gameHasStarted = true;
		}
	}

	private void LockBallToPaddle() {
		Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
		transform.position = paddlePos + paddleToBallVector;
	}

	private void OnCollisionEnter2D(Collision2D collision) {
		Vector2 velocityTweak = new Vector2(
			Random.Range(0.05f, randomFactor),
			Random.Range(0.05f, randomFactor));

		if (gameHasStarted) {
			// AudioClip clip = ballSounds[Random.Range(0, ballSounds.Length)];
			// myAudioSource.PlayOneShot(clip);
			if (Random.Range(0f, 1f) > 0.5f) {
				myRigidbody2D.velocity += velocityTweak;
			}
			else {
				myRigidbody2D.velocity -= velocityTweak;
			}
		}
	}

	public bool HasGameStarted() {
		return gameHasStarted;
	}
}
