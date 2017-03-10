using UnityEngine;
using System.Collections;
/*
 * 	Source File Name: EnemyShipSpawner.cs
 *  Name: Jhun Kyle Tolentino
 *  Student Number: 100955026
 * 	Program Description : This controls on how the enemy ship spawns in the scene.
 * 	Date: October 24, 2016
 * 	Last Modified by: Jhun Kyle Tolentino
 * 	Date Last Modified: October 25, 2016
 * 	Revision History: Edit the minY,maxY,minSpawnPoint,maxSpawnPoint values - October 25, 2016 
 * 
 */
public class EnemyShipSpawner : MonoBehaviour {

	[SerializeField]
	GameObject EnemyShip = null;

	private float MaxY = 2.90f;
	private float MinY = -3.1f;
	private float minSpawnPoint = 6.5f;
	private float maxSpawnPoint = 8f;
	float maxSpawnRateInSeconds = 5f;

	// Use this for initialization
	// Reference: https://docs.unity3d.com/ScriptReference/MonoBehaviour.InvokeRepeating.html
	void Start () {

		Invoke ("SpawnEnemy", maxSpawnRateInSeconds);

		//increase spawn rate every 15 seconds
		InvokeRepeating("IncreaseSpawnRate",0f,15f);
	}

	// Update is called once per frame
	void Update () {

	}

	//Function to spawn an enemy
	void SpawnEnemy()
	{ 
		GameObject anEnemy = (GameObject)Instantiate (EnemyShip);
		float currentY = Random.Range (MaxY, MinY);
		float currentX = Random.Range (minSpawnPoint,maxSpawnPoint);
		anEnemy.transform.position =  new Vector2 (currentX,currentY);

		//Schedule when to spawn next enemy
		ScheduleNextEnemySpawn();
	}

	//this schedule when the next enemy will spawn and at the bottom it increases the spawnrate of the enemyship
	//Reference : https://docs.unity3d.com/ScriptReference/MonoBehaviour.Invoke.html
	void ScheduleNextEnemySpawn()
	{
		float spawnInNSeconds;
		if (maxSpawnRateInSeconds > 1f) {

			spawnInNSeconds = Random.Range (1f, maxSpawnRateInSeconds);

		} else
			spawnInNSeconds = 1f;
		Invoke ("SpawnEnemy", spawnInNSeconds);
	}
	void IncreaseSpawnRate()
	{
		if (maxSpawnRateInSeconds > 1f)
			maxSpawnRateInSeconds--;
		if (maxSpawnRateInSeconds == 1f)
			CancelInvoke ("IncreaseSpawnRate");
	}
}
