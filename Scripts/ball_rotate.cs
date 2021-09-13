using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball_rotate : MonoBehaviour
{

    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.transform.Rotate(1f,2f,1f);
    }
}
