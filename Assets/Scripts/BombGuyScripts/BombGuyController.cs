using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombGuyController : MonoBehaviour
{
    // BombGuyController가 Animator 컴포넌트를 알아야한다.
    // 왜? 애니메이션 전환을 해야하니까
    // Animator컴포넌트는 자식 오브젝트 anim에 붙어 있다.
    // 어떻게 하면 자식 오브젝트에 붙어있는 Animator컴포넌트를 가져올 수 있을까?

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

        // 시리얼 라이즈로 anim을 찾거나 아래처렴 쳐야하는데 지금은 시리얼라이즈로 찾자
        /*Transform animTransform = this.transform.Find("anim");
        GameObject animGo = animTransform.gameObject;
        this.anim = animGo.GetComponent<Animator>();*/

        // 코루틴 함수 호출 시
        // 도커먼에 전역처럼 적혀있긴한데 전역 아니니까 주의
        this.coroutine = this.StartCoroutine(this.CoMove(() =>
        {
            Debug.LogFormat("이동을 모두 완료 했습니다.");

        }));
    }

    IEnumerator CoMove(System.Action callback)
    {
        // 매 프레임마다 앞으로 이동
        while (true)
        {
            this.transform.Translate(transform.right * 1f * Time.deltaTime);

            float length =  this.flag.position.x - this.transform.position.x;
            Debug.LogFormat("이동 중 남은 거리 : {0}", length);

            if(length < 1)
            {
                break;
            }

            // 반복문 무한루프 쓸때 이거 꼭 안에다가 넣어놓자
            // 안 넣어두면 무한루프하면서 유니티가 먹통됨
            yield return null; // 다음 프레임으로 넘어간다.
        }
        Debug.Log("이동 완료");
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

        /*// 이동
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
            // 애니메이션 변경
            this.anim.SetInteger("State", (int)state);
        }
        // 이동 힘 가하기
        this.rbody.AddForce(transform.right * dirX * moveForce);

        // 바라보는 방향 변경
        if (dirX != 0)
        {
            this.transform.localScale = new Vector3(dirX * 2, 2, 2);
        }*/


        //////////////////////////////////////////////////////////////////////////////////////
        // 키 입력으로 애니메이터 전환
        /*if (Input.GetKey(KeyCode.Alpha0))
        {
            Debug.Log("Idle");
            // 애니메이션 전환하기
            // 전환할 때 파라미터에 값을 변경하기
            this.anim.SetInteger("State", 0);
        }
        if (Input.GetKey(KeyCode.Alpha1))
        {
            Debug.Log("Run");
            this.anim.SetInteger("State", 1);
        }*/

        //////////////////////////////////////////////////////////////////////////////////////

        // 어택 애니메이션 / 공격 당했을 때 죽는거
    }
}
