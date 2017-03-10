using UnityEngine;
using System.Collections;
/*
 * 	Source File Name: EnemyShooter.cs
 *  Name: Jhun Kyle Tolentino
 *  Student Number: 100955026
 * 	Program Description : This codes finds the PlayerShip and fires the enemy laser after 1 sec and relaunch it every 2.5 seconds 
 * 	Date: October 24, 2016
 * 	Last Modified by: Jhun Kyle Tolentino
 * 	Date Last Modified: October 25, 2016
 * 	Revision History: Edit the minY,maxY,minSpawnPoint,maxSpawnPoint values - October 25, 2016 
 * 
 */
public class EnemyShooter : MonoBehaviour {
	[SerializeField]
	GameObject EnemyShooter1 = null;


	// Use this for initialization
	void Start () {
		//fire an enemy bullet after 1 second and it will launch every 2.5 seconds
		InvokeRepeating ("FireEnemyLaser", 1.0f, 2.5f);
	}

	// Update is called once per frame
	void Update () {

	}

	//Function to fire an enemy laser
	void FireEnemyLaser()
	{
		GameObject playerShip = GameObject.Find ("PlayerShip");

		if (playerShip != null) //if the player is not dead
		{
			//instantiate an enemy laser
			GameObject laser = (GameObject)Instantiate (EnemyShooter1);
			//set the laser's initial position
			laser.transform.position = transform.position;

			//compute the laser's direction towards the player's ship
			Vector2 direction = playerShip.transform.position - laser.transform.position;
			//set the laser's direction
			laser.GetComponent<EnemyLaser>().SetDirection(direction);

		}
	}
}
