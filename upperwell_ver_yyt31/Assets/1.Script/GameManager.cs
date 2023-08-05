using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {



        StartCoroutine("SpawnLoop");


    }


    IEnumerable SpawnLoop()
    {


        while (true)
        {
            Debug.Log("ㅜ출력 ");
            yield return new WaitForSeconds(1f);

        }
    }
    IEnumerable corutineEx()
    {

        for(; ; )
        {

            yield return new WaitForSeconds(1f);
        }

       // yield return new WaitForSeconds(1f);
    }
}
