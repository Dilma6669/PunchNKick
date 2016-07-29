using UnityEngine;

public class Player1Controller : MonoBehaviour
{
	//public int m_PlayerNumber = 1;         
	public float speed = 5f;                 
	   
	private Animator anim;

	//player is facing right instead of left.
	private bool facingRight;



	private void Start()
	{
		facingRight = true;
		anim = GetComponent<Animator> ();
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

		// Flip Player Over //
		turn (moveHorizontal);

		if(
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