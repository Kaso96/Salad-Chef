using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int m_PlayerNumber;
    public float m_Speed = 10f;
    public float m_TurnSpeed = 180f;

    private string m_MovementAxisName;
    private string m_TurnAxisName;
    private Rigidbody m_Rigidbody;
    private float m_MovementInputValue = 0f;
    private float m_TurnInputValue = 0f;



	// Use this for initialization
	void Awake ()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
	}

    void Start()
    {
        m_MovementAxisName = "Vertical" + m_PlayerNumber;
        m_TurnAxisName = "Horizontal" + m_PlayerNumber;
        
    }

    // Update is called once per frame
    void Update ()
    {
        m_MovementInputValue = Input.GetAxis(m_MovementAxisName);
        m_TurnInputValue = Input.GetAxis(m_TurnAxisName);
	}

    private void FixedUpdate()
    {
        //Initializing move and rotate function here

        Move();
        Turn();

    }

    void Move()
    {
        //Take the player input to move the player
        Vector3 movement = transform.forward * m_MovementInputValue * m_Speed * Time.deltaTime;

        m_Rigidbody.MovePosition(m_Rigidbody.position + movement);
        
    }

    void Turn()
    {
        //Take the player input to rotate the player
        float turn = m_TurnInputValue * m_TurnSpeed * Time.deltaTime;

        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);

        m_Rigidbody.MoveRotation(m_Rigidbody.rotation * turnRotation);

    }

}
