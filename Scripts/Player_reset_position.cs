using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player_reset_position : MonoBehaviour
{
    Vector3 originalPos;
    public GameObject[] football;
    public int index_football = 0;
    private Scene scenee;

    // Start is called before the first frame update
    void Awake()
    {
        scenee = SceneManager.GetActiveScene();
        //football[1].SetActive(false);
        originalPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
    }

    // Update is called once per frame

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "football")
        {
            StartCoroutine(delay());

        }
    }

    IEnumerator delay()
    {
        yield return new WaitForSeconds(4f);
        gameObject.transform.position = originalPos;
        //gameObject.transform.rotation = new Vector3(0f,40f,0f);
        transform.rotation = Quaternion.identity;
        transform.Rotate(0f,40f,0f);
        if(index_football < 9)
        {
             //Application.LoadLevel(scenee.name);
                         SceneManager.LoadScene(scenee.name);

        // football[index_football].SetActive(false);
        // Destroy(football[index_football]);
        // index_football +=1;
        // football[index_football].SetActive(true);
        }
        //transform.rotate = new Vector3(0f,40f,0f);
    }
}
