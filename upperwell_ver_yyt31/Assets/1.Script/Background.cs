using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{


    Renderer render;
    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<Renderer>();
        
    }
    [SerializeField]
    float speed = 0.1f;


    // Update is called once per frame
    void Update()
    {
        //0-1사이 반
        float y = Mathf.Repeat(Time.time * speed, 1);


        //Time.time my game playing hours
        Vector2 offset = new Vector2(0, y);

        //render.sharedMaterial.SetTextureOffset("_MainTex", offset); //공유되 재질
        render.material.SetTextureOffset("_MainTex", offset); //개별

    }
}
