using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

	public void LoadNextScene() {
		int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
		if (currentSceneIndex < 5) {
			SceneManager.LoadScene(currentSceneIndex + 1);
		}
		else {
			SceneManager.LoadScene("VictoryScreen");
		}
	}

	public void LoadStartScreen() {
		SceneManager.LoadScene(0);
		GameSession gameStatus = FindObjectOfType<GameSession>();
		gameStatus.ResetGame();
	}

	public void QuitGame() {
		Application.Quit();
	}
}
