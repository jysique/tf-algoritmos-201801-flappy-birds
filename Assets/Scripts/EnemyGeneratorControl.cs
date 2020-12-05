using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGeneratorControl : MonoBehaviour {
	[Header("Position Enemy Variables")] //subtitulos
	public float minYPosition;
	public float maxYPosition;
	[Header("Time Enemy Variables")]
	public float currentTimeToCreate;
	public float timeToCreate;
	[Header("Other Enemy Variables")]
	public List <Enenscript> allEnemies;
	public bool canCreateEnemy;
	public GameObject enemyToCreate;
	public GameController gameManager;

	private int maxNumbEnemy;


	// Use this for initializatio
	void Awake(){
		
		maxNumbEnemy = Random.Range(3,30);
	}
	void Start () {
		//numbEnemy = PlayerPrefs.GetInt ("NumbOfEnemies");
	}
	// Update is called once per frame
	void Update () {
		if (allEnemies.Count < maxNumbEnemy) {
			if (canCreateEnemy == true) {
				currentTimeToCreate = currentTimeToCreate + 1 * Time.deltaTime;
				if (currentTimeToCreate > timeToCreate) {
					currentTimeToCreate = timeToCreate;
					canCreateEnemy = false;
					CreateEnemy ();
				}
			}
		}
	}

	void CreateEnemy(){
		float yPosition = Random.Range (minYPosition, maxYPosition);
		Vector3 positionToCreate = new Vector3 (this.transform.position.x, yPosition, 0);

		GameObject enemyTmp = Instantiate (enemyToCreate, positionToCreate, transform.rotation);
		enemyTmp.GetComponent<Enenscript> ().SetEnemyGeneratorControl (this.gameObject.GetComponent<EnemyGeneratorControl> ());
		allEnemies.Add (enemyTmp.GetComponent<Enenscript>());
		enemyTmp.GetComponent<Enenscript> ().setGameManager (gameManager);
		currentTimeToCreate = 0;
		canCreateEnemy = true;
	}
	public void DestroyEnemy(GameObject tmp){
		allEnemies.Remove (tmp.GetComponent<Enenscript> ());
		Destroy (tmp);
	}
	public int getNumberEnemies(){
		return maxNumbEnemy;
	}
	public void NumberEnemies(int newNumberEnemies){
		maxNumbEnemy = newNumberEnemies;
	}

}
