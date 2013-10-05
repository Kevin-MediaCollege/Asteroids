using UnityEngine;
using System.Collections;

public class Bullet:MonoBehaviour {
	private float movementSpeed;
	
	void Start() {
		GameObject player = GameObject.Find("Player");
		
		transform.position = player.transform.position;
		transform.rotation = player.transform.rotation;
	}
	
	void Update() {
		if(transform.position.x < -40 || transform.position.x > 40 || transform.position.y < -20 || transform.position.y > 20) {
			Destroy(gameObject);
		}
		
		transform.position += (transform.up * 20) * Time.deltaTime;
	}
}