using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScroolingScene : MonoBehaviour {
	Vector3 starPos;
	public float speed;
	// Use this for initialization
	private void Awake(){

	}
	void Start () {

		starPos = transform.position;

	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate ((new Vector3 (-1, 0, 0)) * speed * Time.deltaTime);

		if(transform.position.x<-5.13){
			transform.position = starPos;
		}
	}

}
