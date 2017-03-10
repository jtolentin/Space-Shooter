using UnityEngine;
using System.Collections;
/*
 * 	Source File Name: PlayerShipCollider.cs
 *  Name: Jhun Kyle Tolentino
 *  Student Number: 100955026
 * 	Program Description : This checks if the player collides with the powerups.
 * 	Date: October 25, 2016
 * 	Last Modified by: Jhun Kyle Tolentino
 * 	Date Last Modified: October 25, 2016
 * 	Revision History: OnTrigger Condition - October 25,2016
 * 
 */
public class PlayerShipCollider : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "PowerUps") {
			Debug.Log ("PowerUps");
			PowerUpsController powerups = gameObject.GetComponent<PowerUpsController> ();
			powerups.Reset ();
		}
	}
}
