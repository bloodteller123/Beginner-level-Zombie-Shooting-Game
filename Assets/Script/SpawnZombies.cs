using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZombies : MonoBehaviour {/// <summary>
/// ///////////////////////////////////////////////////////////////////////////////////////////PROBLEM!!!!!!!!!
/// </summary>PROBLEM!!!!!!!!!PROBLEM!!!!!!!!!PROBLEM!!!!!!!!!PROBLEM!!!!!!!!!PROBLEM!!!!!!!!!PROBLEM!!!!!!!!!PROBLEM!!!!!!!!!PROBLEM!!!!!!!!!PROBLEM!!!!!!!!!PROBLEM!!!!!!!!!PROBLEM!!!!!!!!!PROBLEM!!!!!!!!!


    public float m_SpawnAmount = 10f;
    public float m_SpawnSpeed = 10f;

    public float m_StartWait;
    public float m_Wait = 3; 

    // Use this for initialization
    public GameObject m_Player;
    public GameObject m_ZombiePrefab;
    private Vector3 m_SpawnPosition;
    // Update is called once per frame
 // private EnemyLeft enemyLeft;
    private float left = 0;
    private IEnumerator save;
    private GameObject[] zombies;

    public void Start()
    {
        StartCoroutine("Spawn");
        zombies = GameObject.FindGameObjectsWithTag("Zombie");
    }

    /*
    public SpawnZombies() {
        left = 0;
    }
    */
    private void Update()
    {
        zombies = null;
        zombies = GameObject.FindGameObjectsWithTag("Zombie");
        if (zombies.Length > 3)
        {
            left = 0;
            StopCoroutine("Spawn");
            
        }
        else if (zombies.Length < 2) {
            StartCoroutine("Spawn");
        }
    
    }
   

    IEnumerator  Spawn () {
        //  yield return new WaitForSeconds(m_StartWait);
        while (left < 3)
        {

            yield return new WaitForSeconds(1f);

            m_SpawnPosition = new Vector3(Random.Range(-80, 80), 2, Random.Range(-80, 80));
            


           // Debug.Log(left);
           // Debug.Log(m_Player.activeSelf);
            if (m_Player.activeSelf)
            {
                
                Instantiate(m_ZombiePrefab, m_SpawnPosition, Quaternion.identity);

                left++;
                //Debug.Log(left);
            }

        }
      
    }
    public void ReduceLeft()
    {
        left--;
         
    }
}
