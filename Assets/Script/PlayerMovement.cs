using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {


    public float m_Speed = 10f;
    public float m_TurnSpeed = 12f;
    // public Rigidbody m_Player;
    public float m_JumpSpeed = 1f;
    //public GameObject Walls;



  //  private string m_MovementAxisName;
   // private string m_TurnAxisName;
    private Rigidbody m_Rigidbody;
    private float moveHorizontal;
    private float moveVertical;
    private float jump;

    private bool isGounded;

    void Start () {
        m_Rigidbody = GetComponent<Rigidbody>();
        //Walls = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        moveHorizontal = Input.GetAxis("Horizontal"); //* Time.deltaTime * m_speed;
        moveVertical = Input.GetAxis("Vertical");//* Time.deltaTime * m_turnSpeed;
                                                 // Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
                                                 // m_Rigidbody.AddForce(movement * m_speed);
        jump = Input.GetAxis("Jump");
        

        
    }
    private void FixedUpdate()
    {
        Move();
        Turn();
        Jump();
    }
    private void Move()
    {
        Vector3 movement = transform.forward * moveVertical * m_Speed * Time.deltaTime;/////////////////////////////
        m_Rigidbody.MovePosition(m_Rigidbody.position + movement);
        //isGounded = true;
    }
    private void Turn()
    {
        float turn = moveHorizontal * m_TurnSpeed * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        m_Rigidbody.MoveRotation(m_Rigidbody.rotation * turnRotation);
    }

    private void Jump()
    {
        // Vector3 jump = new Vector3();

        //transform.position += transform.up * m_JumpSpeed *Time.deltaTime;
            Vector3 Jump = transform.up * jump * m_JumpSpeed * Time.deltaTime;
            m_Rigidbody.MovePosition(m_Rigidbody.position + Jump);

        if (m_Rigidbody.position.y > 4)
        {

            // ebug.Log(m_Rigidbody.position.y);
            m_Rigidbody.AddForce(Vector3.down * 100);
        }
            
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            //Debug.Log("Hit Walls");
           // m_Rigidbody.rotation = Quaternion.identity;
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
        }
    }

}
