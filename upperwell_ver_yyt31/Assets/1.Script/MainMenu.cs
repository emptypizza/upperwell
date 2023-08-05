using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MainMenu : MonoBehaviour
{

    public Button[] buttons;
    // Start is called before the first frame update
    void Start()
    {

        Creditimg.gameObject.SetActive(false);

        buttons = new Button[3];


        buttons[0] = GameObject.Find("Button_start").GetComponent<Button>();
        buttons[1] = GameObject.Find("Button_credit").GetComponent<Button>();
        buttons[2] = GameObject.Find("Button_exit").GetComponent<Button>();





        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].onClick.AddListener(TaskOnClick);
            
        }
      
    }

 
    void TaskOnClick()
    {
        bBtnflag = true;
    }

    public bool bBtnflag = false;
    string btnname;

    private void Update()
    {
       
        
        
      
    }

    public int num = -1;

    public void n_executeGame()
    {


        UnityEditor.SceneManagement.EditorSceneManager.LoadScene("u_level0");



    }

    public void executeGame()
    {

        num = 0;

        UnityEditor.SceneManagement.EditorSceneManager.LoadScene("u_level0");

       

    }

    public Image Creditimg;


    public void credit()
    {
        Creditimg.gameObject.SetActive(true);
        
        num = 1;

    }

    public void exitfromcredit()
    {
        Creditimg.gameObject.SetActive(false);

        num = 2;

    }

    public void exit()
    {
        Application.Quit();

        num = 3;

    }

}
