using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet1Generator : MonoBehaviour
{

    [SerializeField] GameObject bulletPrefeb;
    private GameObject go;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            go = Object.Instantiate(bulletPrefeb);
        }
    }
}
