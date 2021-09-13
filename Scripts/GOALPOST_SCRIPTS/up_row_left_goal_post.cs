using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class up_row_left_goal_post : MonoBehaviour
{
    public Rigidbody RB;
    public float x,y,z,w;

    void Start()
    {
        RB.GetComponent<Rigidbody>();
    }

    void Update()
    {
        RB.AddForce(x,y,z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "collider")
        {
            y = -260;
            StartCoroutine(delay());
        }
    }


    IEnumerator delay()
    {
        yield return new WaitForSeconds(1f);
        RB.velocity = Vector3.zero; 
        x = 0f;
        y = 0f;
        z = 0f; 
    }
}
