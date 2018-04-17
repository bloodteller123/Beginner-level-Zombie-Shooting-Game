using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByTime : MonoBehaviour {
    public float m_LifeTime;
	// Use this for initialization
	void Start () {
        Destroy(gameObject, m_LifeTime);
	}
	

}
