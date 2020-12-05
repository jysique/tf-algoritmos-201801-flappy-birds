using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMoreMovScript : MonoBehaviour {
	private Rigidbody2D bodyItemMM;
	public GameController gameController;
	public float itemMMValue;
	private ItemsGeneratorControl itemGenerator;
	// Use this for initialization
	void Start () {
		bodyItemMM = GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void Update () {
		Vector2 movItemMM = new Vector2 (-0.6f, 0);
		bodyItemMM.velocity = movItemMM;
	}
	public void DestroyItemMM(){	
		//gameController.ChangeMov (itemMMValue);
		//gameController.IncreaseScore (itemMMValue);

		Destroy (this.gameObject);
	}
	public void setGameManager(GameController tmp){
		gameController = tmp;

	}
	public void setItemGeneratorControl(ItemsGeneratorControl tmp){
		itemGenerator = tmp;
	}
}
