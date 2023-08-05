using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ColliderManage : MonoBehaviour
{


    public Image Clear;

    // Start is called bore the first frame update
    void Start()
    {
        Clear.gameObject.SetActive(false);  
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {


        if (collision.gameObject.CompareTag("wall_ok"))
        {
            collision.gameObject.GetComponent<Wall>().n_hp -= 1;
        }
        else if (collision.gameObject.CompareTag("wall_no"))
        {
            SceneManager.LoadScene(0);
        }
        else if (collision.gameObject.CompareTag("wall_good"))

        {
            Clear.gameObject.SetActive(true);
            Clear.transform.position = new Vector2(500  , 1250);
        }

        if (collision.gameObject.CompareTag("Ground"))

        {
          //  transform.GetComponentInParent<PlayerController>().isGrounded = true;
          //  transform.GetComponentInParent<PlayerController>().isJumping = false;
        }



    }

   void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
          //  transform.GetComponentInParent<PlayerController>().isGrounded = false;
        }
    }
}
