using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;
	public Text countText;
	public Text winText;
	private int count;

	void Start() {
		count = 0;
		UpdateTexts ();
		winText.text = "";
	}

	void FixedUpdate() {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rigidbody.AddForce (movement * speed * Time.deltaTime);

		if (Input.touchCount > 0 && 
		    Input.GetTouch(0).phase == TouchPhase.Moved) {
			
			// Get movement of the finger since last frame
			Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
			
			// Move object across XY plane
			rigidbody.AddForce (new Vector3(touchDeltaPosition.x, 0.0f, touchDeltaPosition.y)
			                    * speed * Time.deltaTime);
		}
	}
	
	void OnTriggerEnter(Collider other) {
		//Destroy(other.gameObject);
		// gameObject.tag = "Player";
		// gameObject.SetActive(false);
		if (other.gameObject.tag == "PickUp") {
			other.gameObject.SetActive(false);
			count++;
			UpdateTexts();
		}
	}

	protected void UpdateTexts() {
		countText.text = "Count: " + count;
		if (count >= 13) {
				winText.text = "YOU WIN!";
		}
	}

}
