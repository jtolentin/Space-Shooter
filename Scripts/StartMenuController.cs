using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
/*
 * 	Source File Name:
 *  Name: Jhun Kyle Tolentino
 *  Student Number: 100955026
 * 	Program Description : This controls on how the Startmenu function.
 * 	Date: October 25, 2016
 * 	Last Modified by: Jhun Kyle Tolentino
 * 	Date Last Modified: October 25, 2016
 * 	Revision History: Added ControlsMenu and StartMenu - October 25, 2016 
 * 
 */
public class StartMenuController : MonoBehaviour {

	[SerializeField]
	Button startButton = null;
	[SerializeField]
	Button controlsButton = null;
	[SerializeField]
	Button backtoMainButton = null;
	[SerializeField]
	GameObject title = null;
	[SerializeField]
	Text controls = null;

	public void LoadScene(string loadScene)
	{
		SceneManager.LoadScene (loadScene);
	}

	void Start()
	{
		StartMenu ();
	}

	public void ControlsMenu()
	{
		backtoMainButton.gameObject.SetActive (true);
		controls.gameObject.SetActive (true);
		startButton.gameObject.SetActive (false);
		controlsButton.gameObject.SetActive (false);
		title.gameObject.SetActive (false);
	}
	public void StartMenu(){
	
		backtoMainButton.gameObject.SetActive (false);
		controls.gameObject.SetActive (false);
		startButton.gameObject.SetActive (true);
		controlsButton.gameObject.SetActive (true);
		title.gameObject.SetActive (true);
	}
}
