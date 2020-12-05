using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DestroyerControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Tubo") {
			Destroy (other.gameObject);
		}
		if (other.gameObject.tag == "Enemy") {
			other.GetComponent<Enenscript> ().SendDestroy ();
		}
		if (other.gameObject.tag == "Coins") {
			Destroy (other.gameObject);
		}
		if (other.gameObject.tag == "ItemCoin") {
			Destroy (other.gameObject);
		}
		if (other.gameObject.tag == "ItemMoreMov") {
			Destroy (other.gameObject);
		}
		if (other.gameObject.tag == "ItemLessMov") {
			Destroy (other.gameObject);
		}
		if (other.gameObject.tag == "Portal") {
			Destroy (other.gameObject);
		}
	}
}
