using UnityEngine;
using System.Collections;
/*
 * 	Source File Name: AsteroidController.cs
 *  Name: Jhun Kyle Tolentino
 *  Student Number: 100955026
 * 	Program Description : This controls the behaviour of the Asteroid
 * 	Date: October 23, 2016
 * 	Last Modified by: Jhun Kyle Tolentino
 * 	Date Last Modified: 
 * 	Revision History: Edit the Collision Condition - October 24, 2016
 * 					change the reset point and boundaries - October 25, 2016
 * 
 */
public class AsteroidController : MonoBehaviour {

	[SerializeField]
	GameObject Explosion = null;

	[SerializeField]
	private float speed = 0;

	private float MinY = -3.2f;
	private float MaxY = 2.90f;
	private float MinX = 6.5f;
	private float MaxX = 10f;
	private float resetPoint = -6.5f;


	private Transform _transform;
	private Vector2 _currentPosition;

	// Use this for initialization
	void Start () {

		_transform = gameObject.transform;
		_currentPosition = transform.position;
		Reset ();

	}

	// Update is called once per frame
	void FixedUpdate () {
		_currentPosition = _transform.position;

		_currentPosition -= new Vector2 (speed, 0);
		_transform.position = _currentPosition;
		if (_currentPosition.x <= resetPoint) {
			Reset ();
		}
	}

	public void Reset(){
		float currentY = Random.Range (MinY, MaxY);
		float currentX = Random.Range (MinX,MaxX);
		_currentPosition = new Vector2 (currentX, currentY);
		_transform.position = _currentPosition;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "PlayerLaser") {
			Player.Instance.Points += 50;
			AudioSource asrc = gameObject.GetComponent<AudioSource> ();
			if (asrc != null) {
				asrc.Play ();
			}
			GameObject explosion = (GameObject)Instantiate (Explosion);
			explosion.transform.position = transform.position;
			Destroy (other.gameObject);
			Reset ();
		} 
		else if (other.gameObject.tag == "PlayerShip") {
			Player.Instance.Health -= 10;
			AudioSource asrc = gameObject.GetComponent<AudioSource> ();
			if (asrc != null) {
				asrc.Play ();
			}
			GameObject explosion = (GameObject)Instantiate (Explosion);
			explosion.transform.position = transform.position;
			Reset ();
		}
		else if (other.gameObject.tag == "Shield"){
			GameObject explosion = (GameObject)Instantiate (Explosion);
			explosion.transform.position = transform.position;
			Reset ();
		}
	}

}
