using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro; //TextMeshPro를 쓰기위한 네임스페이스

public class PlayerControll : MonoBehaviour
{
    [SerializeField] float moveSpd = 1f , rotateSpd =10f , jumpPower= 100f;
    [SerializeField] float normalSpd = 10f, HighSpd = 20f;
    Rigidbody rb;
    Animator anim;
    bool isDance = false;
    TextMeshPro nickName; //닉네임 변수 추가
    //public AudioSource bgmSFX;
    bool isGrounded;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        nickName = GetComponentInChildren<TextMeshPro>(); //자식의 컴포넌트를 찾아서 추가
        nickName.text = UserData.nickName; //유저 데이터에서 저장한 닉네임 가져오기

        //bgmSFX.playOnAwake=true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 vec = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
  

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(vec * moveSpd * Time.deltaTime);
            anim.SetBool("isWalk", true);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(vec * moveSpd * Time.deltaTime);
            anim.SetBool("isWalk", true);
        }
        else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(vec * moveSpd * Time.deltaTime);
            anim.SetBool("isWalk", true);
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(vec * moveSpd * Time.deltaTime);
            anim.SetBool("isWalk", true);
        }
        else if (Input.GetKey(KeyCode.Z))
        {
            this.transform.Rotate(0.0f, -rotateSpd * Time.deltaTime, 0.0f);
        }
        else if (Input.GetKey(KeyCode.X))
        {
            this.transform.Rotate(0.0f, rotateSpd * Time.deltaTime, 0.0f);
        }
        else
        {
            anim.SetBool("isWalk", false);
            return;
        }



        //if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        //{
        //    transform.Translate(Vector3.forward * moveSpd * Time.deltaTime);
        //    anim.SetBool("isWalk", true);
        //}
        //else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        //{
        //    anim.SetBool("isWalk", true);
        //    transform.Translate(Vector3.forward * -moveSpd * Time.deltaTime);
        //}
        //else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        //{
        //    anim.SetBool("isWalk", true);
        //    transform.Translate(Vector3.right * -moveSpd * Time.deltaTime);
        //}
        //else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        //{
        //    anim.SetBool("isWalk", true);
        //    transform.Translate(Vector3.right * moveSpd * Time.deltaTime);
        //}
        //else if (Input.GetKey(KeyCode.Z))
        //{
        //    this.transform.Rotate(0.0f, -rotateSpd * Time.deltaTime, 0.0f);
        //}
        //else if (Input.GetKey(KeyCode.X))
        //{
        //    this.transform.Rotate(0.0f, rotateSpd * Time.deltaTime, 0.0f);
        //}
        //else
        //{
        //   anim.SetBool("isWalk", false);
        //    return;
        //}


        Move();

    }

    private void Update()
    {
        //자식 오브젝트에 오프셋을 적용하여 스케일이 부모를 벗어나지  않도록 함
        isGrounded = Physics.Raycast(this.gameObject.transform.position, Vector3.down, out RaycastHit hit, 1f);
        //RaycastHit : 레이저를 쐈을때 만난 콜라이더의 정보(bool type = false,true)
        //hit.transform.dkjfoihi = hit 정보를 게임오브젝트 처럼 코당 가능 + 컴포넌트에 접근 가능
        bool hitbox = (isGrounded) ? hit.transform.CompareTag("Ground") : false; // isGrounded가 true면 앞에꺼, isGrounded false면 뒤에꺼
        //isGround(레이케스트가 쐈을때 있느냐 없느냐)
        //만약에 없을 때 = false:?{transform.CompareTag("Ground"):false}>>false를 봔환
        //만약에 있을 때 = false:?{transform.CompareTag("Ground"):false}>>hit.transform.CompareTag("Ground")//태그가 "그라운드"인지 확인

        if (hitbox == true) // hit.transform.CompareTag 가 "Ground"일 때 //땅이 공 아래 있을 때
        {
            GameObject Ground = hit.transform.parent.gameObject; //레이저 만난놈이 부모에 접근해서 이름을 GroundParent로 적용
            this.transform.parent = Ground.transform; //공의 부모가 그라운드가 되어짐
            //Debug.Log(hit.transform.tag);
        }

        if (hitbox == false) // hit.transform.CompareTag 가 "Ground" 아닌때 //땅이 공아래 없을때
        {
            this.transform.parent = null;   //공의 부모에서 빠져나옴
        }


        DanceOn();
        Jump();
    }

    private void Move()
    {
        //if (Input.GetAxis("Vertical") == 0)
        //{
        //    anim.SetBool("isWalk", false);
        //    return; //vertical 이 0인 경우 Move에서 바로 빠져나감
        //}
        ////이동중인 경우 아래 실행
        //anim.SetBool("isWalk", true);


        Runing();
        float fallSpd = rb.velocity.y; //낙하 속도 저장
        Vector3 moveDir = new Vector3(0, 0, Input.GetAxis("Vertical")); //캐릭터 방향
        Vector3 worldDir = transform.TransformDirection(moveDir) * moveSpd * Time.deltaTime; ;
        worldDir.y = fallSpd; // 낙하속도 대입
        rb.velocity = worldDir; //벨로시티값 대입해서 이동
    }

    private void Runing()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            anim.SetBool("isRun", true);
            moveSpd = HighSpd;
            
        }
        else
        {
            anim.SetBool("isRun", false);
            moveSpd = normalSpd;
        }
        
    }

    void DanceOn()
    {
        //if(Input.GetKeyDown(KeyCode.LeftControl))
        //{

        //    anim.SetBool("isDance",true);
        //}
        //if(Input.GetKeyUp(KeyCode.LeftControl)) 
        //{
        //    anim.SetBool("isDance", false);
        //}

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            isDance = !isDance;
        }
             anim.SetBool("isDance",isDance);
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            anim.SetTrigger("isJump");
        }
    }


}
