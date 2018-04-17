using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour {


    public Rigidbody m_Shell;
    public Transform m_FireTransform;
    public float m_ShootingSpeed = 100f;
    public float m_ShootingRate = 0.1f;
    public Text BulletText;

    


    private string m_FireButton;
    private bool m_Fired;
    //private float nextFireTime = 0f;
    float timer;
   // Ray shootRay;
    //RaycastHit shootHit;
   // int shootableMask;
   // LineRenderer gunLine;
    Light gunLight;
    float bullets = 100;
    float track;



    private void Awake()
    {
        // gunLine = GetComponent<LineRenderer>();
       // shootableMask = LayerMask.GetMask("Shootable");
        gunLight = this.gameObject.GetComponentInChildren<Light>();

    }
    // Use this for initialization
    void Start () {
        m_FireButton = "j";
        timer = 0f;
        track = bullets;
        setText();
    }
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (Input.GetKeyDown(m_FireButton)) {
            m_Fired = false;
        }
        else if ((Input.GetKeyUp(m_FireButton) || Input.GetKey(m_FireButton)) && !m_Fired && timer>=m_ShootingRate && track>0f)
        {
           // nextFireTime = Time.time + m_ShootingRate;//////////////////
            Fire();
        }
        if (timer >= m_ShootingRate * 0.4f) {
            //Debug.Log("YOOOOO");
            DisableLight();
        }
        setText();

	}

    private void DisableLight() {
        gunLight.enabled = false;
        //Debug.Log("XXXOOOOO");
    }
    private void Fire()
    {
        timer = 0f;
        m_Fired = true;
        gunLight.enabled = true;

        //gunLine.SetPosition(0,this.transform.position);

        //shootRay.origin = this.transform.position;
        //shootRay.direction = this.transform.forward;
        Rigidbody shellInstance = Instantiate(m_Shell, m_FireTransform.position, m_FireTransform.rotation) as Rigidbody;
        shellInstance.velocity = m_ShootingSpeed * m_FireTransform.forward;
        track--;
    }
    void setText()
    {
        BulletText.text = "Bullets: " + track + " / " + bullets;
    }
    public void bulletSupply()
    {
        if ((track + 20) < 100)
        {
            track = track + 20;
            return;
        }
        //else
           // track = 100;

    }
   
}
