using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet1Controller : MonoBehaviour
{
    private GameObject camera;
    private GameObject player;
    private float bulletSpeed = 15f;
    private float minX = -2.3f, maxX = 2.3f;
    private float limitPosition;

    private void Start()
    {
        camera = GameObject.Find("Main Camera");
        player = GameObject.Find("PlayerShip");
        // �Ѿ� ���� ��ġ ���� ������
        this.transform.position = this.player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // ȭ�� ���� ũ��
        limitPosition = Mathf.Clamp(this.transform.position.x, minX, maxX);
        this.transform.Translate
            (this.transform.up * bulletSpeed * Time.deltaTime);

        // ȭ�� ���� ������ ������ �����
        if(this.transform.position.x < limitPosition 
            || this.transform.position.y > this.camera.transform.position.y+6)
        {
            Destroy(this.gameObject);
        }
    }

    // ������ ������ ��������� 
    private void OnTriggerEnter2D(Collider2D collision)
    {
            Destroy(this.gameObject);
    }
}
