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
        // 이름으로 게임 오브젝트를 찾는다.
        this.playerGo = GameObject.Find("player");
        // 이름으로 게임 디렉터를 찾는다.
        this.gameDirector = GameObject.FindObjectOfType<CatEscapeGameDirector>();
    }

    // Update is called once per frame
    void Update()
    {     
        // 방향 * 속도 * 시간
        Vector3 movement = Vector3.down * speed * Time.deltaTime;
        this.transform.Translate(movement);
        // Debug.LogFormat("y = {0}", this.transform.position.y);
        
        // 현재 y 좌표가 -3.1보다 작아졌을때 씬에서 제거한다.
        if(this.transform.position.y <= -3.1)
        {
            //Debug.LogError("제거");
            //Destroy(this); => 주의!!! ArrowController 컴포넌트가 제거된다.
            Destroy(this.gameObject); // 게임오브젝트를 씬에서 제거
        }

        // 플레이어와 화살표의 거리
        Vector2 p1 = this.transform.position;
        Vector2 p2 = this.playerGo.transform.position;
        Vector2 dir = p1 - p2;  // 방향
        float distance = dir.magnitude; // 거리
        // float distance = Vector2.Distance(p1,p2);

        // 반지름 끼리의 합
        float r1 = this.radius;
        playerController controller = this.playerGo.GetComponent<playerController>();
        float r2 = controller.radius;
        float sumRadius = r1 + r2;

        // 플레이어와 화살표 거리 < 반지름 합 이면 충돌
        if (distance < sumRadius)   // 충돌함
        {
            Debug.LogFormat("충돌");
            Destroy(this.gameObject); //씬에서 제거

            this.gameDirector.DecreaseHP();
        }
    }

    // 이벤트 함수
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, this.radius);
    }
}
