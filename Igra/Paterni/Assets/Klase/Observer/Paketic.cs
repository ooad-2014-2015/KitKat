using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Paketic : MonoBehaviour, Observer, IState {

	private IState stanje;
	private int brojPoena;
	private Pozicija pozicijaPaketic;
	public Subject subject;
	private Camera cam;
	private float maxwidth;
	private Rigidbody2D rgbd2;
	public List<GameObject> poklon;
	private GameObject trenutni;

	public Paketic(){}

	void FixedUpdate () {
		//Debug.Log ("X: " + this.transform.position.x);
		//Debug.Log ("Y: " + this.transform.position.y);

	}

	public void Kreni()
	{
		if (cam == null) { cam = Camera.main; }
		Vector3 upperCorner = new Vector3 (Screen.width, Screen.height, 0.0f);
		Vector3 targetWidth = cam.ScreenToWorldPoint (upperCorner);
		float poklonWidth = poklon[0].GetComponent<Renderer>().bounds.extents.x;
		maxwidth = targetWidth.x - poklonWidth;	
		
		Vector3 spawnPosition = new Vector3 (Random.Range (-maxwidth, maxwidth), 8.0f, 0.0f);
		Quaternion spawnRotation = Quaternion.identity;

		int j = Random.Range (0, 3);
		trenutni = poklon [j];
		if (trenutni.tag == "C") {
			stanje = new CrveniPaketic();
			brojPoena = stanje.azurirajBodove();
		}
		if (trenutni.tag == "P") {
			stanje = new PlaviPaketic();
			brojPoena = stanje.azurirajBodove();
		}
		if (trenutni.tag == "Z") {
			stanje = new ZeleniPaketic();
			brojPoena = stanje.azurirajBodove();
		}

		Instantiate (trenutni, spawnPosition, spawnRotation);
	}

	public void update(Pozicija pozicija){

	}


	public void setBrojPoena(int brojPoena)
	{
		this.brojPoena = brojPoena;
	}

	public int getBrojPoena()
	{
		return brojPoena;
	}
	
	//Odnose se na state pattern
	public void setState(IState state)
	{
		stanje = state;
		brojPoena = azurirajBodove ();
	}
	
	public int azurirajBodove()
	{
		return stanje.azurirajBodove ();
	}
	void OnTriggerEnter2D(Collider2D other)
	{

	}
}
