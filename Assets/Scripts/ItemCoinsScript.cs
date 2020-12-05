using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCoinsScript : MonoBehaviour {
	private Rigidbody2D bodyItemCoin;
	public GameController gameController;
	public int itemCoinValue;
	private ItemsGeneratorControl itemGenerator;
	// Use this for initialization
	void Start () {
		bodyItemCoin = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 movItemCoin = new Vector2 (-0.6f, 0);
		bodyItemCoin.velocity = movItemCoin;
	}
	public void DestroyItemCoin(){	
		gameController.IncreaseScore (itemCoinValue);
		Destroy (this.gameObject);
	}
	public void setGameManager(GameController tmp){
		gameController = tmp;

	}
	public void setItemGeneratorControl(ItemsGeneratorControl tmp){
		itemGenerator = tmp;
	}
}
