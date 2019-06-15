using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {
	// Configuration Parameters
	[SerializeField] float screenWidth = 16f;
	[SerializeField] float maxPaddleX = 15f;
	[SerializeField] float minPaddleX = 1f;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
		float mouseXPos = Input.mousePosition.x / Screen.width * screenWidth;
		Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
		paddlePos.x = Mathf.Clamp(mouseXPos, minPaddleX, maxPaddleX);
		transform.position = paddlePos;
    }
}
