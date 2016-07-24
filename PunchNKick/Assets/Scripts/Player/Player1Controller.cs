using UnityEngine;

public class Player1Controller : MonoBehaviour
{
	public int m_PlayerNumber = 1;         
	public float m_Speed = 12f;                 

	private string m_MovementAxisName;   
	private Rigidbody m_Rigidbody;         
	private float m_MovementInputValue;


	private void Awake()
	{
		m_Rigidbody = GetComponent<Rigidbody>();
	}


	private void OnEnable ()
	{
		m_Rigidbody.isKinematic = false;
		m_MovementInputValue = 0f;
	}


	private void OnDisable ()
	{
		m_Rigidbody.isKinematic = true;
	}


	private void Start()
	{
		m_MovementAxisName  = "Horizontal" + m_PlayerNumber;
		m_MovementAxisName = "Vertical" + m_PlayerNumber;
	}
		
	private void Update()
	{
		m_MovementInputValue = Input.GetAxis (m_MovementAxisName);
	}

	private void FixedUpdate()
	{
		// Move and turn the tank.
		Move ();
	}


	private void Move()
	{
		// Adjust the position of the tank based on the player's input.
		Vector3 movement = transform.forward * m_MovementInputValue * m_Speed * Time.deltaTime;

		m_Rigidbody.MovePosition (m_Rigidbody.position + movement);
	}
}
//            movement = movement.normalized * speed * Time.deltaTime;