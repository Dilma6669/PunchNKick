using UnityEngine;

public class Player1Controller : MonoBehaviour
{
	//public int m_PlayerNumber = 1;         
	public float speed = 5f;   

	private CharacterController player1Control;

	private bool run;
	private float verticalVelocity;
	private float gravity = 14f;
	private float jumpForce = 10f;

	private Animator anim;

	//player is facing right instead of left.
	private bool facingRight;



	private void Start()
	{
		player1Control = GetComponent <CharacterController>();
		run = false;
		anim = GetComponent<Animator> ();
		facingRight = true;
	}
		
	private void Update()
	{
		//Sets Running animation **NEED TO INCREASE SPEED BUT EVERYTHING I'VE TRIED DIDN'T WORK PROPERLY**
		if (Input.GetKey(KeyCode.LeftShift)) 
		{
			run = true;
		} 
		else 
		{
			run = false;
		}

		//Sets Jumping animation
		if (Input.GetKey(KeyCode.Space)) 
		{
			anim.SetBool ("Jumping", true);
		} 
		else 
		{
			anim.SetBool ("Jumping", false);
		}


	}


	private void FixedUpdate()
	{
		// Basic Movement Player //
		float moveHorizontal = Input.GetAxis ("Horizontal1");
		//*************float moveY = verticalVelocity;
		float moveVertical = Input.GetAxis ("Vertical1");

		//Sets x and y basic movement
		transform.Translate (new Vector3 (Time.deltaTime * speed * moveHorizontal, 0, 0));
		//**********transform.Translate (new Vector3 (0, Time.deltaTime * moveY, 0));
		transform.Translate (new Vector3 (0, 0, Time.deltaTime * speed * moveVertical));

		//code for walking animation to flow fluently between x and z planes
		anim.SetFloat ("WalkSpeedX", Mathf.Abs (moveHorizontal));
		anim.SetFloat ("WalkSpeedZ", Mathf.Abs (moveVertical));

		anim.SetBool ("Running", run);
		/*if (run = true)
		{
			speed *= 1.5f;
		}*/





		//Sets Gravity settings for if jumping. THIS CODE AND THE JUMPING ANIMATION CODE MIGHT BE ABLE TO GO TOGETHER SOMEHOW??
		if (player1Control.isGrounded) 
		{
			verticalVelocity = -gravity * Time.deltaTime;
			if (Input.GetKey(KeyCode.Space))
			{
				verticalVelocity = jumpForce;
			}
			else
			{
				verticalVelocity -= gravity * Time.deltaTime;
			}
		}







		// Flip Player Over //
		turn (moveHorizontal);

	}
		

	//code 	for turning the player to either right or left.
	private void turn(float moveHorizontal)
	{
		if (moveHorizontal < 0 && !facingRight || moveHorizontal > 0 && facingRight) 
		{
			facingRight = !facingRight;
			Vector3 playerScale = transform.localScale;
			playerScale.x *= -1;
			transform.localScale = playerScale;
		}
	}

}