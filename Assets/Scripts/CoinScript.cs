using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour {
	private Rigidbody2D bodyCoin;
	public GameController gameController;
	public int coinValue;
	private CoinGeneratorControl coinGenerator;

	// Use this for initialization
	void Start () {
		bodyCoin = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 movCoin = new Vector2 (-0.6f, 0);
		bodyCoin.velocity = movCoin;
	}
	public void DestroyCoin(){
		gameController.IncreaseScore (coinValue);
		Destroy (this.gameObject);
	}
	public void setGameManager(GameController tmp){
		gameController = tmp;

	}
	public void setCoinManagerGenerator(CoinGeneratorControl tmp){
		coinGenerator = tmp;
	}
}
