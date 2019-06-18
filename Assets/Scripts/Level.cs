using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] int blockCount; // serialized for debugging purposes

	SceneLoader sceneLoader;

	void Start() {
		sceneLoader = FindObjectOfType<SceneLoader>();
	}

	public void CountBlocks() {
		// count all the blocks in the scene
		blockCount++;
	}

	public void BlockDestroyed() {
		blockCount = blockCount - 1;
		if (blockCount <= 0) {
			sceneLoader.LoadNextScene();
		}
	}

}
