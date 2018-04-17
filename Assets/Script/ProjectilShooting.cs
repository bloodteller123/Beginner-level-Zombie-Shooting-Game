using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ProjectilShooting : MonoBehaviour {

    public Transform m_ProjectileTransform;
    public Rigidbody m_Projectile;
    //public float m_ProjectileLaunchingTime = 2f;
    public float m_ProjectileLuanchForce = 100f;
    public float m_LaunchFrequency = 5f;
    public float amount = 8f;
    public Text TAmount;

    private float time;
    private float track;
    
    


	// Use this for initialization
    
	void Start () {
        // m_Projectile = this.GetComponent<Rigidbody>();
        track = amount;
        setText();
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        if (Input.GetKey("k") &&  time > m_LaunchFrequency && track>0f) {
            Rigidbody bomb;
            bomb = Instantiate(m_Projectile, m_ProjectileTransform.position, m_ProjectileTransform.rotation) as Rigidbody;

            bomb.AddForce(m_ProjectileTransform.forward * m_ProjectileLuanchForce);
            time = 0f;
            track--;
        }
        setText();
	}
    void setText()
    {
        TAmount.text = "Grenade : " + track + " / " + amount;
    }
    public float grenadeRemaining()
    {
        return track;
    }
    public void grenadeSupply()
    {
        if ((track + 2) < 8) {
            track = track + 2;
            return;
        }
        else
            track = 8;
        
            
    }
}
