using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mid_row_mid_goal_post : MonoBehaviour
{
    public Rigidbody RB;
    public float x,y,z,w;
   // public TextMeshPro textmeshPro;

    private void Awake()
    {
        //textmeshPro = GetComponent<TextMeshPro>();
        //textmeshPro.enabled = false;
    }

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
            y = y * -(y/w);

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
