using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour {

    public GameObject m_Instance;
    public GameObject m_Zombie;
    public Text m_Message;
    public Text m_MessageCount;


    public float m_StartDelay = 3f;
    public float m_EndDelay = 3f;
    public Transform supplyTransform;
    public GameObject supplyPrefab;
    public Camera camera;

    


    private WaitForSeconds start;
    private WaitForSeconds end;

    private Shooting m_Shooting;
    private PlayerMovement m_PlayerMovement;
    private AiMoving m_AiMovement;
    private Canvas m_CanvasUi;
    private ZombieHealth m_ZombieHealth;
    private SpawnZombies m_Spawn;
    private Supply m_Supply;
    private ProjectilShooting m_Grenade;
    //int count = 0;
    int num = 0;
    string[] randomSupply;
    //private ManSpawn m_Man;
    //private int count;
    //private SpawnZombies  m_Sapwn;


    // Use this for initialization
    void Start() {
        // m_Spawn = new SpawnZombies();
        m_Shooting = m_Instance.GetComponent<Shooting>();
        m_PlayerMovement = m_Instance.GetComponent<PlayerMovement>();
        m_Grenade = m_Instance.GetComponent<ProjectilShooting>();
         

        m_AiMovement = m_Zombie.GetComponent<AiMoving>();/////////////////////////////////
        m_CanvasUi = m_Instance.GetComponentInChildren<Canvas>();/////////////////////////////
        m_ZombieHealth = m_Zombie.GetComponent<ZombieHealth>();////////////////////////////////
        m_Supply = supplyPrefab.GetComponent<Supply>();

       // m_Spawn = m_Zombie.GetComponent<SpawnZombies>();
        // this.GetComponent<ManSpawn>().enabled = true;

        start = new WaitForSeconds(m_StartDelay);
        end = new WaitForSeconds(m_EndDelay);
        //count = m_ZombieHealth.GetCount();//////////////////////////////////////
        randomSupply = new string[] { "Grenade", "Bullets" };

       // InvokeRepeating()
        DisEnableContorl();
        SetCountText();
        StartCoroutine(Game());
        
    }

    // Update is called once per frame
    void Update() {
       // count = m_ZombieHealth.GetCount();//////////////////////////////////////
        SetCountText();
        m_Supply.rotate();

    }

    IEnumerator supply()
    {
        //if (!m_Supply.IsActive())
        //{
        //Debug.Log(m_Grenade.grenadeRemaining());
         num = Random.Range(0, 1);
        //string type = m_Supply.supplyType(randomSupply, num);
        string type = m_Supply.supplyType(randomSupply, num);
        //Debug.Log(type);
        if (type.Equals("Grenade"))
            {
                m_Grenade.grenadeSupply();
               // yield return new WaitForSeconds(10f);
               // m_Supply.putSupply();
             }
        else if (type.Equals("Bullets"))
            {
            //Debug.Log(num);
            // m_Grenade.grenadeSupply();
            // yield return new WaitForSeconds(10f);
            //m_Supply.putSupply();
                m_Shooting.bulletSupply();
            }
        yield return new WaitForSeconds(10f);
        m_Supply.putSupply();

        //}
    }
    private IEnumerator Game()
    {
        //start the game
        yield return StartCoroutine(GameStart());
        //game ongoing
        yield return StartCoroutine(GamePlaying());
        //game ending
        yield return StartCoroutine(GameEnding());
        //EnableContorl();
        // yield return StartCoroutine(GamePlaying());
        // Debug.Log("结束结束结束结束结束");
        SceneManager.LoadScene(2);

    }

    private void EnableContorl() {
        m_Shooting.enabled = true;
        m_PlayerMovement.enabled = true;
        m_AiMovement.enabled = true;

        m_CanvasUi.gameObject.SetActive(true);
    }
    private void DisEnableContorl()
    {
        m_Shooting.enabled = false;
        m_PlayerMovement.enabled = false;
       // m_AiMovement.enabled = false;

        m_CanvasUi.gameObject.SetActive(false);
    }

    private void SetCountText() {
        
        m_MessageCount.text = "Score : " + ZombieHealth .count.ToString();
    }
    
    private IEnumerator GameStart() { 
        //DisEnableContorl();
        
        yield return start;
        m_Message.text = string.Empty;
     
        EnableContorl();
    }

    
    private IEnumerator GamePlaying() {
       
        while (m_Instance.activeSelf) {
            // Debug.Log("玩玩玩玩");
            //Debug.Log(m_Supply.IsActive());
            //Debug.Log(m_Grenade.grenadeRemaining());
            if (!m_Supply.IsActive())
                StartCoroutine(supply());
            yield return null;
          }
        camera.enabled = false;

    }
    private IEnumerator GameEnding()
    {
        

        yield return new WaitForSeconds(2f);
        m_Message.text = "your score is: " + m_ZombieHealth.GetCount();
        yield return new WaitForSeconds(3f);
    }

}
