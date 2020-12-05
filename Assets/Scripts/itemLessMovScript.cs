using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemLessMovScript : MonoBehaviour {
	private Rigidbody2D bodyItemLM;
	public GameController gameController;
	public float itemLMValue;
	private ItemsGeneratorControl itemGenerator;
	// Use this for initialization
	void Start () {
		bodyItemLM = GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void Update () {
		Vector2 movItemLM = new Vector2 (-0.6f, 0);
		bodyItemLM.velocity = movItemLM;
	}
	public void DestroyItemLM(){
		Destroy (this.gameObject);
	}
	public void setGameManager(GameController tmp){
		gameController = tmp;

	}
	public void setItemGeneratorControl(ItemsGeneratorControl tmp){
		itemGenerator = tmp;
	}
}
