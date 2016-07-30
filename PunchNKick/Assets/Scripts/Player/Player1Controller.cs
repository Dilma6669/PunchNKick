using UnityEngine;

public class Player1Controller : MonoBehaviour
{   
	public float speed = 5f;   

	private Rigidbody rb;

	private bool run;

	private float jumpHeight = 7f;
	private bool jump = true;
	private float jumptimer;

	private Animator anim;

	//player is facing right instead of left.
	private bool facingRight;



	private void Start()
	{
		rb = GetComponent<Rigidbody>();
		run = false;
		anim = GetComponent<Animator> ();
		facingRight = true;
	}
		
	private void Update()
	{
		//Sets Running animation
		if (Input.GetKey(KeyCode.LeftShift)) 
		{
			run = true;
			speed *= 2;
		} 
		else 
		{
			run = false;
			speed = 5f;
		}
	}


	private void FixedUpdate()
	{

		// Basic Movement Player //
		float moveHorizontal = Input.GetAxis ("Horizontal1");
		float moveVertical = Input.GetAxis ("Vertical1");

		//Sets x and y basic movement
		transform.Translate (new Vector3 (Time.deltaTime * speed * moveHorizontal, 0, 0));
		transform.Translate (new Vector3 (0, 0, Time.deltaTime * speed * moveVertical));

		//code for walking animation to flow fluently between x and z planes
		anim.SetFloat ("WalkSpeedX", Mathf.Abs (moveHorizontal));
		anim.SetFloat ("WalkSpeedZ", Mathf.Abs (moveVertical));

		anim.SetBool ("Running", run);

		// Flip Player Over //
		turn (moveHorizontal);

		if (Input.GetKeyDown (KeyCode.Space)) {
			if (jump == true) {

				anim.SetBool ("Jumping", true);

				rb.velocity = new Vector2 (rb.velocity.x, jumpHeight);
				jump = false;
			}
		}
			
		if (jump == false) {


			jumptimer = jumptimer + 1;
			if (jumptimer >= 50) {
				jumptimer = 0;
				anim.SetBool ("Jumping", false);
				jump = true;
			}
		}
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