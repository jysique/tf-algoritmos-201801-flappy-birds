using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsGeneratorControl : MonoBehaviour {
	[Header("Position Items Variables")] //subtitulos
	public float minYPosition;
	public float maxYPosition;
	[Header("Time Items Variables")]
	public float currentTimeToCreate;
	public float timeToCreate;

	public float currentTimeToCreateMM;
	public float timeToCreateMM;

	public float currentTimeToCreateLM;
	public float timeToCreateLM;

	[Header("Other Variables")]
	public List <ItemCoinsScript> allItemCoin;
	public List <ItemMoreMovScript> allItemMM;
	public List <itemLessMovScript> allItemLM;
	public bool canCreateItemCoin;
	public bool canCreateItemMM;
	public bool canCreateItemLM;
	public GameObject itemCoinToCreate;
	public GameObject itemMMToCreate;
	public GameObject itemLMToCreate;
	public GameController gameManager;

	private int maxNumbItemCoin;
	private int maxNumbItemMM;
	private int maxNumbItemLM;

	void Awake(){
		maxNumbItemMM = Random.Range(3,10);
		maxNumbItemLM = Random.Range(3,10);
		maxNumbItemCoin = Random.Range(3,10);
	}


	// Use this for initialization
	void Start () {
		//maxNumbItemCoin = PlayerPrefs.GetInt ("NumbOfItemCoins");
		//maxNumbItemMM= PlayerPrefs.GetInt ("NumbOfItemMM");
		//maxNumbItemLM = PlayerPrefs.GetInt ("NumbOfItemLM");
	}
	
	// Update is called once per frame
	void Update () {
		if (allItemCoin.Count < maxNumbItemCoin) {
			if (canCreateItemCoin == true) {
				currentTimeToCreate = currentTimeToCreate + 1 * Time.deltaTime;
				if (currentTimeToCreate > timeToCreate) {
					currentTimeToCreate = timeToCreate;
					canCreateItemCoin = false;
					CreateItemCoin ();
				}
			}
		}
		if (allItemMM.Count < maxNumbItemMM){
			if (canCreateItemMM == true) {
				currentTimeToCreateMM = currentTimeToCreateMM + 1 * Time.deltaTime;	
				if (currentTimeToCreateMM > timeToCreateMM) {
					currentTimeToCreateMM= timeToCreateMM;
					canCreateItemMM = false;
					CreateItemMM ();
				}
			}
		}
		if (allItemLM.Count < maxNumbItemLM){
			if (canCreateItemLM == true) {
				currentTimeToCreateLM = currentTimeToCreateLM + 1 * Time.deltaTime;	
				if (currentTimeToCreateLM > timeToCreateLM) {
					currentTimeToCreateLM= timeToCreateLM;
					canCreateItemLM = false;
					CreateItemLM ();
				}
			}
		}

	}
	void CreateItemCoin (){
		float yPositionItemCoin = Random.Range (minYPosition, maxYPosition);
		Vector3 positionToCreate = new Vector3 (this.transform.position.x, yPositionItemCoin, 0);

		GameObject itemCoinTmp = Instantiate (itemCoinToCreate, positionToCreate, transform.rotation);
		itemCoinTmp.GetComponent<ItemCoinsScript> ().setItemGeneratorControl (this.gameObject.GetComponent<ItemsGeneratorControl> ());
		allItemCoin.Add (itemCoinTmp.GetComponent<ItemCoinsScript>());
		itemCoinTmp.GetComponent<ItemCoinsScript> ().setGameManager (gameManager);
		currentTimeToCreate = 0;
		canCreateItemCoin = true;
	}
	void CreateItemMM (){
		float yPositionItemMM = Random.Range (minYPosition, maxYPosition);
		Vector3 positionToCreate = new Vector3 (this.transform.position.x, yPositionItemMM, 0);

		GameObject itemMMTmp = Instantiate (itemMMToCreate, positionToCreate, transform.rotation);
		itemMMTmp.GetComponent<ItemMoreMovScript> ().setItemGeneratorControl (this.gameObject.GetComponent<ItemsGeneratorControl> ());
		allItemMM.Add (itemMMTmp.GetComponent<ItemMoreMovScript>());
		itemMMTmp.GetComponent<ItemMoreMovScript> ().setGameManager (gameManager);
		currentTimeToCreateMM = 0;
		canCreateItemMM = true;
	}
	void CreateItemLM (){
		float yPositionItemLM = Random.Range (minYPosition, maxYPosition);
		Vector3 positionToCreate = new Vector3 (this.transform.position.x, yPositionItemLM, 0);

		GameObject itemLMTmp = Instantiate (itemLMToCreate, positionToCreate, transform.rotation);
		itemLMTmp.GetComponent<itemLessMovScript> ().setItemGeneratorControl (this.gameObject.GetComponent<ItemsGeneratorControl> ());
		allItemLM.Add (itemLMTmp.GetComponent<itemLessMovScript>());
		itemLMTmp.GetComponent<itemLessMovScript> ().setGameManager (gameManager);
		currentTimeToCreateLM = 0;
		canCreateItemLM = true;
	}		

	public int getNumberItemCoins(){
		return maxNumbItemCoin;
	}

	public int getNumberItemMM(){
		return maxNumbItemMM;
	}

	public int getNumberItemLM(){
		return maxNumbItemLM;
	}

	public void setNumberItemsMM(int newNumberItemsMM){
		maxNumbItemMM = newNumberItemsMM;
	}
	public void setNumberItemsLM(int newNumberItemsLM){
		maxNumbItemLM = newNumberItemsLM;
	}

}
