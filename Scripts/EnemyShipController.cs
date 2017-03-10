using UnityEngine;
using System.Collections;
/*
 * 	Source File Name: EnemyShipController.cs
 *  Name: Jhun Kyle Tolentino
 *  Student Number: 100955026
 * 	Program Description : This controls the movement of the enemyship from left to right
 * 	Date: October 24, 2016
 * 	Last Modified by: Jhun Kyle Tolentino
 * 	Date Last Modified: 
 * 	Revision History: Edit the Collision Condition - October 24, 2016
 * 					Change the resetPoint - October 25, 2016
 * 
 */
public class EnemyShipController : MonoBehaviour {

	[SerializeField]
	GameObject Explosion = null;
	[SerializeField]
	private float speed = 0;
	private float resetPoint = -6.5f;
	// Use this for initialization
	void Start () {


	}

	// Update is called once per frame
	void FixedUpdate () {

		Vector2 _currentPosition = transform.position;

		_currentPosition -= new Vector2 (speed,0);

		transform.position = _currentPosition;

		if (transform.position.x < resetPoint) {

			Destroy (gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		//detect collision of enemy ship with the player ship or with a player's bullet
		if (other.gameObject.tag == "PlayerShip") {
			Player.Instance.Health -= 10;
			AudioSource asrc = gameObject.GetComponent<AudioSource> ();
			if (asrc != null) {
				asrc.Play ();
			}
			GameObject explosion = (GameObject)Instantiate (Explosion);
			explosion.transform.position = transform.position;

			Destroy (gameObject);
		}
		else if (other.gameObject.tag == "PlayerLaser")
		{
			AudioSource asrc = gameObject.GetComponent<AudioSource> ();
			if (asrc != null) {
				asrc.Play ();
			}
			GameObject explosion = (GameObject)Instantiate (Explosion);
			explosion.transform.position = transform.position;
			Destroy (gameObject);
		}
		else if (other.gameObject.tag == "Shield"){
			GameObject explosion = (GameObject)Instantiate (Explosion);
			explosion.transform.position = transform.position;
			Destroy (gameObject);
		}
	}
}
