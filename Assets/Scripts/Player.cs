using UnityEngine;
using System.Collections;

public class Player:MonoBehaviour {
	private float movementSpeed;
	
	void Start() {
		this.movementSpeed = 35000;
	}
	
	void FixedUpdate() {
		input();
	}
	
	/** Handle input */
	private void input() {
		rigidbody.velocity = Vector3.zero;
		
		// Set new X and Y
		float horMovement = Input.GetAxis("Horizontal") * movementSpeed;
		float verMovement = Input.GetAxis("Vertical") * movementSpeed;
	
		rigidbody.AddForce(new Vector3(horMovement, verMovement, 0) * Time.deltaTime);
		
		// Set rotation towards mouse
		Vector3 mousePos = Input.mousePosition;
		mousePos.z = 30.0f;
		
		Vector3 lookPos = Camera.main.ScreenToWorldPoint(mousePos);
		lookPos -= transform.position;
		
		float angle = Mathf.Atan2(lookPos.y, lookPos.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		
		// Handle off screen
		Vector3 position = transform.position;
		if(position.x < -41) { position.x = 40; } else if(position.x > 41) { position.x = -40; }
		if(position.y > 19) { position.y = -18; } else if(position.y < -19) { position.y = 18; }
			
		transform.position = position;
		
		// Shoot
		if(Input.GetMouseButtonDown(0)) {
			GameObject bullet = Instantiate(Resources.Load("Bullet"), transform.position, Quaternion.identity) as GameObject;
			bullet.name = "Bullet";
		}
	}
}
