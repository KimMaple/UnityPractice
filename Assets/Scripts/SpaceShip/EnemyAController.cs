using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAController : MonoBehaviour
{
    private GameObject explosion;
    private ExplosionGenerator explosionGenerator;
    private GameObject camera;
    private Animator anim;
    [SerializeField] int hp = 2;
    float speed = 0.5f;


    private enum State{
        EnemyA, EnemyAHit
    }   
    private State state;

    private void Start()
    {
        explosion = GameObject.Find("ExplosionGenerator");
        explosionGenerator = explosion.GetComponent<ExplosionGenerator>();
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
        if(transform.position.y <= camera.transform.position.y - 7)
        {
            Destroy(this.gameObject);
        }

        state = State.EnemyA;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerBullet")
        {
            hp--;
            state = State.EnemyAHit;     
        }

        Debug.Log((int)state);
        this.anim.SetInteger("State", (int)state);
        Debug.LogFormat("EnemyA Hp : {0}", hp);
    }

    private void CreateExplosion()
    {

        GameObject explosionGo = this.explosionGenerator.CreateExplosion();
        explosionGo.transform.position = this.transform.position;
        explosionGo.GetComponent<ExplosionController>().Explode();
    }
}
