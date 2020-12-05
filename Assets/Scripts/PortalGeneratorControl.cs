using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalGeneratorControl : MonoBehaviour {
	public GameObject portalToCreate;
	//Crear columna
	public float timerToCreate; 
	public float currentTimeToCreate;
	public bool canCreatPortal;
	public float minYPositiontoCreate;
	public float maxYPositiontoCreate;

	public GameController gameManager;

	public List <PortalScript> allPortal;
	private int maxNumbPortal;

	//------------------------------


	void Awake(){
		maxNumbPortal = Random.Range(3,6);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (allPortal.Count < maxNumbPortal) {
			if (canCreatPortal == true) {
				currentTimeToCreate = currentTimeToCreate + 1 * Time.deltaTime; //time.deltaTime: hace que el tiempo corra igual. 
				if (currentTimeToCreate > timerToCreate) {
					currentTimeToCreate = timerToCreate;
					canCreatPortal = false;
					CreatePortal ();
				}
			}
		}
	}
	void CreatePortal(){
		float randomY = Random.Range (minYPositiontoCreate, maxYPositiontoCreate);

		//Instantiate (columnToCreate, new Vector2 (1.5f, randomY),transform.rotation);//rotacion
		GameObject portalTmp =Instantiate (portalToCreate, new Vector2 (1.5f, randomY),transform.rotation);//rotacion
		portalTmp.GetComponent<PortalScript> ().SetPortalControl (this.gameObject.GetComponent<PortalGeneratorControl> ());
		allPortal.Add (portalTmp.GetComponent<PortalScript>());
		canCreatPortal =true;
		currentTimeToCreate = 0;
		portalTmp.GetComponent<PortalScript> ().SetGameManager (gameManager);
	}
}
