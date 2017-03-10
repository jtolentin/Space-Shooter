using UnityEngine;
using System.Collections;
/*
 * 	Source File Name: DestroyObjectController.cs
 *  Name: Jhun Kyle Tolentino
 *  Student Number: 100955026
 * 	Program Description : This controls on how the enemy ship spawns in the scene.
 * 	Date: October 23, 2016
 * 	Last Modified by: Jhun Kyle Tolentino
 * 	Date Last Modified: October 23, 2016
 * 	Revision History:  
 * 
 */
public class DestroyObjectController : MonoBehaviour {

	public void End(){
		Destroy (gameObject);
	}
}
