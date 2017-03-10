using UnityEngine;
using System.Collections;
/*
 * 	Source File Name: StarCoinController.cs
 *  Name: Jhun Kyle Tolentino
 *  Student Number: 100955026
 * 	Program Description : This controls the movement of the StarCoins going left to right.
 * 	Date: October 23, 2016
 * 	Last Modified by: Jhun Kyle Tolentino
 * 	Date Last Modified: October 25, 2016
 * 	Revision History: Added the OnTriggerEnter2D - October 24, 2016 
 * 					the resetpoint and boundaries value - October 25, 2016 
 * 
 */
public class StarCoinController : MonoBehaviour {

	[SerializeField]
	private float speed = 0;
	private float MinY = -3.4f;
	private float MaxY = 3.11f;
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
		if (other.gameObject.tag == "PlayerShip") {
			Debug.Log ("Collision with " + gameObject.tag);
			Player.Instance.Points += 100;
			Reset ();
			AudioSource asrc = gameObject.GetComponent<AudioSource> ();
			if (asrc != null) {
				asrc.Play ();
			}
		}
	}
}
