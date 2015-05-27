using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {
	
	public Camera cam;

	public GameObject poklon;

	public float timeLeft=15;

   	public float maxwidth;

	public Text timerText;

	public GameObject gameOverText;

	public GameObject restartButton;
	

	// Use this for initialization
	void Start () {
		if (cam == null) {
			cam = Camera.main;
		}
		Vector3 upperCorner = new Vector3 (Screen.width, Screen.height, 0.0f);
		Vector3 targetWidth = cam.ScreenToWorldPoint (upperCorner);
			float poklonWidth = poklon.GetComponent<Renderer>().bounds.extents.x;
		maxwidth = targetWidth.x - poklonWidth;
		StartCoroutine (Spawn ());
		timerText.text = "Preostalo vrijeme:\n" + Mathf.RoundToInt (timeLeft);
	}

	void FixedUpdate(){
		timeLeft -= Time.deltaTime;
		if (timeLeft < 0) {
			timeLeft = 0;
		}
		timerText.text = "Preostalo vrijeme:\n" + Mathf.RoundToInt (timeLeft);
	}

	IEnumerator Spawn(){
		yield return new WaitForSeconds (2.0f);
		while (timeLeft>0) {
			Vector3 spawnPosition = new Vector3 (Random.Range (-maxwidth, maxwidth), transform.position.y, 0.0f);
			Quaternion spawnRotation = Quaternion.identity;
			Instantiate (poklon, spawnPosition, spawnRotation);
			yield return new WaitForSeconds(Random.Range(1.0f,2.0f));
		}
		yield return new WaitForSeconds(2.0f);
		gameOverText.SetActive (true);
		yield return new WaitForSeconds(2.0f);
		restartButton.SetActive (true);
	}
}
