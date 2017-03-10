using UnityEngine;
using System.Collections;
/*
 * 	Source File Name: Player.cs
 *  Name: Jhun Kyle Tolentino
 *  Student Number: 100955026
 * 	Program Description : This controls the Players Points, Health, and Highscore.
 * 	Date: October 23, 2016
 * 	Last Modified by: Jhun Kyle Tolentino
 * 	Date Last Modified: October 24, 2016
 * 	Revision History: Added the HighScore - October 24, 2016 
 * 
 */
public class Player  {

	private const string key ="HIGH_SCORE";

	private int _points = 0;
	private int _health = 100;
	private int _highScore = 0;

	public HUDController hud; 

	private static Player _instance = null;
	public static Player Instance
	{
		get
		{
			if (_instance == null) 
			{
				_instance = new Player ();
			}
			return _instance;
		}
	}

	private Player(){

		if (PlayerPrefs.HasKey (key))
		{
			_highScore = PlayerPrefs.GetInt (key);
		}
	}

	public int Points 
	{
		get
		{
			return _points;
		}
		set
		{
			_points = value;
			hud.UpdatePoints();
			// trigger UI update

			if (value > _highScore) 
			{
				PlayerPrefs.SetInt (key, value);
				_highScore = value;
			}
		}
	}
	public int Health 
	{
		get
		{
			return _health;
		}
		set
		{
			_health = value;
			hud.UpdateHealth();
			// trigger UI update

			hud.UpdateHealth ();
			if (_health <= 0) 
			{
				hud.GameOver ();
			}
		}
	}

	public int HighScore
	{
		get{
			return _highScore;
		}
			
	}
}
