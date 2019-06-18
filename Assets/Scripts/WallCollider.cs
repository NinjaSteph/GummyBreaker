using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollider : MonoBehaviour
{
	// configuration parameters
	[SerializeField] AudioClip wallSound;

	// cached references
	AudioSource myAudioSource;

	// Start is called before the first frame update
	void Start() {
		myAudioSource = GetComponent<AudioSource>();
	}

	private void OnCollisionEnter2D(Collision2D collision) {
		myAudioSource.PlayOneShot(wallSound);
	}
}
