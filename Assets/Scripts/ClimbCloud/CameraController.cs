using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offSet;
    private Camera camera;

    private void Start()
    {
        this.player = GameObject.Find("cat");
        this.camera = GetComponent<Camera>();
        this.camera.orthographicSize = 3;
        offSet = this.transform.position;
    }

    void Update()
    {
        this.transform.position  = this.player.transform.position + offSet;
    }
}
