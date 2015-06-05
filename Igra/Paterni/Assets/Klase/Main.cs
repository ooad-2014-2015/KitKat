using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Main : MonoBehaviour {

	public SouvenirBoy boy;
	public Invoker i = new Invoker();
	public Kretanje Lijevo;
	public Kretanje Desno;
	public Paketic paketic;
	public List<IState> istate;
	public GameObject gameOverText;
	public GameObject restartButton;
	public Observer o;
	void Start()
	{
		Lijevo = new Left(ref boy);
		Desno = new Right(ref boy);
		istate = new List<IState>();

		StartCoroutine (Rutina ());
	}
	
	void FixedUpdate () {
		if (Input.GetKey(KeyCode.RightArrow)) { i.Uradi(Desno); }
		if (Input.GetKey(KeyCode.LeftArrow)) { i.Uradi(Lijevo); }
	}

	IEnumerator Rutina()
	{
		while (boy.getNegativniBodovi() != 0) {

			boy.register(ref paketic);

			yield return new WaitForSeconds(Random.Range(0.5f, 2.0f));

			boy.remove(paketic);
		}
		yield return new WaitForSeconds(1.0f);
		gameOverText.SetActive (true);
		yield return new WaitForSeconds(2.0f);
		restartButton.SetActive (true);
	}
}
