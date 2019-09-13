using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

	// configuration parameters
	[SerializeField] AudioClip breakSound;
	[SerializeField] GameObject blockSparklesVFX;
	[SerializeField] Sprite[] hitSprites;

	// cached referneces
	Level level;
	GameSession gameSession;

	// state variables
	[SerializeField] int timesHit; // only serialized for debug purposes

	void Start() {
		CountBreakableBlocks();
		gameSession = FindObjectOfType<GameSession>();
	}

	private void CountBreakableBlocks() {
		level = FindObjectOfType<Level>();
		if (tag == "Breakable") {
			level.CountBlocks();
		}
	}

	private void OnCollisionEnter2D(Collision2D collision) {
		AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
		if (tag == "Breakable") {
			ProcessCollision();
		}
	}

	private void ProcessCollision() {
		timesHit++;
		int maxHits = hitSprites.Length + 1;
		if (timesHit >= maxHits) {
			DestroyBlock();
		}
		else {
			ShowNextHitSprite();
		}
	}

	private void ShowNextHitSprite() {
		int spriteIndex = timesHit - 1;
		if (hitSprites[spriteIndex] != null) {
			GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		}
		else {
			Debug.LogError("Block sprite is missing from array: " + gameObject.name);
		}
	}

	private void DestroyBlock() {
		PlayBlockDestroyFX();
		gameSession.AddToScore();
		level.BlockDestroyed();
		Destroy(gameObject);
	}

	private void PlayBlockDestroyFX() {
		TriggerSparklesVFX();
	}

	private void TriggerSparklesVFX() {
		GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
		Destroy(sparkles, 2f);
	}
}
