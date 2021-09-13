using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Buttons_Actions : MonoBehaviour
{

    public void backtomain()
    {
        SceneManager.LoadScene(0);
    }

    public void player_player()
    {
        SceneManager.LoadScene(1);
    }

    public void player_com()
    {
        SceneManager.LoadScene(2);
    }

    public void quit()
    {
        Application.Quit();
    }
}
