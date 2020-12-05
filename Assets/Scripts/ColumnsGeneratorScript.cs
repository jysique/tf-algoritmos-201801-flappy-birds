using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnsGeneratorScript : MonoBehaviour {

	// Use this for initialization
	public GameObject columnToCreate;
	//Crear columna
	public float timerToCreate; 
	public float currentTimeToCreate;
	public bool canCreatColumn;
	public float minYPositiontoCreate;
	public float maxYPositiontoCreate;

	public GameController gameManager;

	public List <ColumnaScript> allColumnas;

	void Start () {
		CreateColumn ();

	}
	
	// Update is called once per frame
	void Update () {
		if (canCreatColumn == true) {
			currentTimeToCreate = currentTimeToCreate+ 1*Time.deltaTime; //time.deltaTime: hace que el tiempo corra igual. 
			if (currentTimeToCreate > timerToCreate) {
				currentTimeToCreate = timerToCreate;
				canCreatColumn = false;
				CreateColumn();
			}
		}
	}
	void CreateColumn(){
		
		float randomY = Random.Range (minYPositiontoCreate, maxYPositiontoCreate);
		//Instantiate (columnToCreate, new Vector2 (1.5f, randomY),transform.rotation);//rotacion
		canCreatColumn =true;
		currentTimeToCreate = 0;
		GameObject columnTmp =Instantiate (columnToCreate, new Vector2 (1.5f, randomY),transform.rotation);//rotacion
		columnTmp.GetComponent<ColumnaScript> ().SetColumnGeneratorControl (this.gameObject.GetComponent<ColumnsGeneratorScript> ());
		//allColumnas.Add (columnTmp.GetComponent<ColumnaScript>());
		columnTmp.GetComponent<ColumnaScript> ().setGameManager (gameManager);

	}

}
