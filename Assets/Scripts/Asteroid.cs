using UnityEngine;
using System.Collections;

public class Asteroid:MonoBehaviour {
	float movementSpeed;
	
	void Start() {
		movementSpeed = Random.value * 1500;
		
		Quaternion rotation = transform.rotation;
		
		rotation.x = Random.value * 360;
		
		transform.rotation = rotation;
	}
	
	void Update() {
		transform.position += (transform.up * movementSpeed) * Time.deltaTime;
	}
}
