using UnityEngine;
using System.Collections;

public class Left : MonoBehaviour, Kretanje {

	protected SouvenirBoy boy;
	public string Parametar { get; set; }
	
	public Left(ref SouvenirBoy s)
	{
		boy = s;
	}
	
	public void pomjeriSe ()
	{
		boy.pomjeriSeLijevo ();
	}
}
