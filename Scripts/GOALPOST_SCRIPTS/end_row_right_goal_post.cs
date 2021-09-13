using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class end_row_right_goal_post : MonoBehaviour
{
    public Rigidbody RB;
    public float x,y,z;

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
            y = y * -(y/2);
                 StartCoroutine(delay());
        }
    }


    IEnumerator delay()
    {
        yield return new WaitForSeconds(1f);
        x = 0;
        y = 0;
        z = 0;    }


}
