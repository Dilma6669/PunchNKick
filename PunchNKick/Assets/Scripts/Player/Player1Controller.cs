using UnityEngine;

public class Player1Controller : MonoBehaviour
{
	//public int m_PlayerNumber = 1;         
	public float speed = 12f;                 
	   
	private Rigidbody rb;

	private bool facingRight;
	//player is facing right instead of left.



	private void Start()
	{
		facingRight = true;
		rb = GetComponent<Rigidbody> ();
	}
		

	private void FixedUpdate()
	{

		float moveHorizontal = Input.GetAxis ("Horizontal1");
		float moveVertical = Input.GetAxis ("Vertical1");

		transform.Translate( new Vector3(Time.deltaTime * speed * -moveHorizontal,0,0));
		transform.Translate( new Vector3(0,0,Time.deltaTime * speed * -moveVertical));

		Turn (moveHorizontal);
	}

	private void Turn(float moveHorizontal)
	//code for turning the player to either right or left.
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