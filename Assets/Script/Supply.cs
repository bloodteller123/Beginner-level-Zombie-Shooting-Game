using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[Serializable]
public class Supply : MonoBehaviour , ISupplyInterface
{
    
    public void rotate()
    {
        transform.Rotate(new Vector3(15, 30, 15) * Time.deltaTime);
    }
    public bool IsActive()
    {
        if (this.gameObject.activeSelf)
        {
            return true;
        }

        //putSupply();
        return false;
    }
    public void putSupply()
    {

            //Instantiate(this);
           this.gameObject.SetActive(true);
        
    }

    public string supplyType(string[] supply,int num)
    {

        //return randomSupply[num];
        //Debug.Log(n);
        return supply[num];
    }
    
}
