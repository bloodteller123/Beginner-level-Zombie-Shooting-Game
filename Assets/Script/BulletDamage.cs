using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour {

    //public Rigidbody Zombie;
    private float damage;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Bullet") {
            // TakeDamage();
            //Debug.Log("DAMAGE");
            ZombieHealth ZombieHealth = this.GetComponent<ZombieHealth>();
            ZombieHealth.TakeDamage(AmountOfDamage());

        }
    }
    private float AmountOfDamage() {
        damage = 20;
        return damage;
    }
}
