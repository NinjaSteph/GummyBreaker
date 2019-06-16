using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

	[SerializeField] AudioClip breakSound;

	// cached refernece
	Level level;
	GameStatus gameStatus;

	void Start() {
		level = FindObjectOfType<Level>();
		level.CountBreakableBlocks();
		gameStatus = FindObjectOfType<GameStatus>();
	}

	private void OnCollisionEnter2D(Collision2D collision) {
		DestroyBlock();
	}

	private void DestroyBlock() {
		AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
		level.BlockDestroyed();
		gameStatus.AddToScore();
		Destroy(gameObject);
	}
}
