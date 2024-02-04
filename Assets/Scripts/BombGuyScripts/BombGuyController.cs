using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombGuyController : MonoBehaviour
{
    // BombGuyController�� Animator ������Ʈ�� �˾ƾ��Ѵ�.
    // ��? �ִϸ��̼� ��ȯ�� �ؾ��ϴϱ�
    // Animator������Ʈ�� �ڽ� ������Ʈ anim�� �پ� �ִ�.
    // ��� �ϸ� �ڽ� ������Ʈ�� �پ��ִ� Animator������Ʈ�� ������ �� ������?

    [SerializeField] private Animator anim;
    [SerializeField] private Rigidbody2D rbody;
    [SerializeField] private float moveForce = 30f;
    [SerializeField] Transform flag;
    private Coroutine coroutine;
    private enum State
    {
        Idle, Run
    }


    private void Start()
    {
        Debug.Log("Start");

        // �ø��� ������� anim�� ã�ų� �Ʒ�ó�� �ľ��ϴµ� ������ �ø��������� ã��
        /*Transform animTransform = this.transform.Find("anim");
        GameObject animGo = animTransform.gameObject;
        this.anim = animGo.GetComponent<Animator>();*/

        // �ڷ�ƾ �Լ� ȣ�� ��
        // ��Ŀ�տ� ����ó�� �����ֱ��ѵ� ���� �ƴϴϱ� ����
        this.coroutine = this.StartCoroutine(this.CoMove(() =>
        {
            Debug.LogFormat("�̵��� ��� �Ϸ� �߽��ϴ�.");

        }));
    }

    IEnumerator CoMove(System.Action callback)
    {
        // �� �����Ӹ��� ������ �̵�
        while (true)
        {
            this.transform.Translate(transform.right * 1f * Time.deltaTime);

            float length =  this.flag.position.x - this.transform.position.x;
            Debug.LogFormat("�̵� �� ���� �Ÿ� : {0}", length);

            if(length < 1)
            {
                break;
            }

            // �ݺ��� ���ѷ��� ���� �̰� �� �ȿ��ٰ� �־����
            // �� �־�θ� ���ѷ����ϸ鼭 ����Ƽ�� �����
            yield return null; // ���� ���������� �Ѿ��.
        }
        Debug.Log("�̵� �Ϸ�");
        yield return null; yield return null; yield return null; 
        yield return null; yield return null; yield return null; 
        yield return null; yield return null; yield return null; 
        yield return null; yield return null; yield return null; 

        Debug.Log("End Of CoMove");

        callback();
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StopCoroutine(this.coroutine);
        }

        ///////////////////////////////////////////////////////////////////////////

        /*// �̵�
        int dirX = 0;
        State state = State.Idle;

        if (Mathf.Abs(this.rbody.velocity.x) < 3)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                dirX = -1;
                state = State.Run;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                dirX = 1;
                state = State.Run;
            }
            // �ִϸ��̼� ����
            this.anim.SetInteger("State", (int)state);
        }
        // �̵� �� ���ϱ�
        this.rbody.AddForce(transform.right * dirX * moveForce);

        // �ٶ󺸴� ���� ����
        if (dirX != 0)
        {
            this.transform.localScale = new Vector3(dirX * 2, 2, 2);
        }*/


        //////////////////////////////////////////////////////////////////////////////////////
        // Ű �Է����� �ִϸ����� ��ȯ
        /*if (Input.GetKey(KeyCode.Alpha0))
        {
            Debug.Log("Idle");
            // �ִϸ��̼� ��ȯ�ϱ�
            // ��ȯ�� �� �Ķ���Ϳ� ���� �����ϱ�
            this.anim.SetInteger("State", 0);
        }
        if (Input.GetKey(KeyCode.Alpha1))
        {
            Debug.Log("Run");
            this.anim.SetInteger("State", 1);
        }*/

        //////////////////////////////////////////////////////////////////////////////////////

        // ���� �ִϸ��̼� / ���� ������ �� �״°�
    }
}
