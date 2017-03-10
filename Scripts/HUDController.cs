using UnityEngine;
using System.Collections;
using UnityEngine.UI;
/*
 * 	Source File Name: HUDController.cs
 *  Name: Jhun Kyle Tolentino
 *  Student Number: 100955026
 * 	Program Description : This controls the HUD and how the games restarts and goes to Gameover.
 * 	Date: October 23, 2016
 * 	Last Modified by: Jhun Kyle Tolentino
 * 	Date Last Modified: October 25, 2016
 * 	Revision History: added Your Score Text - October 25, 2016 
 * 
 */

public class HUDController : MonoBehaviour {

	[SerializeField]
	Text points = null;
	[SerializeField]
	Text health = null;
	[SerializeField]
	GameObject player = null;
	[SerializeField]
	GameObject gameover = null;
	[SerializeField]
	Text highscore = null;
	[SerializeField]
	Button restartButton = null;
	[SerializeField]
	Text score = null;
	[SerializeField]
	GameObject enemyShip = null;
	// Use this for initialization
	void Start () 
	{
		points.text = "Points: 0";
		health.text = "Health: 100";
		Player.Instance.hud = this;
		RestartGame ();
	}

	// Update is called once per frame
	void Update () {

	}

	public void UpdatePoints()
	{

		points.text = "Points: " + Player.Instance.Points;
	}

	public void UpdateHealth()
	{
		health.text = "Health: " + Player.Instance.Health;

	}

	public void GameOver()
	{
		points.gameObject.SetActive (false);
		health.gameObject.SetActive (false);
		player.SetActive (false);
		enemyShip.gameObject.SetActive (false);
		highscore.text = "HighScore: " + Player.Instance.HighScore;
		highscore.gameObject.SetActive (true);
		score.text = "Your Score: " + Player.Instance.Points;
		score.gameObject.SetActive (true);
		gameover.gameObject.SetActive (true);
		restartButton.gameObject.SetActive (true);
	}

	public void RestartGame()
	{
		enemyShip.gameObject.SetActive (true);
		points.gameObject.SetActive (true);
		health.gameObject.SetActive (true);
		player.SetActive (true);
		score.gameObject.SetActive (false);
		highscore.gameObject.SetActive (false);
		gameover.gameObject.SetActive (false);
		restartButton.gameObject.SetActive (false);
		Player.Instance.Points = 0;
		Player.Instance.Health = 100;

	}
}
