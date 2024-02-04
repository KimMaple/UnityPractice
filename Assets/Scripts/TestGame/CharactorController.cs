using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactorController : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] Transform flag;
    private Coroutine coroutine;

    private enum State
    {
        Idle, Run
    }

    void Start()
    {
        this.coroutine = StartCoroutine(CoMove());
    }

    IEnumerator CoMove()
    {
        State state = State.Idle;
        while (true)
        {
            float length = this.flag.position.x - this.transform.position.x;
            state = State.Run;
            this.transform.Translate(transform.right * 1f * Time.deltaTime);
            Debug.LogFormat("±ê¹ß±îÁö °Å¸® : {0}", length);
            this.anim.SetInteger("State", (int)state);

            if (length < 1)
            {
                state = State.Idle;
                break;
            }
            yield return null;
        }
        this.anim.SetInteger("State", (int)state);
        Debug.Log("µµÂø");
    }

    void Update()
    {

    }
}
