using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ball_move_com : MonoBehaviour
{
    // MATRIX
    public int one,two,three,four,five,six,seven,eight,nine = 0;
    // 1 for player-1 ,,, 2 for player 2

    // Player-Animation
    public Animator myanim;


    // TESH MASH PRO TEST PLAYER - ONE
    public GameObject[] Player_One_Text;
    public int[] Player_One_Text_index;
    public int index; 

    // TESH MASH PRO TEST PLAYER - ONE
    public GameObject[] Player_Two_Text;
    public int[] Player_Two_Text_index;

    // Player-One turn or Player-Two
    public GameObject[] Turn;
    int index_turn;
    int index_turn_check = 0;

    // LAST GOAL POST
    public GameObject script_end_row_mid_goal_post;
    private bool script_end_row_mid_goal_post_set = false;

    public GameObject script_end_row_left_goal_post;
    private bool script_end_row_left_goal_post_set = false;

    public GameObject script_end_row_right_goal_post;
    private bool script_end_row_right_goal_post_set = false;

    // MID GOAL POST
    public GameObject script_mid_row_left_goal_post;
    private bool script_mid_row_left_goal_post_set = false;

    public GameObject script_mid_row_mid_goal_post;
    private bool script_mid_row_mid_goal_post_set = false;

    public GameObject script_mid_row_right_goal_post;
    private bool script_mid_row_right_goal_post_set = false;

    // UP GOAL POST
    public GameObject script_up_row_left_goal_post;
    private bool script_up_row_left_goal_post_set = false;

    public GameObject script_up_row_mid_goal_post;
    private bool script_up_row_mid_goal_post_set = false;

    public GameObject script_up_row_right_goal_post;
    private bool script_up_row_right_goal_post_set = false;

    public Rigidbody RB;

    Vector3 originalPos;

    public bool condition_com = false;

    private void Awake() 
    {
        RB = GetComponent<Rigidbody>(); 
        
        //PlayerPrefs.DeleteAll();

        // LAST 
        script_end_row_mid_goal_post.GetComponent<end_row_mid_goal_post>().enabled = false;
        script_end_row_left_goal_post.GetComponent<end_row_left_goal_post>().enabled = false;
        script_end_row_right_goal_post.GetComponent<end_row_right_goal_post>().enabled = false;
        // MID
        script_mid_row_mid_goal_post.GetComponent<mid_row_mid_goal_post>().enabled = false;
        script_mid_row_left_goal_post.GetComponent<mid_row_left_goal_post>().enabled = false;
        script_mid_row_right_goal_post.GetComponent<mid_row_right_goal_post>().enabled = false;
        // UP
       script_up_row_mid_goal_post.GetComponent<up_row_mid_goal_post>().enabled = false;
       script_up_row_left_goal_post.GetComponent<up_row_left_goal_post>().enabled = false;
       script_up_row_right_goal_post.GetComponent<up_row_right_goal_post>().enabled = false;

        // GETTING-PLAYER-ONE-PREF-TEXT
        Player_One_Text_index[0] = PlayerPrefs.GetInt("player_one_zero_index", -1);
        Player_One_Text_index[1] = PlayerPrefs.GetInt("player_one_one_index", -1);
        Player_One_Text_index[2] = PlayerPrefs.GetInt("player_one_two_index", -1);
        Player_One_Text_index[3] = PlayerPrefs.GetInt("player_one_three_index", -1);
        Player_One_Text_index[4] = PlayerPrefs.GetInt("player_one_four_index", -1);
        Player_One_Text_index[5] = PlayerPrefs.GetInt("player_one_five_index", -1);
        Player_One_Text_index[6] = PlayerPrefs.GetInt("player_one_six_index", -1);
        Player_One_Text_index[7] = PlayerPrefs.GetInt("player_one_seven_index", -1);
        Player_One_Text_index[8] = PlayerPrefs.GetInt("player_one_eight_index", -1);
        
        // GETTING-PLAYER-TWO-PREF-TEXT
        Player_Two_Text_index[0] = PlayerPrefs.GetInt("player_two_zero_index", -1);
        Player_Two_Text_index[1] = PlayerPrefs.GetInt("player_two_one_index", -1);
        Player_Two_Text_index[2] = PlayerPrefs.GetInt("player_two_two_index", -1);
        Player_Two_Text_index[3] = PlayerPrefs.GetInt("player_two_three_index", -1);
        Player_Two_Text_index[4] = PlayerPrefs.GetInt("player_two_four_index", -1);
        Player_Two_Text_index[5] = PlayerPrefs.GetInt("player_two_five_index", -1);
        Player_Two_Text_index[6] = PlayerPrefs.GetInt("player_two_six_index", -1);
        Player_Two_Text_index[7] = PlayerPrefs.GetInt("player_two_seven_index", -1);
        Player_Two_Text_index[8] = PlayerPrefs.GetInt("player_two_eight_index", -1);  

        // SETTING-INDEX
        index = PlayerPrefs.GetInt("INDEX_GOAL_TEXT", 0);   

        // saving ONE - EIGHT 
        one = PlayerPrefs.GetInt("one", 0);
        two = PlayerPrefs.GetInt("two", 0);
        three = PlayerPrefs.GetInt("three", 0);
        four = PlayerPrefs.GetInt("four", 0);
        five = PlayerPrefs.GetInt("five", 0);
        six = PlayerPrefs.GetInt("six", 0);
        seven = PlayerPrefs.GetInt("seven", 0);
        eight = PlayerPrefs.GetInt("eight", 0);
        nine = PlayerPrefs.GetInt("nine", 0); 

    
        // getting turn index
        index_turn = PlayerPrefs.GetInt("index_turn", 0); 
            Debug.Log("hello->"+index_turn_check+" and "+index_turn);


        if(index_turn == 0)
        {
            index_turn_check = 0;
            Turn[1].SetActive(false);
            Turn[0].SetActive(true);
            //index_turn = 1;
            //PlayerPrefs.SetInt("index_turn", index_turn); 
        }
        if(index_turn == 1)
        {
            //Debug.Log("hello->"+index_turn_check+" and "+index_turn);
            index_turn_check = 1;
            Turn[0].SetActive(false);
            Turn[1].SetActive(true);
            computer_turn();
            //index_turn = 0;
            //PlayerPrefs.SetInt("index_turn", index_turn);
            //condition_com = true; 
        }
        
        

        // getting original position
        originalPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        
        
        // Disable All GOAL!! text
        for(int k = 0 ; k < 9;k++)
        {
            bool Condition_Player_One = false;
            bool Condition_Player_Two = false;

            for(int j = 0; j <  9; j++)
            {
                if(k == Player_One_Text_index[j])
                {
                    Condition_Player_One = true;
                }
                if (k == Player_Two_Text_index[j])
                {
                    Condition_Player_Two = true;
                }
            }
            if(Condition_Player_One == false)
            {
                Player_One_Text[k].SetActive(false);
            }
            if(Condition_Player_Two == false)
            {
                Player_Two_Text[k].SetActive(false);
            }
        }


    }

    void start()
    {
        myanim = GetComponent<Animator>();
    }


    void Check_All_Conditons()
    {
        // one conditions (3)
        check_one_conditions();
        // two conditions (1)
        check_two_conditions();
        // three conditions (2)
        check_three_conditions();
        // four conditions (1)
        check_four_conditions();
        
        // five condition (0)
        // six condition (0)

        // seven condition (1)
        check_seven_conditions();

        if(one != 0 && two != 0 && three != 0 && four != 0 && five != 0 && six != 0 && seven != 0 && eight != 0 && nine != 0)
        {
            // DRAW
            index_turn = 2;
            PlayerPrefs.SetInt("index_turn", index_turn);
            StartCoroutine(wait());
            SceneManager.LoadScene(3);
        }
        // if(condition_com == true && index_turn_check == 1)
        // {
        //     Debug.Log("chal raha ha  "+ condition_com);
        //     condition_com = false;
        // }

    }

    void check_one_conditions()
    {
        // condition 1.1
        if(one == 1 && two == 1 && three == 1)
        {
            // player one win
            Debug.Log("player one win");
            index_turn = 0;
            PlayerPrefs.SetInt("index_turn", index_turn);
            SceneManager.LoadScene(3);
 
        }
        if(one == 2 && two == 2 && three == 2)
        {
            // player two win
            Debug.Log("player two win");
            index_turn = 1;
            PlayerPrefs.SetInt("index_turn", index_turn);
            SceneManager.LoadScene(3);

 
        }

        // condition 1.2
        if(one == 1 && four == 1 && seven == 1)
        {
            // player one win
            Debug.Log("player one win");
            index_turn = 0;
            PlayerPrefs.SetInt("index_turn", index_turn);
            SceneManager.LoadScene(3);
            
 
        }
        if(one == 2 && four == 2 && seven == 2)
        {
            // player two win
            Debug.Log("player two win");
            index_turn = 2;
            PlayerPrefs.SetInt("index_turn", index_turn); 
            SceneManager.LoadScene(3);
        }

        // condition 1.3
        if(one == 1 && five == 1 && nine == 1)
        {
            // player one win
            Debug.Log("player one win");
            index_turn = 0;
            PlayerPrefs.SetInt("index_turn", index_turn); 
            SceneManager.LoadScene(3);
        }
        if(one == 2 && five == 2 && nine == 2)
        {
            // player two win
            Debug.Log("player two win");
            index_turn = 1;
            PlayerPrefs.SetInt("index_turn", index_turn); 
            SceneManager.LoadScene(3);

        }
    }
    void check_two_conditions()
    {
        // condition 2.1
        if(two == 1 && five == 1 && eight == 1)
        {
            // player one win
            Debug.Log("player one win");
            index_turn = 0;
            PlayerPrefs.SetInt("index_turn", index_turn); 
            SceneManager.LoadScene(3);

        }
        if(two == 2 && five == 2 && eight == 2)
        {
            // player two win
            Debug.Log("player two win");
            index_turn = 1;
            PlayerPrefs.SetInt("index_turn", index_turn);
            SceneManager.LoadScene(3);

        }
    
    }
    void check_three_conditions()
    {
        // condition 3.1
        if(three == 1 && five == 1 && seven == 1)
        {
            // player one win
            Debug.Log("player one win");
            index_turn = 0;
            PlayerPrefs.SetInt("index_turn", index_turn);
            SceneManager.LoadScene(3);

        }
        if(three == 2 && five == 2 && seven == 2)
        {
            // player two win
            Debug.Log("player two win");
            index_turn = 1;
            PlayerPrefs.SetInt("index_turn", index_turn); 
            SceneManager.LoadScene(3);

        }

        // condition 3.2
        if(three == 1 && six == 1 && nine == 1)
        {
            // player one win
            Debug.Log("player one win");
            index_turn = 0;
            PlayerPrefs.SetInt("index_turn", index_turn); 
            SceneManager.LoadScene(3);


        }
        if(three == 2 && six == 2 && nine == 2)
        {
            // player two win
            Debug.Log("player two win");
            index_turn = 1;
            PlayerPrefs.SetInt("index_turn", index_turn); 
            SceneManager.LoadScene(3);


        }

    
    }
    void check_four_conditions()
    {
       // condition 4.1
        if(four == 1 && five == 1 && six == 1)
        {
            // player one win
            Debug.Log("player one win");
            index_turn = 0;
            PlayerPrefs.SetInt("index_turn", index_turn);
            SceneManager.LoadScene(3);

        }
        if(four == 2 && five == 2 && six == 2)
        {
            // player two win
            Debug.Log("player two win");
            index_turn = 1;
            PlayerPrefs.SetInt("index_turn", index_turn); 
            SceneManager.LoadScene(3);

        } 
    }
    void check_seven_conditions()
    {
       // condition 4.1
        if(seven == 1 && eight == 1 && nine == 1)
        {
            // player one win
            Debug.Log("player one win");
            index_turn = 0;
            PlayerPrefs.SetInt("index_turn", index_turn); 
            SceneManager.LoadScene(3);

        }
        if(seven == 2 && eight == 2 && nine == 2)
        {
            // player two win
            Debug.Log("player two win");
            index_turn = 1;
            PlayerPrefs.SetInt("index_turn", index_turn); 
            SceneManager.LoadScene(3);

        } 
    }

    // void check_one_conditions()
    // {
    //     // condition 1.1
    //     if(one == 1 && two == 1 && three == 1)
    //     {
    //         // player one win
    //         Debug.Log("player one win");
    //     }
    //     if(one == 2 && two == 2 && three == 2)
    //     {
    //         // player two win
    //         Debug.Log("player two win");
    //     }

    //     // condition 1.2
    //     if(one == 1 && four == 1 && seven == 1)
    //     {
    //         // player one win
    //         Debug.Log("player one win");
    //     }
    //     if(one == 2 && four == 2 && seven == 2)
    //     {
    //         // player two win
    //         Debug.Log("player two win");
    //     }

    //     // condition 1.3
    //     if(one == 1 && five == 1 && nine == 1)
    //     {
    //         // player one win
    //         Debug.Log("player one win");

    //     }
    //     if(one == 2 && five == 2 && nine == 2)
    //     {
    //         // player two win
    //         Debug.Log("player two win");
    //     }
    // }
    // void check_two_conditions()
    // {
    //     // condition 2.1
    //     if(two == 1 && five == 1 && eight == 1)
    //     {
    //         // player one win
    //         Debug.Log("player one win");
    //     }
    //     if(two == 2 && five == 2 && eight == 2)
    //     {
    //         // player two win
    //         Debug.Log("player two win");
    //     }

    
    // }
    // void check_three_conditions()
    // {
    //     // condition 3.1
    //     if(three == 1 && five == 1 && seven == 1)
    //     {
    //         // player one win
    //         Debug.Log("player one win");
    //     }
    //     if(three == 2 && five == 2 && seven == 2)
    //     {
    //         // player two win
    //         Debug.Log("player two win");
    //     }

    //     // condition 3.2
    //     if(three == 1 && six == 1 && nine == 1)
    //     {
    //         // player one win
    //         Debug.Log("player one win");
    //     }
    //     if(three == 2 && six == 2 && nine == 2)
    //     {
    //         // player two win
    //         Debug.Log("player two win");
    //     }

    
    // }
    // void check_four_conditions()
    // {
    //    // condition 4.1
    //     if(four == 1 && five == 1 && six == 1)
    //     {
    //         // player one win
    //         Debug.Log("player one win");
    //     }
    //     if(four == 2 && five == 2 && six == 2)
    //     {
    //         // player two win
    //         Debug.Log("player two win");
    //     } 
    // }
    // void check_seven_conditions()
    // {
    //    // condition 5.1
    //     if(seven == 1 && eight == 1 && nine == 1)
    //     {
    //         // player one win
    //         Debug.Log("player one win");
    //     }
    //     if(seven == 2 && eight == 2 && nine == 2)
    //     {
    //         // player two win
    //         Debug.Log("player two win");
    //     } 
    // }


    // computer turn
    void computer_turn()
    {
        if(computer_winning_conditions() == true)
        {
            if(computer_conditions() == true)
            {
                if(one != 1 && one != 2)
                {
                    Button___script_up_row_left_goal_post();
                }
                else if(two != 1 && two != 2)
                {
                    Button___script_up_row_mid_goal_post();
                }
                else if(three != 1 && three != 2)
                {
                    Button___script_up_row_right_goal_post();
                }
                else if(four != 1 && four != 2)
                {
                    Button___script_mid_row_left_goal_post();
                }
                else if(five != 1 && five != 2)
                {
                    Button___script_mid_row_mid_goal_post();
                }
                else if(six != 1 && six != 2)
                {
                    Button___script_mid_row_right_goal_post();
                }
                else if(seven != 1 && seven != 2)
                {
                    Button___script_end_row_left_goal_post();
                }
                else if(eight != 1 && eight != 2)
                {
                    Button___script_end_row_mid_goal_post();
                }
                else if(nine != 1 && nine != 2)
                {
                    Button___script_end_row_right_goal_post();
                }
            }
        }
    }

    // void computer conditions check
    bool computer_conditions()
    {
        Debug.Log("nice");
        // condition 1.1
        if(one == 1 && two == 1 && three != 2)
        {
            Button___script_up_row_right_goal_post();
            return false;
        }
        if(two == 1 && three == 1 && one != 2)
        {
            Button___script_up_row_left_goal_post();
                        return false;

        }
        if(three == 1 && one == 1 && two != 2)
        {
            Button___script_up_row_mid_goal_post();
                        return false;

        }

        // condition 1.2
        if(one == 1 && four == 1 && seven != 2)
        {
           Button___script_end_row_left_goal_post();
                       return false;

        }
        if(four == 1 && seven == 1 && one != 2)
        {
           Button___script_up_row_left_goal_post(); 
                       return false;

        }
        if( seven == 1 && one == 1 && four != 2)
        {
           Button___script_mid_row_left_goal_post(); 
                       return false;

        }


        // condition 1.3
        if(one == 1 && five == 1 && nine != 2)
        {
           Button___script_end_row_right_goal_post();
                       return false;


        }
        if(five == 1 && nine == 1 && one != 2)
        {
          Button___script_up_row_left_goal_post();
                      return false;

        }
        if(five != 2 && nine == 1 && one == 1)
        {
          Button___script_mid_row_mid_goal_post();
                      return false;

        }

        //-----------

        // condition 2.1
        if(two == 1 && five == 1 && eight != 2)
        {
            Button___script_end_row_mid_goal_post();
                        return false;

        }
        if(five == 1 && eight == 1 && two != 2)
        {
            Button___script_up_row_mid_goal_post();
                        return false;

        }
        if(five != 2 && eight == 1 && two == 1)
        {
            Button___script_mid_row_mid_goal_post();
                        return false;

        }
        //--------

        // condition 3.1
        if(three == 1 && five == 1 && seven != 2)
        {
            Button___script_end_row_left_goal_post();
                        return false;

        }
        if( five == 1 && seven == 1 && three != 2)
        {
            Button___script_up_row_right_goal_post();
                        return false;

        }
        if( five != 2 && seven == 1 && three == 1)
        {
            Button___script_mid_row_mid_goal_post();
                        return false;

        }

        // condition 3.2
        if(three == 1 && six == 1 && nine != 2)
        {
            Button___script_end_row_right_goal_post();
                        return false;

        }
        if(six == 1 && nine == 1 && three != 2)
        {
           Button___script_up_row_right_goal_post();
                       return false;

        }
        if(six != 2 && nine == 1 && three == 1)
        {
           Button___script_mid_row_right_goal_post();
                       return false;

        }

        // ---------------

        // condition 4.1
        if(four == 1 && five == 1 && six != 2)
        {
            Button___script_mid_row_right_goal_post();
                        return false;

        }
        if(five == 1 && six == 1 && four != 2)
        {
            Button___script_mid_row_left_goal_post();
                        return false;

        } 
        if(five != 2 && six == 1 && four == 1)
        {
            Button___script_mid_row_mid_goal_post();
                        return false;

        } 

        //---------

        // condition 5.1
        if(seven == 1 && eight == 1 && nine != 2)
        {
            Button___script_end_row_right_goal_post();
                        return false;

        }
        if(eight == 1 && nine == 1 && seven != 2)
        {
            Button___script_end_row_left_goal_post();
                        return false;

        } 
        if(eight != 2 && nine == 1 && seven == 1)
        {
            Button___script_end_row_mid_goal_post();
                        return false;

        }
                    return true;

    }

    bool computer_winning_conditions()
    {
        Debug.Log("nice");
        // condition 1.1
        if(one == 2 && two == 2 && three != 2)
        {
            Button___script_up_row_right_goal_post();
            return false;
        }
        if(two == 2 && three == 2 && one != 2)
        {
            Button___script_up_row_left_goal_post();
                        return false;

        }
        if(three == 2 && one == 2 && two != 2)
        {
            Button___script_up_row_mid_goal_post();
                        return false;

        }

        // condition 1.2
        if(one == 2 && four == 2 && seven != 2)
        {
           Button___script_end_row_left_goal_post();
                       return false;

        }
        if(four == 2 && seven == 2 && one != 2)
        {
           Button___script_up_row_left_goal_post(); 
                       return false;

        }
        if( seven == 2 && one == 2 && four != 2)
        {
           Button___script_mid_row_left_goal_post(); 
                       return false;

        }


        // condition 1.3
        if(one == 2 && five == 2 && nine != 2)
        {
           Button___script_end_row_right_goal_post();
                       return false;


        }
        if(five == 2 && nine == 2 && one != 2)
        {
          Button___script_up_row_left_goal_post();
                      return false;

        }
        if(five != 2 && nine == 2 && one == 2)
        {
          Button___script_mid_row_mid_goal_post();
                      return false;

        }

        //-----------

        // condition 2.1
        if(two == 2 && five == 2 && eight != 2)
        {
            Button___script_end_row_mid_goal_post();
                        return false;

        }
        if(five == 2 && eight == 2 && two != 2)
        {
            Button___script_up_row_mid_goal_post();
                        return false;

        }
        if(five != 2 && eight == 2 && two == 2)
        {
            Button___script_mid_row_mid_goal_post();
                        return false;

        }
        //--------

        // condition 3.1
        if(three == 2 && five == 2 && seven != 2)
        {
            Button___script_end_row_left_goal_post();
                        return false;

        }
        if( five == 2 && seven == 2 && three != 2)
        {
            Button___script_up_row_right_goal_post();
                        return false;

        }
        if( five != 2 && seven == 2 && three == 2)
        {
            Button___script_mid_row_mid_goal_post();
                        return false;

        }

        // condition 3.2
        if(three == 2 && six == 2 && nine != 2)
        {
            Button___script_end_row_right_goal_post();
                        return false;

        }
        if(six == 2 && nine == 2 && three != 2)
        {
           Button___script_up_row_right_goal_post();
                       return false;

        }
        if(six != 2 && nine == 2 && three == 2)
        {
           Button___script_mid_row_right_goal_post();
                       return false;

        }

        // ---------------

        // condition 4.1
        if(four == 2 && five == 2 && six != 2)
        {
            Button___script_mid_row_right_goal_post();
                        return false;

        }
        if(five == 2 && six == 2 && four != 2)
        {
            Button___script_mid_row_left_goal_post();
                        return false;

        } 
        if(five != 2 && six == 2 && four == 2)
        {
            Button___script_mid_row_mid_goal_post();
                        return false;

        } 

        //---------

        // condition 5.1
        if(seven == 2 && eight == 2 && nine != 2)
        {
            Button___script_end_row_right_goal_post();
                        return false;

        }
        if(eight == 2 && nine == 2 && seven != 2)
        {
            Button___script_end_row_left_goal_post();
                        return false;

        } 
        if(eight != 2 && nine == 2 && seven == 2)
        {
            Button___script_end_row_mid_goal_post();
                        return false;

        }
                    return true;

    }



    // button one // last row mid
    public void Button___script_end_row_mid_goal_post()
    {
        myanim.SetBool("shoot",true);
        script_end_row_mid_goal_post_set = true;
    }

    // button two // last row left
    public void Button___script_end_row_left_goal_post()
    {
        myanim.SetBool("shoot",true);
        script_end_row_left_goal_post_set = true;
    }

    // button three /// last row right
    public void Button___script_end_row_right_goal_post()
    {
        myanim.SetBool("shoot",true);
        script_end_row_right_goal_post_set = true;
    }

    // button four // mid row mid
    public void Button___script_mid_row_mid_goal_post()
    {
        myanim.SetBool("shoot",true);
        script_mid_row_mid_goal_post_set = true;
    }

    // button five // mid row left
    public void Button___script_mid_row_left_goal_post()
    {
        myanim.SetBool("shoot",true);
        script_mid_row_left_goal_post_set = true;
    }

    // button six /// mid row right
    public void Button___script_mid_row_right_goal_post()
    {
        myanim.SetBool("shoot",true);
        script_mid_row_right_goal_post_set = true;
    }

    // button seven // up row mid
    public void Button___script_up_row_mid_goal_post()
    {
        myanim.SetBool("shoot",true);
        script_up_row_mid_goal_post_set = true;
    }

    // button eight // up row left
    public void Button___script_up_row_left_goal_post()
    {
        myanim.SetBool("shoot",true);
        script_up_row_left_goal_post_set = true;
    }

    // button nine /// up row right
    public void Button___script_up_row_right_goal_post()
    {
        myanim.SetBool("shoot",true);
        script_up_row_right_goal_post_set = true;
    }





    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "Player")
        {
            // LAST ROW CONDITIONS
            if(script_end_row_mid_goal_post_set == true)
            {
                // eight
                script_end_row_mid_goal_post.GetComponent<end_row_mid_goal_post>().enabled = true;
                myanim.SetBool("shoot",false);

                if(index_turn_check == 0)
                {
                    Player_One_Text[6].SetActive(true);
                    Player_One_Text_index[index] = 6;
                    index++;

                    index_turn = 1;
                    eight = 1;
                }
                if(index_turn_check == 1)
                {
                    Player_Two_Text[6].SetActive(true);
                    Player_Two_Text_index[index] = 6;
                    index++;
                    index_turn = 0;
                    eight = 2;
                }

                StartCoroutine(delay());
                script_end_row_mid_goal_post_set = false;
                //index_football++;
                //football[index_football].SetActive(true);

            }

            if(script_end_row_left_goal_post_set == true)
            {
                // seven

                script_end_row_left_goal_post.GetComponent<end_row_left_goal_post>().enabled = true;
                myanim.SetBool("shoot",false);

                if(index_turn_check == 0)
                {
                    Player_One_Text[7].SetActive(true);
                    Player_One_Text_index[index] = 7;
                    index++;

                    index_turn = 1;
                    seven = 1;
                }
                if(index_turn_check == 1)
                {
                    Player_Two_Text[7].SetActive(true);
                    Player_Two_Text_index[index] = 7;
                    index++;

                    index_turn = 0;
                    seven = 2;
                }

                StartCoroutine(delay());
                script_end_row_left_goal_post_set = false;

            }

            if(script_end_row_right_goal_post_set == true)
            {

                // nine

                script_end_row_right_goal_post.GetComponent<end_row_right_goal_post>().enabled = true;
                myanim.SetBool("shoot",false);

                if(index_turn_check == 0)
                {
                    Player_One_Text[8].SetActive(true);
                    Player_One_Text_index[index] = 8;
                    index++;

                    index_turn = 1;
                    nine = 1;
                }
                if(index_turn_check == 1)
                {
                    Player_Two_Text[8].SetActive(true);
                    Player_Two_Text_index[index] = 8;
                    index++;


                    index_turn = 0;
                    nine = 2;
                }

                StartCoroutine(delay());
                script_end_row_right_goal_post_set = false;
            }

            // MID ROW CONDITIONS
            if(script_mid_row_mid_goal_post_set == true)
            {
                // five 

                script_mid_row_mid_goal_post.GetComponent<mid_row_mid_goal_post>().enabled = true;
                myanim.SetBool("shoot",false);

                if(index_turn_check == 0)
                {
                    Player_One_Text[0].SetActive(true);
                    Player_One_Text_index[index] = 0;
                    index++;

                    index_turn = 1;
                    five = 1;
                }
                if(index_turn_check == 1)
                {
                    Player_Two_Text[0].SetActive(true);
                    Player_Two_Text_index[index] = 0;
                    index++;


                    index_turn = 0;
                    five = 2;
                }

                StartCoroutine(delay());
                script_mid_row_mid_goal_post_set = false;
            }

            if(script_mid_row_left_goal_post_set == true)
            {

                // four 

                script_mid_row_left_goal_post.GetComponent<mid_row_left_goal_post>().enabled = true;
                myanim.SetBool("shoot",false);

                if(index_turn_check == 0)
                {
                    Player_One_Text[2].SetActive(true);
                    Player_One_Text_index[index] = 2;
                    index++;


                    index_turn = 1;
                    four = 1;
                }
                if(index_turn_check == 1)
                {
                    Player_Two_Text[2].SetActive(true);
                    Player_Two_Text_index[index] = 2;
                    index++;


                    index_turn = 0;
                    four = 2;
                }

                StartCoroutine(delay());
                script_mid_row_left_goal_post_set = false;
            }

            if(script_mid_row_right_goal_post_set == true)
            {
                // six

                script_mid_row_right_goal_post.GetComponent<mid_row_right_goal_post>().enabled = true;
                myanim.SetBool("shoot",false);

                if(index_turn_check == 0)
                {
                    Player_One_Text[1].SetActive(true);
                    Player_One_Text_index[index] = 1;
                    index++;


                    index_turn = 1;
                    six = 1;
                }
                if(index_turn_check == 1)
                {
                    Player_Two_Text[1].SetActive(true);
                    Player_Two_Text_index[index] = 1;
                    index++;

                    
                    index_turn = 0;

                    six = 2;
                }

                StartCoroutine(delay());
                script_mid_row_right_goal_post_set = false;
            }

            // UP ROW CONDITIONS
            if(script_up_row_mid_goal_post_set == true)
            {
                // two

                script_up_row_mid_goal_post.GetComponent<up_row_mid_goal_post>().enabled = true;
                myanim.SetBool("shoot",false);

                if(index_turn_check == 0)
                {
                    Player_One_Text[4].SetActive(true);
                    Player_One_Text_index[index] = 4;
                    index++;

                    index_turn = 1;
                    two = 1;
                }
                if(index_turn_check == 1)
                {
                    Player_Two_Text[4].SetActive(true);
                    Player_Two_Text_index[index] = 4;
                    index++;

                    index_turn = 0;
                    two = 2;
                }

                StartCoroutine(delay());
                script_up_row_mid_goal_post_set = false;
            }

            if(script_up_row_left_goal_post_set == true)
            {
                // ONE
                script_up_row_left_goal_post.GetComponent<up_row_left_goal_post>().enabled = true;
                myanim.SetBool("shoot",false);

                if(index_turn_check == 0)
                {
                    Player_One_Text[5].SetActive(true);
                    Player_One_Text_index[index] = 5;
                    index++;

                    index_turn = 1;
                    one = 1;
                }
                if(index_turn_check == 1)
                {
                    Player_Two_Text[5].SetActive(true);
                    Player_Two_Text_index[index] = 5;
                    index++;

                    index_turn = 0;
                    one = 2;
                }
                StartCoroutine(delay());
                script_up_row_left_goal_post_set = false;
            }

            if(script_up_row_right_goal_post_set == true)
            {
                // three

                script_up_row_right_goal_post.GetComponent<up_row_right_goal_post>().enabled = true;
                myanim.SetBool("shoot",false);

                if(index_turn_check == 0)
                {
                    Player_One_Text[3].SetActive(true);
                    Player_One_Text_index[index] = 3;
                    index++;

                    index_turn = 1;
                    three = 1;
                }
                if(index_turn_check == 1)
                {
                    Player_Two_Text[3].SetActive(true);
                    Player_Two_Text_index[index] = 3;
                    index++;

                    index_turn = 0;
                    three = 2;
                }

                StartCoroutine(delay());
                script_up_row_right_goal_post_set = false;
            }

            // SETTING-PLAYER-ONE-PREF-TEXT
            PlayerPrefs.SetInt("player_one_zero_index", Player_One_Text_index[0]);
            PlayerPrefs.SetInt("player_one_one_index", Player_One_Text_index[1]);
            PlayerPrefs.SetInt("player_one_two_index", Player_One_Text_index[2]);
            PlayerPrefs.SetInt("player_one_three_index", Player_One_Text_index[3]);
            PlayerPrefs.SetInt("player_one_four_index", Player_One_Text_index[4]);
            PlayerPrefs.SetInt("player_one_five_index", Player_One_Text_index[5]);
            PlayerPrefs.SetInt("player_one_six_index", Player_One_Text_index[6]);
            PlayerPrefs.SetInt("player_one_seven_index", Player_One_Text_index[7]);
            PlayerPrefs.SetInt("player_one_eight_index", Player_One_Text_index[8]);
            
            // SETTING-PLAYER-TWO-PREF-TEXT
            PlayerPrefs.SetInt("player_two_zero_index", Player_Two_Text_index[0]);
            PlayerPrefs.SetInt("player_two_one_index", Player_Two_Text_index[1]);
            PlayerPrefs.SetInt("player_two_two_index", Player_Two_Text_index[2]);
            PlayerPrefs.SetInt("player_two_three_index", Player_Two_Text_index[3]);
            PlayerPrefs.SetInt("player_two_four_index", Player_Two_Text_index[4]);
            PlayerPrefs.SetInt("player_two_five_index", Player_Two_Text_index[5]);
            PlayerPrefs.SetInt("player_two_six_index", Player_Two_Text_index[6]);
            PlayerPrefs.SetInt("player_two_seven_index", Player_Two_Text_index[7]);
            PlayerPrefs.SetInt("player_two_eight_index", Player_Two_Text_index[8]);      

            // SETTING-INDEX
            PlayerPrefs.SetInt("INDEX_GOAL_TEXT", index);

            // saving ONE - EIGHT 
            PlayerPrefs.SetInt("one", one);
            PlayerPrefs.SetInt("two", two);
            PlayerPrefs.SetInt("three", three);
            PlayerPrefs.SetInt("four", four);
            PlayerPrefs.SetInt("five", five);
            PlayerPrefs.SetInt("six", six);
            PlayerPrefs.SetInt("seven", seven);
            PlayerPrefs.SetInt("eight", eight);
            PlayerPrefs.SetInt("nine", nine);    

            // index turn save
            PlayerPrefs.SetInt("index_turn", index_turn);    
            Debug.Log("this -> "+index_turn);


        }
    } 


    IEnumerator delay()
    {
        yield return new WaitForSeconds(2f);

        // LAST 
        script_end_row_mid_goal_post.GetComponent<end_row_mid_goal_post>().enabled = false;
        script_end_row_left_goal_post.GetComponent<end_row_left_goal_post>().enabled = false;
        script_end_row_right_goal_post.GetComponent<end_row_right_goal_post>().enabled = false;
        // MID
        script_mid_row_mid_goal_post.GetComponent<mid_row_mid_goal_post>().enabled = false;
        script_mid_row_left_goal_post.GetComponent<mid_row_left_goal_post>().enabled = false;
        script_mid_row_right_goal_post.GetComponent<mid_row_right_goal_post>().enabled = false;
        // UP
        script_up_row_mid_goal_post.GetComponent<up_row_mid_goal_post>().enabled = false;
        script_up_row_left_goal_post.GetComponent<up_row_left_goal_post>().enabled = false;
        script_up_row_right_goal_post.GetComponent<up_row_right_goal_post>().enabled = false;
        
        //RB.velocity = Vector3.zero; 
        Check_All_Conditons();

        yield return new WaitForSeconds(2f);


        //gameObject.transform.position = originalPos;

    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(3f);
        Debug.Log("adsa");
       //SceneManager.LoadScene(3);

    }
}
