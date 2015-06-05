using UnityEngine;
using System.Collections;

public interface Subject{

	void register(ref Paketic o);
	void remove(Paketic o);
	void notify(); 
}
