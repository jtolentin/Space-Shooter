using UnityEngine;
using System.Collections;
/*
 * 	Source File Name: EnemyLaser.cs
 *  Name: Jhun Kyle Tolentino
 *  Student Number: 100955026
 * 	Program Description : This controls the behaviour of the Laser .
 * 	Date: October 24, 2016
 * 	Last Modified by: Jhun Kyle Tolentino
 * 	Date Last Modified: October 25, 2016
 * 	Revision History: Added OnTriggerEnter2D - October 24, 2016
 * 				Edit the MinY,MaxY,MaxX,MinX values - October 25, 2016 
 * 
 */
public class EnemyLaser : MonoBehaviour {

	[SerializeField]
	private float speed = 0;
	private float MaxX = 6f;
	private float MinX = -6f;
	private float MaxY = 4f;
	private float MinY = -4f;
	private Vector2 _direction;
	bool isReady;//to know when the bullet direction is set
	private Vector2 _currentPosition;

	//ser default values in awake function
	void Awake()
	{
		isReady = false;
	}

	// Use this for initialization
	void Start () {

	}

	public void SetDirection(Vector2 direction)
	{
		//set the direction normalized, to get an unit vector
		_direction = direction.normalized;
		isReady = true;
	}

	// Update is called once per frame
	void FixedUpdate () {

		if (isReady) {

			//get the laser's current position
			_currentPosition = transform.position;
			//compute the laser's new position
			_currentPosition += _direction * speed;
			//update the laser's position
			transform.position = _currentPosition;
			//if the laser goes outside the screen, then destroy it
			if ((_currentPosition.x < MinX) || (_currentPosition.x > MaxX) ||
				(_currentPosition.y < MinY) || (_currentPosition.y > MaxY)) 
			{
				Destroy (gameObject);
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other){

		if (other.gameObject.tag == "PlayerShip") {
			Player.Instance.Health -= 10;
			Destroy (gameObject);
		}
		else if(other.gameObject.tag == "Shield"){
			Destroy (gameObject);
		}

	}
}
