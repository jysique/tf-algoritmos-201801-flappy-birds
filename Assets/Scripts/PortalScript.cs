using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PortalScript : MonoBehaviour {
	private Rigidbody2D bodyPortal;
	public GameController gameController;
	private PortalGeneratorControl portalGenerator;
	//private float speedColumns;
	private int nroCoins;
	private int nroEnemys;
	private int nroItemsMM;
	private int nroItemsLM;
	private int nroID;
	// 
	// Use this for initialization
	void Start () {
		bodyPortal = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 movPortal = new Vector3 (-0.6f, 0);
		bodyPortal.velocity = movPortal;
	}
	public void DestroyPortal(){
		Destroy (this.gameObject);
	}
	public void SetGameManager(GameController tmp){
		gameController = tmp;
	}
	public void SetPortalControl(PortalGeneratorControl tmp){
		portalGenerator = tmp;
	}



}
