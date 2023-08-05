using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fbird : MonoBehaviour
{



    public Vector2 gotopositon;
    public Rigidbody2D rb;
    public float forwardSpeed = 1.5f;


    public float fdeltatime;

    
    public float fDelayDuration = 1.5f;
    public bool bJumpOK = false;

    private float fillTimer = 0f; // Timer for tracking fill duration
    public float fJumpPower = 30;
    public float fillDuration = 1.5f; // Time in seconds for the alpha value to fill up
    public float alphaIncreaseRate = 1f; // Rate at which the alpha value increases per second
    public SpriteRenderer spriteRenderer; // Reference to the SpriteRenderer component
    private float currentAlpha = 0f; // Current alpha value



    public TextMesh Textjumpdelay;
    public TextMesh TextRbRot;

    public Animator anim;
    float moveInput;
    private bool isGrounded;


    public bool bIsDead = false;


    private int touchId = -1;


    public GameObject Aim;

    // Start is called before the first frame update
    void Start()
    {

        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        fdeltatime = 0;
        forwardSpeed = 1.5f;


        //Aim = transform.GetComponentsInChildren<>



    }


    void StartGame()
    {
        fdeltatime = 0;
        forwardSpeed = 1.5f;
        this.rb.velocity = new Vector2(forwardSpeed, 0);   

    }


    private void OnCollisionEnter2D(Collision2D collision) //�浹 ó��
    {
        if (collision.gameObject.CompareTag("wall_no"))
        {
            bIsDead = true;
            anim.SetTrigger("ani_dead");
        }

       // if (collision.collider.tag == "wall_ok" || collision.collider.tag == "wall_good")
       //     RotationBogan();
        
    }

    void FillAlpha() //구현 필요 
    {
        currentAlpha = Mathf.Clamp01(fillTimer / fillDuration * alphaIncreaseRate);
        spriteRenderer.color = new Color(this.GetComponent<SpriteRenderer>().color.r, this.GetComponent<SpriteRenderer>().color.g,

            this.GetComponent<SpriteRenderer>().color.b, currentAlpha);
    }


    public void OnDash()
    {
        if (bJumpOK == true)// && isGrounded)
        {

            /*
            Quaternion rotation = this.transform.rotation;


            // 현재 오브젝트의 Z 축 회전 값을 오일러 각으로 변환합니다.
            float angle = rotation.eulerAngles.z;
            //float angle = rb.rotation;

            //  angle = Mathf.Clamp(angle, -90, 90);

            // 각도를 기준으로 발사 방향 벡터를 계산합니다.
            Vector2 jumpDirection = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));

            rb.AddForce(jumpDirection * Vector2.up* fJumpPower, ForceMode2D.Impulse);  //this.rb.velocity = new Vector2(forwardSpeed, 0);
            */
            Vector2 dic_aim = Aim.transform.position - this.transform.position;

            rb.AddForce(dic_aim.normalized * fJumpPower, ForceMode2D.Impulse);  //this.rb.velocity = new Vector2(forwardSpeed, 0);
            anim.SetTrigger("ani_fly");

            fdeltatime = 0;
            fillTimer = 0f;
            bJumpOK = false;


        }
    }


    // 물리 업데이트마다 호출되는 FixedUpdate 메서드를 사용합니다.
    void RotationBogan()
    {
        // rigidbody의 위치에 땅을 검사할 레이캐스트를 발사합니다.
        Vector2 raycastOrigin = rb.position;
        //  RaycastHit2D hit = Physics2D.Raycast(raycastOrigin, Vector2.down, 1.0f, CompareTag("Wall");
        RaycastHit2D hit = Physics2D.Raycast(raycastOrigin, Vector2.down, 1.0f, LayerMask.GetMask("Ground"));

        // 땅에 닿아 있는지 여부를 판단합니다.
        isGrounded = (hit.collider != null);

        // 만약 땅에 닿아 있다면, rigidbody의 각도를 0으로 보간합니다.
        if (isGrounded)
        {   

        // 충돌한 오브젝트의 태그가 "wall"인지 확인합니다.
       
            // 보간 시 사용할 각도 (0으로 보간하려면 해당 값이 0이 되도록 설정합니다).
            float targetAngle = 0f;

            // 보간할 각도로 현재 각도와의 차이를 구합니다.
            float angleDifference = Mathf.DeltaAngle(rb.rotation, targetAngle);

            // 보간 속도를 조정합니다. (보간 속도를 높이면 더 빠르게 각도가 0으로 보간됩니다.)
            float interpolationSpeed = 5f;

            // 보간된 각도를 적용합니다.
            rb.rotation += angleDifference * interpolationSpeed * Time.fixedDeltaTime;
         }



        }
    // 에임을 처리하는 함수
    void HandleAim(Touch touch)
    {
        // 월드 좌표로 마우스 위치를 변환합니다.
        Vector3 aimPosition = Camera.main.ScreenToWorldPoint(touch.position);
        aimPosition.z = 0f; // 2D 게임에서는 z 좌표를 0으로 고정합니다.

        // 여기에서 원하는 작업을 수행하고 에임 위치에 따라 총알이나 레이저를 발사하거나 기타 동작을 수행합니다.
        // 예시: 총알 발사 함수 호출
        // ShootBullet(aimPosition);

        // 예시: 캐릭터를 에임 위치로 회전시키기
        // Vector3 lookDirection = aimPosition - transform.position;
        // float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        // transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }

    // Update is called once per frame
    void Update()
    {
        RotationBogan();
         
        TextRbRot.text = this.rb.rotation.ToString();
        Textjumpdelay.text = fdeltatime.ToString("F2");
        moveInput = Input.GetAxisRaw("Horizontal");

        if (bIsDead == true) //만약 죽으면
        {
            UnityEditor.SceneManagement.EditorSceneManager.LoadScene(0);// 게임 오버 처리 구현 할것
        }
        if (Input.GetKeyDown(KeyCode.Space))
            OnDash();

        else if(moveInput != 0)
         rb.AddForce(new Vector2(moveInput*1, 0), ForceMode2D.Force);


       // else
       // {  rb.velocity = new Vector2(moveInput * 3, rb.velocity.y); }
             
              
               

        // 마우스 입력을 처리합니다.
        if (Input.GetMouseButtonDown(0))
        {
            // 마우스를 클릭하면 터치 아이디를 할당합니다.
            
            touchId = 0;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            // 마우스를 뗄 때 터치 아이디를 해제합니다.
            touchId = -1;
        }

        // 마우스가 눌려있는 동안 터치 이동을 처리합니다.
        if (touchId != -1)
        {
            // 터치 아이디에 해당하는 터치 정보를 가져옵니다.
            Touch touch = new Touch();
            touch.fingerId = touchId;
            touch.position = Input.mousePosition;
            touch.phase = TouchPhase.Moved;

            // 마우스 위치를 에임으로 사용하는 함수를 호출합니다.
            HandleAim(touch);
        }




        if (bJumpOK == false)
        {
            fdeltatime += Time.deltaTime;
          //  FillAlpha();
            if (fdeltatime >= fDelayDuration)
                bJumpOK = true;
        }



     

        

    }
}
