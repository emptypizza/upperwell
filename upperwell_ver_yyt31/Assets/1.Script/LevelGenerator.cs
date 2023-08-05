using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class LevelGenerator : MonoBehaviour
{


    public List<Wall> List_Walltype;
    float fTimer = 0f;
    public static int nColulmIndex = 0;


    // Start is called before the first frame update
    void Start()
    {


        for (int a = 0; a < GameObject.FindObjectsOfType<Wall>().Length; a++)
            List_Walltype.Add(GameObject.FindObjectsOfType<Wall>()[a]);

        //  foreach (Wall i in GameObject.FindObjectsOfType<Wall>())
        //     List_Walltype.Add(i);

        
    }




    // Update is called once per frame
    void Update()
    {


       

        fTimer += Time.deltaTime;
        if(fTimer > 2f)
        {
            fTimer = 0f;

            List_Walltype[nColulmIndex++].transform.Translate(new Vector3(1,0,0)) ;
            if (nColulmIndex > List_Walltype.Count)
                nColulmIndex = 0;
        }





    }
}
