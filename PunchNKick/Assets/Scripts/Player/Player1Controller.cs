using UnityEngine;

public class Player1Controller : MonoBehaviour
{
	//public int m_PlayerNumber = 1;         
	public float speed = 5f;                 
	   
	private Animator anim;

	private bool facingRight;
	//player is facing right instead of left.



	private void Start()
	{
		facingRight = true;
		anim = GetComponent<Animator> ();
	}
		

	private void FixedUpdate()
	{

		float moveHorizontal = Input.GetAxis ("Horizontal1");
		float moveVertical = Input.GetAxis ("Vertical1");

		transform.Translate (new Vector3 (Time.deltaTime * speed * -moveHorizontal, 0, 0));
		transform.Translate (new Vector3 (0, 0, Time.deltaTime * speed * -moveVertical));
		//Sets x and y basic movement

		anim.SetFloat ("WalkSpeedX", Mathf.Abs (moveHorizontal));
		anim.SetFloat ("WalkSpeedZ", Mathf.Abs (moveVertical));
		//code for walking animation to flow fluently between x and z planes

		turn (moveHorizontal);
	}

	private void turn(float moveHorizontal)
	//code 	for turning the player to either right or left.
	{
		if (moveHorizontal > 0 && !facingRight || moveHorizontal < 0 && facingRight) 
		{
			facingRight = !facingRight;

			Vector3 playerScale = transform.localScale;

			playerScale.x *= -1;

			transform.localScale = playerScale;

		}
	}





}