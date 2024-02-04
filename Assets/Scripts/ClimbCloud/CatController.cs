using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;      // �̰� �־���� ���� ��ȯ�� �� �ִ�.

public class CatController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rbody;
    [SerializeField] private float moveForce = 30f;
    [SerializeField] private float jumpForce = 500f;
    [SerializeField] private ClimbCloudGameDirector gameDirector;
    //private int scale = 1;
    private int change = 0;
    private float minf = -2.65f;
    private float maxf = 2.65f;

    Animator animator;

    private void Start()
    {
        //this.gameDirector = GameObject.Find("GameDirector").GetComponent<ClimbCloudGameDirector>();
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        if (this.rbody.velocity.y == 0)
        {
            // �����̽��� Ŭ��
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // ����(���� ���Ѵ�.)
                this.rbody.AddForce(this.transform.up * this.jumpForce);    // ���� ����
                //this.rbody.AddForce(Vector3.up * this.force); // ���� ����     
            }
        }

        /****************************************************************************************************************/

        // �̵� ���� -1,0,1
        int dirX = 0;

        // �¿� ���� ��� �̰� ���� �ڵ� ��������!
        Vector3 localPosition = new Vector3(Mathf.Clamp(this.transform.position.x, minf, maxf),
            this.transform.position.y, this.transform.position.z);
        this.transform.position = localPosition;

        // ������Ʈ �����̱� �� �ڵ�
        // 0.1f �߰�
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            dirX = -1;
            //this.rbody.AddForce(Vector2.right * dirX * 0.1f, ForceMode2D.Impulse);
            //this.rbody.AddForce(-this.transform.right * this.force * 0.1f);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            dirX = 1;
            //this.rbody.AddForce(Vector2.right * dirX * 0.1f, ForceMode2D.Impulse);
            //this.rbody.AddForce(this.transform.right * this.force * 0.1f);
        }
        if (Mathf.Abs(this.rbody.velocity.x) < 3)   // �� �Ʒ��� �ȵ� �ӵ� ������ �ȴ�.
        {
            this.rbody.AddForce(Vector2.right * dirX * 0.1f, ForceMode2D.Impulse);
        }

        /****************************************************************************************************************/

        // ������Ʈ �����̱� �����
        /*if (Input.GetKey(KeyCode.LeftArrow))
        {
            dirX = -1;
            //scale = -1;
            //this.transform.localScale = new Vector3(scale,1,1);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            dirX = 1;
            //scale = 1;
            //this.transform.localScale = new Vector3(scale, 1, 1);
        }
        // ����! : �ӵ��� ��������.  // �ȵǴ°� ������ �� ã�ƺ��߰ڴ�.
        if (Mathf.Abs(this.rbody.velocity.x) < 3)
        {
            this.rbody.AddForce(this.transform.right * dirX * moveForce);
        }*/

        /****************************************************************************************************************/

        //Debug.LogFormat("dir : {0}", dirX);

        // ������Ʈ ����� ĳ���Ͱ� �ٶ󺸴� ���� -1: ���� / 1: ������
        // ��, 0�϶��� ���� �� ����
        if (dirX != 0)
        {
            this.transform.localScale = new Vector3(dirX, 1, 1);
        }

        // ������ ��
        //Debug.Log(this.transform.right * dirX);     // vector3

        /****************************************************************************************************************/

        // �ִϸ��̼� �ӵ�����
        this.animator.speed = Mathf.Abs(this.rbody.velocity.x*0.7f);
        this.gameDirector.UpdateVelocityText(this.rbody.velocity);
    }


    // Trigger����� ��� �浹������ ���ִ� �̺�Ʈ
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (change == 0)
        {
            // ����� ��ȯ
            SceneManager.LoadScene("ClimbCloudClear");
            // ���� �浹 �Ҷ� �ѹ��� ȣ��
            Debug.LogFormat("OnTriggerEnter2D : {0}", collision);
            change = 1;
        }        
    }
}
