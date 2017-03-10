using UnityEngine;
using System.Collections;
/*
 * 	Source File Name: StarBackgroundController.cs
 *  Name: Jhun Kyle Tolentino
 *  Student Number: 100955026
 * 	Program Description : This controls the movement of the background from right to left
 * 	Date: October 23, 2016
 * 	Last Modified by: Jhun Kyle Tolentino
 * 	Date Last Modified: 
 * 	Revision History: edit the background reset point to make it look smooth - October 25, 2016
 * 
 */
public class StarBackgroundController : MonoBehaviour {

	[SerializeField]
	private float speed = 0.07f;
	[SerializeField]
	private float resetPoint = -38.76f;
	[SerializeField]
	private float startPoint = -5.21f;
	private Transform _transform;
	private Vector2 _currentPosition;

	// Use this for initialization
	void Start () {

		_transform = gameObject.transform;
		_currentPosition = transform.position;
		Reset ();

	}

	// Update is called once per frame
	void Update () {

		_currentPosition = _transform.position;

		_currentPosition -= new Vector2 (speed, 0);
		_transform.position = _currentPosition;
		if (_currentPosition.x <= resetPoint) {
			Reset ();
		}
	}

	private void Reset(){
		_currentPosition = new Vector2 (startPoint, 0);
		_transform.position = _currentPosition;
	}
}
