using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

    public float m_ExplosionRadius = 5f;
    public float m_ExplosionForce = 6000f;
    public float m_Damage = 20f;

   
    bool explosion = false;
    private float time;

    private void Start()
    {
        time = 0f;
    }
    // Use this for initialization
    private void OnCollisionEnter()
    {
        explosion = true;
    }

    // Update is called once per frame
    void  Update () {
        time += Time.deltaTime;
        if(explosion && time>=1f)
        {
            Explode(time);
            explosion = false;
        }
	}
    void Explode(float time) {
      //  Debug.Log("TEST");
        
        time += Time.deltaTime;
        if (explosion == true)
        {
            Collider[] HitZombies = Physics.OverlapSphere(transform.position, m_ExplosionRadius);
            Debug.Log(HitZombies.Length);
            foreach (Collider nearBy in HitZombies)  
            {
               // Debug.Log("有炸dao");
                //Debug.Log(HitZombies[i].GetComponent<ZombieHealth>() != null );

                if (nearBy.GetComponent<ZombieHealth>() != null)
                {
                   // Debug.Log("看一下先？  ");
                    nearBy.GetComponent<ZombieHealth>().TakeDamage(m_Damage);

                    if (nearBy.GetComponent<Rigidbody>() != null)
                    {
                        nearBy.GetComponent<Rigidbody>().AddExplosionForce(m_ExplosionForce, transform.position, m_ExplosionRadius);
                        //HitZombies[i].GetComponent<Rigidbody>().AddExplosionForce(m_ExplosionForce, this.transform.position, m_ExplosionRadius);
                        //Debug.Log("这个是吗？  ");/////////////////Doesnt work anyways
                        //HitZombies[i].GetComponent<Rigidbody>().AddForce(m_ExplosionForce * transform.forward);

                    }
                     
                }
               
            }
           // this.gameObject.SetActive(false);
            Destroy(this.gameObject);
           // explosion = false;
        }
        else
        {
            if (time >= 3f)
                //this.gameObject.SetActive(false);
                Destroy(this.gameObject);
        }
        
    }
}
