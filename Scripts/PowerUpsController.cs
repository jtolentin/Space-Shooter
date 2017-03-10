using UnityEngine;
using System.Collections;
/*
 * 	Source File Name: PowerUpsController.cs
 *  Name: Jhun Kyle Tolentino
 *  Student Number: 100955026
 * 	Program Description : This code controls the movement of the powerups and set the shield on everytime it collides with the player
 * 	Date: October 25, 2016
 * 	Last Modified by: Jhun Kyle Tolentino
 * 	Date Last Modified: October 25, 2016
 * 	Revision History: edit the destroy point and startPoint- October 25,2016
 * 
 */
public class PowerUpsController : MonoBehaviour {
	[SerializeField]
	GameObject Shield = null;

	[SerializeField]
	private float speed = 0;
	private float MinY = -3.4f;
	private float MaxY = 3.11f;
	private float startPoint = 50f;
	private float resetPoint = -6.5f;
	private Transform _transform;
	private Vector2 _currentPosition;

	// Use this for initialization
	void Start () {
		Shield.gameObject.SetActive (false);
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
		_currentPosition = new Vector2 (startPoint, currentY);
		_transform.position = _currentPosition;
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "PlayerShip") {
			Debug.Log ("Collision with " + gameObject.tag);
			Shield.gameObject.SetActive (true);
			Reset ();
		}
	}
}
