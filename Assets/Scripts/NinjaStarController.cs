using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaStarController : MonoBehaviour
{
    private float speed = 0;
    private float divide = 4000;
    private float rotateSpeed = 0;
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {           
            //this.transform.Translate(���� * �ӵ� * �ð�, ��ǥ��(���� ���ϸ� ����));
            
            rotateSpeed = 50;
        }
        this.transform.Translate(Vector3.up * 1 * Time.deltaTime, Space.World);
        this.transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
    }
}
