using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiMoving : MonoBehaviour {

    Transform m_Player;
    public float m_EnemyAttackDistance;
    public float m_EnemyMoveSpeed;
    public float m_AttackFrequency = 2f;
    Rigidbody m_Man;
    GameObject m_People;
    public float m_EnemyForce = 30f;

    Vector3 wayPoint;

    ZombieHealth health;
    private  float m_ToTargetDistance;
    private Rigidbody m_Enemy;
    private Renderer m_Renderer;
    private float timer;
    /////////private WaitForSeconds m_AttackFrequency;
    bool m_IsTouched;
    bool m_IsInRange;
    int Ran = 5;
    // private NavMeshAgent agent;
   
    void Awake()
    {
        // Set up the references.
        m_Player = GameObject.FindGameObjectWithTag("Center").transform;
        m_Man = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
        m_People = GameObject.FindGameObjectWithTag("Player");
        health = this.GetComponent<ZombieHealth>();
    }
    // Use this for initialization
    void Start () {
        m_Enemy = GetComponent<Rigidbody>();
        m_Renderer = GetComponent<Renderer>();
        m_Man = GetComponent<Rigidbody>();

         
        m_IsInRange = false;
        //Move();///////////////////////////////////////

        

     //   agent = GetComponent<NavMeshAgent>();


    }
    private void Update()
    {
        transform.position += transform.TransformDirection(Vector3.forward) * m_EnemyMoveSpeed * Time.deltaTime;
        if ((transform.position - wayPoint).magnitude > m_EnemyAttackDistance) {
            m_IsInRange = false;
            Move();
        }
    }


    // Update is called once per frame


    void FixedUpdate () {
        timer += Time.deltaTime;
        m_ToTargetDistance = Vector3.Distance(transform.position, m_Player.position);
        if (m_ToTargetDistance <= m_EnemyAttackDistance)
        {
            m_Renderer.material.color = Color.red;
            LookAtTarget();
            m_IsInRange = true;
            Move();
            //Attack();
        }
        else {
            //Debug.Log("walk around");
            m_Renderer.material.color = Color.yellow;

        }
	}
    void LookAtTarget()
    {
        Quaternion Rotation = Quaternion.LookRotation(m_Player.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation,Rotation,Time.deltaTime*10);

    }

    void Move()
    {
        if (m_IsInRange)
        {
            Vector3 move = transform.forward * m_EnemyMoveSpeed * Time.deltaTime;
            m_Enemy.MovePosition(m_Enemy.position + move);
        }
        else
        {
            wayPoint = new Vector3(Random.Range(transform.position.x - Ran, transform.position.x + Ran), -1.374432f, Random.Range(transform.position.z - Ran, transform.position.z + Ran));
            wayPoint.y = -1.374432f;
            transform.LookAt(wayPoint);

        }

    }
    //void Attack()
    // {
    //   m_Man.AddForce(transform.forward*m_EnemyForce);
    //}


    void Attack() {

        if (timer >= m_AttackFrequency && health.m_CurrentHealth > 0 && m_IsTouched)
        {
            m_Man.AddForce(m_Man.transform.position* m_EnemyForce);
            ManHealth manHealth = m_People.GetComponent<ManHealth>();
            manHealth.TakeDamage(10);
            timer = 0f;
            //m_IsTouched = false;
           // Debug.Log("!!!!!");
        }
    }


    private void OnTriggerEnter(Collider player)
    {
        
        if (player.gameObject.CompareTag("Player"))
        {
           // Debug.Log("碰到");
            m_IsTouched = true;
            /*
            if (timer>=m_AttackFrequency && health.m_CurrentHealth > 0) {
                m_Man.AddForce(transform.forward * m_EnemyForce);
                ManHealth manHealth = m_People.GetComponent<ManHealth>();
                manHealth.TakeDamage(10);
            }
            */
            Attack();
        }
        
        
        if (player.gameObject.CompareTag("Bullet")) {
            Destroy(player.gameObject);
        }
    }
    private void OnTriggerExit(Collider player)
    {
        //Debug.Log("没碰到");
        if (player.gameObject.CompareTag("Player")) {
            m_IsTouched = false;
        }
    }

}
