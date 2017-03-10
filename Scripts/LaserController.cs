using UnityEngine;
using System.Collections;
/*
 * 	Source File Name: LaserController.cs
 *  Name: Jhun Kyle Tolentino
 *  Student Number: 100955026
 * 	Program Description : This code controls the movement of the laser going from its initial position to the right.
 * 	Date: October 24, 2016
 * 	Last Modified by: Jhun Kyle Tolentino
 * 	Date Last Modified: 
 * 	Revision History: edit the destroy point - October 25,2016
 * 
 */
public class LaserController : MonoBehaviour {

	[SerializeField]
	private float speed = 0;
	private float destroyPoint = 6f;
	private Vector2 _currentPosition;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		_currentPosition = transform.position;
		//computes the laser's new position
		_currentPosition += new Vector2(speed,0);
		transform.position = _currentPosition;
		if (_currentPosition.x > destroyPoint) 
		{
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "EnemyShip")
		{
			Player.Instance.Points += 50;
			Destroy (gameObject);
		}
	}

}
