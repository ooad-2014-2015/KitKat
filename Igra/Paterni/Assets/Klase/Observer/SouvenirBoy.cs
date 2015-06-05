using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class SouvenirBoy : MonoBehaviour, Subject {

	private List<Paketic> observer;
	private int bodovi;
	public int negativniBodovi;
	private Pozicija pozicija;
	private float maxwidth ;
	private Camera cam;
	private Rigidbody2D rgbd2;
	private Renderer rend;
	public Text scoreText;
	public Text lifeText;
	public GameObject gameOverText;
	public GameObject restartButton;

	void Start()
	{
		observer = new List<Paketic> ();
		pozicija = new Pozicija ();
		rend = GetComponent<Renderer>();
		bodovi = 0;
		negativniBodovi = 3;
		if(cam==null) cam=Camera.main;
		rgbd2= this.gameObject.GetComponent<Rigidbody2D>();
		Vector3 upperCorner = new Vector3 (Screen.width, Screen.height, 0.0f);
		Vector3 targetWidth = cam.ScreenToWorldPoint (upperCorner);
		float playerWidth = rend.bounds.extents.x;
		maxwidth = targetWidth.x-playerWidth;
	}
	
	public void register(ref Paketic o)
	{
		observer.Add (o);
		o.Kreni ();
	}

	public void remove(Paketic o)
	{
		if (observer.Count > 2) {
			observer.Remove (o);
		}
	}

	public void notify()
	{
		if (observer != null) {
			observer.ForEach (x => x.update (this.pozicija));
		}
	}

	public void pomjeriSe(float x)
	{
		Vector3 position = new Vector3(x, 0, 0); 
		this.transform.position = position;
		notify ();
	}
	public void pomjeriSeLijevo()
	{
		pozicija.x -= 0.33f; 
		if (pozicija.x < -maxwidth) pozicija.x = -maxwidth;
		pomjeriSe (pozicija.x);
	}

	public void pomjeriSeDesno()
	{
		pozicija.x += 0.33f; 
		if (pozicija.x > maxwidth) pozicija.x = maxwidth;
		pomjeriSe (pozicija.x);
	}

	public Pozicija getPozicija()
	{
		return this.pozicija;
	}

	public int getBodovi()
	{
		return bodovi;
	}

	public int getNegativniBodovi()
	{
		return negativniBodovi;
	}

	public void setBodovi(int bodovi)
	{
		this.bodovi += bodovi;
	}

	public void setNegativni(int neg)
	{
		this.negativniBodovi += neg;
	}

	void OnTriggerEnter2D(Collider2D other)
	{

		if (other.gameObject.tag == "C" && getNegativniBodovi() != 0) {
			setNegativni(-1);
			Destroy (other.gameObject);

		} else if (other.gameObject.tag == "P" && getNegativniBodovi() != 0) {

			setBodovi(10);
			Destroy (other.gameObject);
			
		} else if (other.gameObject.tag == "Z" && getNegativniBodovi() != 0) {
			setBodovi (50);
			Destroy (other.gameObject);
		} 
		scoreText.text = "Bodovi:\n" + getBodovi();
		lifeText.text = "Zivoti: " + getNegativniBodovi ();
	}
}
