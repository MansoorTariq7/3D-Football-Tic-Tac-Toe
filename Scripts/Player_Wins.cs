using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player_Wins : MonoBehaviour
{
    int index_turn;
    public GameObject[] player_text;
    public Animator myanim;



    // Start is called before the first frame update
    void Start()
    {
        //myanim = GetComponent<Animator>();

        player_text[0].SetActive(false);
        player_text[1].SetActive(false);
        player_text[2].SetActive(false);

        index_turn = PlayerPrefs.GetInt("index_turn", 0);
        player_text[index_turn].SetActive(true);

        int rande = Random.Range(0,3);
        Debug.Log(rande);
        if(rande == 3)
        {
            myanim.SetBool("hiphop",true);
 
        }
        else if(rande == 2)
        {
            myanim.SetBool("break",true);

        }
        else if(rande == 1)
        {
            myanim.SetBool("flip",true);

        }
        else
        {
            myanim.SetBool("dance",true);

        }

        PlayerPrefs.DeleteAll();


    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
