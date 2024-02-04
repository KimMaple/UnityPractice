using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipController : MonoBehaviour
{
    [SerializeField] private ExplosionGenerator explosionGenerator;
    private float limitPosition;    // X축 화면 제한 값 변수
    private float minX = -2.3f, maxX = 2.3f;    // 화면 제한 범위
    private float horizontal;   // X축
    private float vertical;     // Y축
    float speed = 5f;          // 플레이어 이동속도
    private enum State
    {
        Center, Left, Right
    }

    Animator anim;

    [SerializeField] private int playerHp = 4;   // 플레이어 체력

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

        // 체력이 양수 일 때만 동작 가능
        if (playerHp > 0)
        {
            // 이동 메서드 호출
            Move(state);
        }else if(playerHp == 0)
        {
            this.CreateExplosion();
            Destroy(this.gameObject);
        }
        
    }

    private void Move(State state)
    {
        // x 범위 밖으로 안나가도록 제한
        limitPosition = Mathf.Clamp(this.transform.position.x, minX, maxX);
        this.transform.position = new Vector3
            (limitPosition, transform.position.y, transform.position.z);

        // 키 입력
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

        // 플레이어 이동
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
