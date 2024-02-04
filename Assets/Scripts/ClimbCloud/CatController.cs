using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;      // 이걸 넣어야지 씬을 전환할 수 있다.

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
            // 스페이스바 클릭
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // 점프(힘을 가한다.)
                this.rbody.AddForce(this.transform.up * this.jumpForce);    // 로컬 기준
                //this.rbody.AddForce(Vector3.up * this.force); // 월드 기준     
            }
        }

        /****************************************************************************************************************/

        // 이동 방향 -1,0,1
        int dirX = 0;

        // 좌우 막는 방법 이거 토대로 코드 수정하자!
        Vector3 localPosition = new Vector3(Mathf.Clamp(this.transform.position.x, minf, maxf),
            this.transform.position.y, this.transform.position.z);
        this.transform.position = localPosition;

        // 오브젝트 움직이기 내 코드
        // 0.1f 추가
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
        if (Mathf.Abs(this.rbody.velocity.x) < 3)   // 오 아래서 안된 속도 제한이 된다.
        {
            this.rbody.AddForce(Vector2.right * dirX * 0.1f, ForceMode2D.Impulse);
        }

        /****************************************************************************************************************/

        // 오브젝트 움직이기 배운방법
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
        // 도전! : 속도를 제한하자.  // 안되는것 같은데 좀 찾아봐야겠다.
        if (Mathf.Abs(this.rbody.velocity.x) < 3)
        {
            this.rbody.AddForce(this.transform.right * dirX * moveForce);
        }*/

        /****************************************************************************************************************/

        //Debug.LogFormat("dir : {0}", dirX);

        // 오브젝트 고양이 캐릭터가 바라보는 방향 -1: 왼쪽 / 1: 오른쪽
        // 단, 0일때는 값을 안 넣음
        if (dirX != 0)
        {
            this.transform.localScale = new Vector3(dirX, 1, 1);
        }

        // 벡터의 곱
        //Debug.Log(this.transform.right * dirX);     // vector3

        /****************************************************************************************************************/

        // 애니메이션 속도조절
        this.animator.speed = Mathf.Abs(this.rbody.velocity.x*0.7f);
        this.gameDirector.UpdateVelocityText(this.rbody.velocity);
    }


    // Trigger모드일 경우 충돌판정을 해주는 이벤트
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (change == 0)
        {
            // 장면을 전환
            SceneManager.LoadScene("ClimbCloudClear");
            // 최초 충돌 할때 한번만 호출
            Debug.LogFormat("OnTriggerEnter2D : {0}", collision);
            change = 1;
        }        
    }
}
