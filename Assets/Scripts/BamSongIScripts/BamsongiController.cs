using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BamsongiController : MonoBehaviour
{
    private Rigidbody rbody;
    private ParticleSystem particleSystem;

    void Start()
    {
        this.rbody = this.GetComponent<Rigidbody>();      
        this.particleSystem = this.GetComponent<ParticleSystem>();
        Shoot();
    }

    private void Shoot()
    {
        this.rbody.AddForce(new Vector3(0, 200, 2000));
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.LogFormat("충돌 물체 : {0}", collision);
        this.rbody.isKinematic = true;

        this.particleSystem.Play();
    }
}
