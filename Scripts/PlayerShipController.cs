using UnityEngine;
using System.Collections;
/*
 * 	Source File Name: PlayerShipController.cs
 *  Name: Jhun Kyle Tolentino
 *  Student Number: 100955026
 * 	Program Description : This controls the behaviour of the PlayerShip.
 * 	Date: October 23, 2016
 * 	Last Modified by: Jhun Kyle Tolentino
 * 	Date Last Modified: 
 * 	Revision History: put Boundary controls - October 23,2016
 * 					added Laser control and audiosource play - October 24 ,2016
 * 					change the reset point and boundaries - October 25,2016
 * 
 */
public class PlayerShipController : MonoBehaviour {
	[SerializeField]
	GameObject Laser = null;

	[SerializeField]
	GameObject LaserPosition01 = null;

	[SerializeField]
	GameObject LaserPosition02 = null;

	[SerializeField]
	private float speed = 0;

	private float MaxX = 5.40f;
	private float MinX = -5.40f;
	private float MaxY = 2.73f;
	private float MinY = -3.01f;

	private Transform _transform;
	private Vector2 _currentPosition;
	private float playerInputY;
	private float playerInputX;

	// Use this for initialization
	void Start () {

		_transform = gameObject.transform;
		_currentPosition = transform.position;
	}

	// Update is called once per frame
	void FixedUpdate () {
		//press "space" or "l" to shoot
		if (Input.GetKeyDown ("space") || Input.GetKeyDown ("l")) 
		{
			//instantiate the lasers
			GameObject laser01 = (GameObject)Instantiate (Laser);
			GameObject laser02 = (GameObject)Instantiate (Laser);
			//set laser position
			laser01.transform.position = LaserPosition01.transform.position;
			laser02.transform.position = LaserPosition02.transform.position;
			AudioSource asrc = gameObject.GetComponent<AudioSource> ();
			if (asrc != null) {
				asrc.Play ();
			}
		}

		playerInputX = Input.GetAxis ("Horizontal");
		playerInputY = Input.GetAxis ("Vertical");
		_currentPosition = _transform.position;

		if (playerInputX > 0) {

			_currentPosition += new Vector2 (speed, 0); 

		}
		if (playerInputX < 0) {

			_currentPosition -= new Vector2 (speed, 0); 

		}
		if (playerInputY > 0) {

			_currentPosition += new Vector2 (0, speed); 

		}
		if (playerInputY < 0) {

			_currentPosition -= new Vector2 (0, speed); 

		}
		checkBounds();
		_transform.position = _currentPosition;

	}
	//keeps the player inside the scene.
	private void checkBounds() {
		if (_currentPosition.x < MinX) {
			_currentPosition.x = MinX;
		}
		if (_currentPosition.x > MaxX) {
			_currentPosition.x = MaxX;
		}

		if (_currentPosition.y < MinY) {
			_currentPosition.y = MinY;
		}
		if (_currentPosition.y > MaxY) {
			_currentPosition.y = MaxY;
		}
	}		
}
