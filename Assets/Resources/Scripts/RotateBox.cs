using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBox : MonoBehaviour
{
    public float spinForce;

    //0 == false; 1 == true
    private int focused = 0; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, spinForce * Time.deltaTime * focused , 0);
    }

    public void StartSpin(){
        focused = 1;
	}

    public void StopSpin(){
        focused = 0;
	}
}
