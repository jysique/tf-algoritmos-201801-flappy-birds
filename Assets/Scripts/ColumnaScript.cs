using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnaScript : MonoBehaviour {
	private Rigidbody2D rbColumna;
	public float speedX;
	//public GameObject columnToCreate;
	public float minYPositiontoCreate;
	public float maxYPositiontoCreate;
//	public bool thisIsColumnDowm;

	public GameController gameController;
	private ColumnsGeneratorScript columnsGenerator;
	public int columnValue;
	// Use this for initialization
	void Start () {
		rbColumna = GetComponent<Rigidbody2D> ();
//		if (thisIsColumnDowm == true) {
//			CreateColumno ();
//		}

	}
	
	// Update is called once per frame
	void Update () {
		rbColumna.velocity = new Vector2 (speedX*Time.deltaTime, 0);

	}
//	void CreateColumno(){
		//float randomY = Random.Range (minYPositiontoCreate, maxYPositiontoCreate);
		//Instantiate (columnToCreate, new Vector2 (this.transform.position.x,this.transform.position.y+randomY), transform.rotation);
//	}
	public void HitColumn(){
		gameController.IncreaseScore (columnValue);
	}
	public void setGameManager(GameController tmp){
		gameController = tmp;
	}
	public void SetColumnGeneratorControl(ColumnsGeneratorScript tmp){
		columnsGenerator = tmp;
	}

}
