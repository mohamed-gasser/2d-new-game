using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bat_move : MonoBehaviour
{
    public float speed = 7f;
	public float jumpspeed = 7f;
	private float movement= 0f;
  	private Rigidbody2D rigidBody ;
	
     // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D> () ; 
	
    }

    // Update is called once per frame
    void Update()
    {
		
	
	rigidBody.velocity = new Vector2(speed , rigidBody.velocity.y) ;
	
    }
    
   
	

     	
   	


}
 