using UnityEngine;
using System.Collections;
/*
 * 	Source File Name: ShieldController.cs
 *  Name: Jhun Kyle Tolentino
 *  Student Number: 100955026
 * 	Program Description : This code checks if the shield collides with the enemylaser, enemyship , or asteroid.
 * 	Date: October 25, 2016
 * 	Last Modified by: Jhun Kyle Tolentino
 * 	Date Last Modified: October 25, 2016
 * 	Revision History: add OnTriggerEnter2D- October 25,2016
 * 
 */
public class ShieldController : MonoBehaviour {
	private int shieldHealth = 50;
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "EnemyShip" || other.gameObject.tag == "EnemyLaser" || other.gameObject.tag == "Asteroid") {
			Debug.Log ("Shield Hit");
			shieldHealth -= 10;
			if (shieldHealth == 0) {
				gameObject.SetActive (false);
				shieldHealth = 50;
			}
		}
	}
}
