using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGeneratorControl : MonoBehaviour {
	[Header("Position Coin Variables")] //subtitulos
	public float minYPosition;
	public float maxYPosition;
	[Header("Time Coin Variables")]
	public float currentTimeToCreate;
	public float timeToCreate;
	[Header("Other Coin Variables")]
	public List <CoinScript> allCoin;
	public bool canCreateCoin;
	public GameObject coinToCreate;
	public GameController gameManager;


	private int maxNumbCoin;
	// Use this for initialization

	void Awake(){
		//maxNumbCoin = PlayerPrefs.GetInt ("NumbOfCoins");
		maxNumbCoin = Random.Range(3,30);
	}

	void Start () {
		//PlayerPrefs.SetInt ("NumbOfCoins", maxNumbCoin);
	//	maxNumbCoin = PlayerPrefs.GetInt ("NumbOfCoins");
	}
	
	// Update is called once per frame
	void Update () {
		if (allCoin.Count < maxNumbCoin) {
			if (canCreateCoin == true) {
				currentTimeToCreate = currentTimeToCreate + 1 * Time.deltaTime;
				if (currentTimeToCreate > timeToCreate) {
					currentTimeToCreate = timeToCreate;
					canCreateCoin = false;
					CreateCoin ();
				}
			}
		}
	}
	void CreateCoin(){
		float yPosition = Random.Range (minYPosition, maxYPosition);
		Vector3 positionToCreate = new Vector3 (this.transform.position.x, yPosition, 0);

		GameObject coinTmp = Instantiate (coinToCreate, positionToCreate, transform.rotation);
		coinTmp.GetComponent<CoinScript> ().setCoinManagerGenerator (this.gameObject.GetComponent<CoinGeneratorControl> ());
		allCoin.Add (coinTmp.GetComponent<CoinScript>());
		coinTmp.GetComponent<CoinScript> ().setGameManager (gameManager);
		currentTimeToCreate = 0;
		canCreateCoin = true;
	}

	public int getNumberCoins(){
		return maxNumbCoin;
	}
	public void setNumberCoins(int newNumberCoins){
		maxNumbCoin = newNumberCoins;
	}
}
