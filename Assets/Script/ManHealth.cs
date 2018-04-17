using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManHealth : MonoBehaviour {
    public float m_StartingHealth = 100;
    public Slider m_Slider;
    public Color m_FullHealth = Color.green;
    public Color m_DeadHealth = Color.red;
    public Image m_FillImage;

    //public GameObject 流血；
    private float m_CurrentHealth;
   // private bool m_Dead;


    private void OnEnable()
    {
        m_CurrentHealth = m_StartingHealth;
        //m_Dead = false;
        SetHealthUI();
    }


    // Use this for initialization
    void Start () {
       

	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void SetHealthUI() {
        m_Slider.value = m_CurrentHealth;
        m_FillImage.color = Color.Lerp(m_DeadHealth,m_FullHealth, m_CurrentHealth / m_StartingHealth);
    }
    public void TakeDamage(float amount) {
        m_CurrentHealth = m_CurrentHealth - amount;
        SetHealthUI();
        if (m_CurrentHealth <= 0) {
            Death();
        }
    }
    private void Death() {
       // m_Dead = true;
        gameObject.SetActive(false);
    }


}
