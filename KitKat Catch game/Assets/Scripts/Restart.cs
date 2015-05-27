using UnityEngine;
using System.Collections;

public class Restart : MonoBehaviour {

	public void RestartGame(){
		Application.LoadLevel (Application.loadedLevel);
	}
}
