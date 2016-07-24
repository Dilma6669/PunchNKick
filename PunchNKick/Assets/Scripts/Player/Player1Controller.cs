using UnityEngine;

public class Player1Controller : MonoBehaviour
{
	//public int m_PlayerNumber = 1;         
	public float speed = 12f;                 
	   
	private Rigidbody2D rb;         
	private float m_MovementInputValue;



	private void Start()
	{
		rb = GetComponent<Rigidbody2D> ();
		//m_MovementAxisName  = "Horizontal" + m_PlayerNumber;
		//m_MovementAxisName = "Vertical" + m_PlayerNumber;
	}
		

	private void FixedUpdate()
	{

		float moveHorizontal = Input.GetAxis ("Horizontal1");
		float moveVertical = Input.GetAxis ("Vertical1");

		transform.Translate( new Vector3(Time.deltaTime * speed * -moveHorizontal,0,0));
		transform.Translate( new Vector3(0,0,Time.deltaTime * speed * -moveVertical));
	}



}