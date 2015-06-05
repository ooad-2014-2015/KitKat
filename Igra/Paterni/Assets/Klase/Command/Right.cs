using UnityEngine;
using System.Collections;

public class Right : MonoBehaviour, Kretanje {

	protected SouvenirBoy boy;
	public string Parametar { get; set; }

	public Right(ref SouvenirBoy s)
	{
		boy = s;
	}

	public void pomjeriSe ()
	{
		boy.pomjeriSeDesno ();
	}
}
