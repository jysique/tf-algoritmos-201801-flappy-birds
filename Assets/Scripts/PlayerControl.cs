using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerControl : MonoBehaviour {

    private bool isGround;
	private Rigidbody2D bodyPlayer;
    private Animator animPlayer;
    private float maxSpeed=5;
	public float speed;
	private float maxSpeedChange=2.2f;
	private float minSpeedChange=0.3f;
	private float speedChange;
	public GameController gameController;

	public Text currentMovText;
	private float currentMov;
	private float currentMovF;


    //public float upForce = 200f;
	// Use this for initialization
	void Start () {
		speedChange = Random.Range (minSpeedChange, maxSpeedChange);
        bodyPlayer = GetComponent<Rigidbody2D>();
        animPlayer = GetComponent<Animator>();
	}

	// Update is called once per frame
	void FixedUpdate () {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
		if (isGround) return;
		Vector2 movimiento = new Vector2 (moveHorizontal * speed, moveVertical * speed); //Velocidad al cuerpo
		bodyPlayer.velocity = movimiento;
        animPlayer.SetTrigger("Flap");
      
        //body.AddForce(new Vector2(0, upForce));
        //mov.velocity = new Vector2(move_horizontal * MaxSpeed, move_vertical * MaxSpeed); //Velocidad al cuerpo
    }

    private void OnCollisionEnter2D(Collision2D other){
		if(other.gameObject.tag  == "Wall"){
			isGround = true;
			animPlayer.SetTrigger("Hit");
			gameController.BirdDie ();
			//gameControl.BirdLose ();
		}
		if (other.gameObject.tag == "Coins") {
			other.gameObject.GetComponent <CoinScript> ().DestroyCoin ();
		}
		if (other.gameObject.tag == "Enemy") {
			other.gameObject.GetComponent <Enenscript> ().HitEnemy ();
		}
		if (other.gameObject.tag == "Tubo") {
			other.gameObject.GetComponent<ColumnaScript> ().HitColumn ();
		}
		if (other.gameObject.tag == "ItemCoin") {
			other.gameObject.GetComponent<ItemCoinsScript> ().DestroyItemCoin ();
		}
		if (other.gameObject.tag == "ItemMoreMov") {
			other.gameObject.GetComponent<ItemMoreMovScript> ().DestroyItemMM ();
			speed = maxSpeed + speedChange;
			//print (speed );
			//print (currentMov);
			//print (currentMovF);
			Mov ();

		}
		if (other.gameObject.tag == "ItemLessMov") {
			other.gameObject.GetComponent<itemLessMovScript> ().DestroyItemLM ();
			speed = maxSpeed - speedChange;
			//print (speed );
			//print (currentMov);
			//print(currentMovF);
			Mov ();

		}
		if (other.gameObject.tag == "Portal") {
			//other.gameObject.GetComponent<PortalScript> ().DestroyPortal ();
			gameController.CallPortal ();
		}
    }

	//public float PercentageSpeed(){
	//	return speed * 100 / maxSpeed;
	//}

	public void Mov(){
		currentMovF = speed* 100/maxSpeed;
		currentMovText.text = "Movimiento: "+ currentMovF.ToString("##.0")+"%";
	}

}
 