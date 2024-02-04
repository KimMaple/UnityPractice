using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RouletteController : MonoBehaviour
{
    // 1. 마우스 왼쪽 클릭을 하면
    // 2. 회전한다.
    [SerializeField] private float maxSpeed = 5;
    [SerializeField] private float attenuation = 0.96f;
    [SerializeField] private float speed = 0;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Button Down!!");
            speed = maxSpeed;
        }
        this.transform.Rotate(0, 0, speed);
        speed *= attenuation;
        Debug.LogFormat("speed = {0}", speed);
    }
}
