using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

//모노 클래스 
public class App : MonoBehaviour
{
    [SerializeField] private Transform b; // child

    private void Start()
    {
        Debug.LogFormat("b.position: {0}", b.position); // world space
        Debug.LogFormat("b.localposition: {0}", b.localPosition); // local space
    }
}
