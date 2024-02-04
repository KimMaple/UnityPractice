using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    private ExplosionGenerator explosionGenerator = new ExplosionGenerator();
    private GameObject camera;
    private Animator anim;
    [SerializeField] int hp = 2;
    float speed = 0.5f;


   /* private enum State
    {
        EnemyA, EnemyAHit
    }
    private State state;*/

    private void Start()
    {
        camera = GameObject.Find("Main Camera");
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        this.transform.Translate(Vector2.down * Time.deltaTime * speed);

        if (hp == 0)
        {
            this.CreateExplosion();
            Destroy(this.gameObject);
        }
        if (transform.position.y <= camera.transform.position.y - 7)
        {
            Destroy(this.gameObject);
        }

        //state = State.EnemyA;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerBullet")
        {
            hp--;
            //state = State.EnemyAHit;
        }

       // Debug.Log((int)state);
        //this.anim.SetInteger("State", (int)state);
        Debug.LogFormat("EnemyA Hp : {0}", hp);
    }

    public void CreateExplosion()
    {
        GameObject explosionGo = this.explosionGenerator.CreateExplosion();
        explosionGo.transform.position = this.transform.position;
        explosionGo.GetComponent<ExplosionController>().Explode();
    }
}
