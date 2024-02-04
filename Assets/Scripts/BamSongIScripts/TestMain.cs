using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMain : MonoBehaviour
{
    [SerializeField] private GameObject bamsongiPrefeb;
    private Rigidbody rbody;


    private GameObject bamGo;
    private Vector3 dir = new Vector3(0, 0, -10);

    private void Start()
    {
        rbody = bamsongiPrefeb.AddComponent<Rigidbody>();
    }
    void Update()
    {
        // 화면의 좌표를 출력하자
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log(Input.mousePosition);

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //Debug.DrawRay(ray.origin, ray.direction, Color.red, 10f);

            DrawArrow.ForDebug(ray.origin, ray.direction, 10, Color.red, ArrowType.Solid);
            bamsongiPrefeb.transform.position = ray.origin + dir;
            rbody.AddForce(ray.direction);
            bamGo = Object.Instantiate(this.bamsongiPrefeb);
        }
    }
}
