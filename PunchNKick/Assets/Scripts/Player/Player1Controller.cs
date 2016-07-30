using UnityEngine;

public class Player1Controller : MonoBehaviour
{
	//public int m_PlayerNumber = 1;         
	public float speed = 5f;   

	private CharacterController player1Control;

	private Rigidbody rb;

	private bool run;

	//private bool jump;

	private float verticalVelocity;
	private float gravity = 14f;
	[SerializeField]
	private float jumpForce = 10f;
	//[SerializeField]
	//private Transform[] groundPoints;
	//[SerializeField]
	//private float groundRadius;
	//[SerializeField]
	//private LayerMask whatIsGround;
	//private bool isGrounded;

	private Animator anim;

	//player is facing right instead of left.
	private bool facingRight;



	private void Start()
	{
		player1Control = GetComponent <CharacterController>();
		rb = GetComponent<Rigidbody>();
		run = false;
		//jump = false;
		anim = GetComponent<Animator> ();
		facingRight = true;
	}
		
	private void Update()
	{
		//Sets Running animation **NEED TO INCREASE SPEED by multiplying BUT EVERYTHING I'VE TRIED DIDN'T WORK PROPERLY**
		if (Input.GetKey(KeyCode.LeftShift)) 
		{
			run = true;
			speed = 12f;
		} 
		else 
		{
			run = false;
			speed = 5f;
		}

		//Sets Jumping animation
		if (Input.GetKey(KeyCode.Space)) 
		{
			anim.SetBool ("Jumping", true);
			//jump = true;
		} 
		else 
		{
			anim.SetBool ("Jumping", false);
			//jump = false;
		}


	}


	private void FixedUpdate()
	{
		//isGrounded = IsGrounded();

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

		/*if (isGrounded && jump)
		{
			isGrounded = false;
			rb.AddForce (new Vector3 (0, jumpForce, 0));
		}*/

		// Flip Player Over //
		turn (moveHorizontal);



		//Sets Gravity settings for if jumping. THIS CODE AND THE JUMPING ANIMATION CODE MIGHT BE ABLE TO GO TOGETHER SOMEHOW?

		if (player1Control.isGrounded) 
		{
			verticalVelocity = -gravity * Time.deltaTime;
			if (Input.GetKey(KeyCode.Space))
			{
				verticalVelocity = jumpForce;
				rb.AddForce (new Vector3 (0, jumpForce, 0));
			}
			else
			{
				verticalVelocity -= gravity * Time.deltaTime;
			}
		}








	}
	// THIS IS ANOTHER CODE TO TRY AND GET HIM JUMPING
	/*private bool IsGrounded
	{
		if (rb.velocity.y <= 0)
		{
			foreach (Transform point in groundPoints)
			{
				Collider2D[] colliders = Physics2D.OverlapCircleAll (point.position, groundRadius, whatIsGround);

				for (int i = 0; i < colliders.length; i++)
				{
					if (colliders[i].gameObject != gameObject)
					{
						return true;
					}
				}
			}
		}
		return false;
	}*/

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