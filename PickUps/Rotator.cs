using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 50f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

   
    void Update()
    {
        rb.transform.Rotate(0, 0, 1*Time.deltaTime*speed);
       
    }
}
