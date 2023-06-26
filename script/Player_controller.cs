using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_controller : MonoBehaviour
{
	public float speed = 7f;
	public float jumpspeed = 7f;
	private float movement= 0f;
  	private Rigidbody2D rigidBody ;
	public Transform  groundCheckpoint ;
       	public float groundCheckRadius = 6f ; 
	public LayerMask groundLayer ; 
	private bool isTouchingGround ; 
	private Animator   playerAnimation ; 
	public Vector3 returnPoint ; // to store the point to return it 
	public delay_manager  delayForplayer ; //for delay
	public nextlevel  text; // for text
 
     // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D> () ; 
	playerAnimation = GetComponent<Animator> () ;
	returnPoint  = transform.position ; 
	delayForplayer = FindObjectOfType < delay_manager > () ;
	text = FindObjectOfType < nextlevel  > () ;
    }

    // Update is called once per frame
    void Update()
    {
		
	isTouchingGround = Physics2D.OverlapCircle(groundCheckpoint.position  , groundCheckRadius , groundLayer  ) ; 
        movement =  Input.GetAxis ("Horizontal") ;
	//Debug.Log (movement) ; 
	if(movement  > 0f) { // rigth move
	rigidBody.velocity = new Vector2(movement*speed , rigidBody.velocity.y) ;
	transform.localScale = new Vector2(0.7437362f, 0.8806766f) ;
	}
	 else if(movement < 0f) { // left move

	rigidBody.velocity = new Vector2(movement*speed , rigidBody.velocity.y) ;
	transform.localScale = new Vector2(-0.7437362f, 0.8806766f) ;

	}
	else{
	rigidBody.velocity = new Vector2(0 , rigidBody.velocity.y) ;
	}


	if(Input.GetButtonDown("Jump") &&  isTouchingGround ){
   	 rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpspeed ) ;
	}
	 //for rigth and left move and convert negative value to poistive
	playerAnimation.SetFloat("speed" , Mathf.Abs(rigidBody.velocity.x) );

 	// for show the player on the ground or not 
	playerAnimation.SetBool("onGround" , isTouchingGround  ) ; 

    }


	//for show if touch the border when drop
	
	void OnTriggerEnter2D(Collider2D other){
         
 	if(other.tag == "fulldetected" || other.tag == "pom"  || other.tag == "bat" ){
     	// when drop 
		
	    //transform.position = returnPoint ; old methods
		delayForplayer.delays_value() ; 
	}
	if (other.tag == "Checkpiont"){
	// store the value will return it

		returnPoint = other.transform.position  ; 
	}

	
	if(other.tag == "nextlevel"  ){
		
		  text.text_active() ; 
		 
	 } 

	     	
	if(other.tag == "endGame"  ){
		
		  delayForplayer.end_text();
		 
	 }


   	} 



}
 