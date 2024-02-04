using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class ArrowController : MonoBehaviour
{
    [SerializeField] private float speed = 1.0f;
    [SerializeField] private float radius = 0.5f;

    private CatEscapeGameDirector gameDirector;

    private GameObject playerGo;

    private void Start()
    {
        // �̸����� ���� ������Ʈ�� ã�´�.
        this.playerGo = GameObject.Find("player");
        // �̸����� ���� ���͸� ã�´�.
        this.gameDirector = GameObject.FindObjectOfType<CatEscapeGameDirector>();
    }

    // Update is called once per frame
    void Update()
    {     
        // ���� * �ӵ� * �ð�
        Vector3 movement = Vector3.down * speed * Time.deltaTime;
        this.transform.Translate(movement);
        // Debug.LogFormat("y = {0}", this.transform.position.y);
        
        // ���� y ��ǥ�� -3.1���� �۾������� ������ �����Ѵ�.
        if(this.transform.position.y <= -3.1)
        {
            //Debug.LogError("����");
            //Destroy(this); => ����!!! ArrowController ������Ʈ�� ���ŵȴ�.
            Destroy(this.gameObject); // ���ӿ�����Ʈ�� ������ ����
        }

        // �÷��̾�� ȭ��ǥ�� �Ÿ�
        Vector2 p1 = this.transform.position;
        Vector2 p2 = this.playerGo.transform.position;
        Vector2 dir = p1 - p2;  // ����
        float distance = dir.magnitude; // �Ÿ�
        // float distance = Vector2.Distance(p1,p2);

        // ������ ������ ��
        float r1 = this.radius;
        playerController controller = this.playerGo.GetComponent<playerController>();
        float r2 = controller.radius;
        float sumRadius = r1 + r2;

        // �÷��̾�� ȭ��ǥ �Ÿ� < ������ �� �̸� �浹
        if (distance < sumRadius)   // �浹��
        {
            Debug.LogFormat("�浹");
            Destroy(this.gameObject); //������ ����

            this.gameDirector.DecreaseHP();
        }
    }

    // �̺�Ʈ �Լ�
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, this.radius);
    }
}
