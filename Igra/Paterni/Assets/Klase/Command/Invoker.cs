using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Invoker {

	private List<Kretanje> k;

	public Invoker(){
		k = new List<Kretanje> ();
	}
	public void Uradi(Kretanje k) 
	{ 
		this.k.Add (k);
		k.pomjeriSe ();
	}
}
