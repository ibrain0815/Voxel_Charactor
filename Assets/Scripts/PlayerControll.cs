using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro; //TextMeshPro�� �������� ���ӽ����̽�

public class PlayerControll : MonoBehaviour
{
    [SerializeField] float moveSpd = 1f , rotateSpd =10f , jumpPower= 100f;
    [SerializeField] float normalSpd = 10f, HighSpd = 20f;
    Rigidbody rb;
    Animator anim;
    bool isDance = false;
    TextMeshPro nickName; //�г��� ���� �߰�
    //public AudioSource bgmSFX;
    bool isGrounded;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        nickName = GetComponentInChildren<TextMeshPro>(); //�ڽ��� ������Ʈ�� ã�Ƽ� �߰�
        nickName.text = UserData.nickName; //���� �����Ϳ��� ������ �г��� ��������

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
        //�ڽ� ������Ʈ�� �������� �����Ͽ� �������� �θ� �����  �ʵ��� ��
        isGrounded = Physics.Raycast(this.gameObject.transform.position, Vector3.down, out RaycastHit hit, 1f);
        //RaycastHit : �������� ������ ���� �ݶ��̴��� ����(bool type = false,true)
        //hit.transform.dkjfoihi = hit ������ ���ӿ�����Ʈ ó�� �ڴ� ���� + ������Ʈ�� ���� ����
        bool hitbox = (isGrounded) ? hit.transform.CompareTag("Ground") : false; // isGrounded�� true�� �տ���, isGrounded false�� �ڿ���
        //isGround(�����ɽ�Ʈ�� ������ �ִ��� ������)
        //���࿡ ���� �� = false:?{transform.CompareTag("Ground"):false}>>false�� ��ȯ
        //���࿡ ���� �� = false:?{transform.CompareTag("Ground"):false}>>hit.transform.CompareTag("Ground")//�±װ� "�׶���"���� Ȯ��

        if (hitbox == true) // hit.transform.CompareTag �� "Ground"�� �� //���� �� �Ʒ� ���� ��
        {
            GameObject Ground = hit.transform.parent.gameObject; //������ �������� �θ� �����ؼ� �̸��� GroundParent�� ����
            this.transform.parent = Ground.transform; //���� �θ� �׶��尡 �Ǿ���
            //Debug.Log(hit.transform.tag);
        }

        if (hitbox == false) // hit.transform.CompareTag �� "Ground" �ƴѶ� //���� ���Ʒ� ������
        {
            this.transform.parent = null;   //���� �θ𿡼� ��������
        }


        DanceOn();
        Jump();
    }

    private void Move()
    {
        //if (Input.GetAxis("Vertical") == 0)
        //{
        //    anim.SetBool("isWalk", false);
        //    return; //vertical �� 0�� ��� Move���� �ٷ� ��������
        //}
        ////�̵����� ��� �Ʒ� ����
        //anim.SetBool("isWalk", true);


        Runing();
        float fallSpd = rb.velocity.y; //���� �ӵ� ����
        Vector3 moveDir = new Vector3(0, 0, Input.GetAxis("Vertical")); //ĳ���� ����
        Vector3 worldDir = transform.TransformDirection(moveDir) * moveSpd * Time.deltaTime; ;
        worldDir.y = fallSpd; // ���ϼӵ� ����
        rb.velocity = worldDir; //���ν�Ƽ�� �����ؼ� �̵�
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
