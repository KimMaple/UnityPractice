using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipController : MonoBehaviour
{
    [SerializeField] private ExplosionGenerator explosionGenerator;
    private float limitPosition;    // X�� ȭ�� ���� �� ����
    private float minX = -2.3f, maxX = 2.3f;    // ȭ�� ���� ����
    private float horizontal;   // X��
    private float vertical;     // Y��
    float speed = 5f;          // �÷��̾� �̵��ӵ�
    private enum State
    {
        Center, Left, Right
    }

    Animator anim;

    [SerializeField] private int playerHp = 4;   // �÷��̾� ü��

    public int GetPlayerHp() {  return this.playerHp; }
    public void SetPlayerHp(int hp) { this.playerHp = hp; }

    private void Start()
    {
        anim = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        State state = State.Center;

        // ü���� ��� �� ���� ���� ����
        if (playerHp > 0)
        {
            // �̵� �޼��� ȣ��
            Move(state);
        }else if(playerHp == 0)
        {
            this.CreateExplosion();
            Destroy(this.gameObject);
        }
        
    }

    private void Move(State state)
    {
        // x ���� ������ �ȳ������� ����
        limitPosition = Mathf.Clamp(this.transform.position.x, minX, maxX);
        this.transform.position = new Vector3
            (limitPosition, transform.position.y, transform.position.z);

        // Ű �Է�
        horizontal = Input.GetAxisRaw("Horizontal"); // x (-1,0,1)
        vertical = Input.GetAxisRaw("Vertical");    // y (-1,0,1)

        if(horizontal == -1)
        {
            state = State.Left;
        }
        if(horizontal == 1)
        {
            state = State.Right;
        }

        anim.SetInteger("State", (int)state);

        // �÷��̾� �̵�
        this.transform.Translate
            (new Vector3(horizontal, vertical, 0) * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerHp -= 1;
        Debug.Log(playerHp);
    }

    private void CreateExplosion()
    {
        GameObject explosionGo = this.explosionGenerator.CreateExplosion();
        explosionGo.transform.position = this.transform.position;
        explosionGo.GetComponent<ExplosionController>().Explode();
    }
}
