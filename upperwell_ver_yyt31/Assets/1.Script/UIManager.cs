using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{


    public Fbird fbird;
    public Text pc_rot_text;
    public Image Clear;
    public int nClear = 10;



    // Start is called before the first frame update
    void Start()
    {
        fbird = GameObject.FindObjectOfType<Fbird>();
        Clear.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        pc_rot_text.text = fbird.rb.rotation.ToString();
        if(fbird.transform.position.y > nClear)
        {
            Clear.gameObject.SetActive(true);
            Time.timeScale = 0.1f;

        }
        
    }

    public void executeGame()
    {

     

        UnityEditor.SceneManagement.EditorSceneManager.LoadScene("u_level0");



    }

}
