using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour {

    Light flashLight;
    private void Start()
    {
        flashLight = GetComponent<Light>();
    }    

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown("q")) {
            if (flashLight.enabled == true)
            {
                flashLight.enabled = false;
            }
            else {
                flashLight.enabled = true;
            }
        }

	}
}
