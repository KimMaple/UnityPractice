using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyController : MonoBehaviour
{
    [SerializeField] Animator capAnim;
    [SerializeField] Coroutine Coroutine;

    private enum State
    {
        Idle, Hit, HitDead, DeadGround
    }
    private int state;

    public int capHp = 2;
    void Start()
    {
        this.Coroutine = StartCoroutine(CoCapMove());
    }

    private IEnumerator CoCapMove()
    {
        state = 0;
        if (capHp > 1)
        {
            state = 0;
        }
        if (capHp == 1)
        {
            state = 2;
        }
        
        if (capHp == 0)
        {
            state = 3;
        }
        this.capAnim.SetInteger("CaptainState", (int)state);
        yield return null;
    }

    // Update is called once per frame
    void Update()
    {
            
        if (Input.GetMouseButtonDown(0))
        {
            capHp -= 1;
        }       
        Debug.Log(capHp);
    }
}
