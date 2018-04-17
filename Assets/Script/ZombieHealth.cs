using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZombieHealth : MonoBehaviour
{
    public float m_StartingHealth = 100;
    public Slider m_Slider;
    public Color m_FullHealth = Color.green;
    public Color m_DeadHealth = Color.red;
    public Image m_FillImage;

    //public GameObject 流血；
    public float m_CurrentHealth;
    //private bool m_Dead;

    public static int count =0;
    private SpawnZombies m_Left;

    private void OnEnable()
    {
        m_CurrentHealth = m_StartingHealth;
        //m_Dead = false;
        SetHealthUI();
    }
    private void SetHealthUI()
    {
        m_Slider.value = m_CurrentHealth;
        m_FillImage.color = Color.Lerp(m_DeadHealth, m_FullHealth, m_CurrentHealth / m_StartingHealth);
    }
    public void TakeDamage(float amount)
    {
        m_CurrentHealth = m_CurrentHealth - amount;
        SetHealthUI();
        if (m_CurrentHealth <= 0)
        {
            Death();
        }
    }
    private void Death()
    {
        //m_Dead = true;
        // gameObject.SetActive(false);

        Destroy(this.gameObject);
        count += 10;
      //  m_Left.ReduceLeft();
    }


    public int GetCount() {
        return count;
    }


}
