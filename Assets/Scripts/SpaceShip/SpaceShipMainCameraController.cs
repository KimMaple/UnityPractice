using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipMainCameraController : MonoBehaviour
{
    [SerializeField] private Transform player;

    float cameraSpeed = 1f;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3
            (this.transform.position.x,
            this.transform.position.y + cameraSpeed * Time.deltaTime,
            this.transform .position.z);
    }
}
