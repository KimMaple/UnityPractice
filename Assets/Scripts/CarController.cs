using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] private float maxSpeed = 0.1f;
    [SerializeField] private float attenAttenuation = 0.96f;
    [SerializeField] private float divied = 4000f;
    private float speed = 0;
    private Vector3 startPosition;

    void Update()
    {
        // ���� ��ư�� �����ٸ�
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("ȭ�� ��ġ ����");
            // ȭ���� ��ġ�� ��ġ ��������
            Debug.Log(Input.mousePosition);
            this.startPosition = Input.mousePosition;
            //speed = maxSpeed;          
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("ȭ�鿡�� ���� ��");
            // ���� �� ����
            Debug.Log(Input.mousePosition);
            float length = Input.mousePosition.x - this.startPosition.x;
            // ȭ�鿡�� ���� �� ������ x - ��ġ�� ������ x
            Debug.LogFormat("Length : {0}", length);
            Debug.Log(length/divied);
            speed = length / divied;
            Debug.LogFormat("<color=yellow>speed: {0}</color>", speed);

            // ���� ����

            // ���� ������Ʈ�� �پ��ִ� ������Ʈ ��������
            AudioSource audioSource = this.gameObject.GetComponent<AudioSource>();
            audioSource.Play(/*������ �Ű�����*/); // ������ �Ű����� �� ������ ����Ʈ ����
        }
        //0.1 ���־� �� �����Ӹ��� �̵��Ѵ�
        this.gameObject.transform.Translate(new Vector3(speed, 0, 0));

        //  �� �����Ӹ��� �ӵ��� �پ���.
        speed *= attenAttenuation;
    }
}
