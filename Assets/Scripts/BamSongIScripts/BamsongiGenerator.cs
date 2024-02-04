using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BamsongiGenerator : MonoBehaviour
{
    [SerializeField] private GameObject BamsongiPrefeb;

    private List<GameObject> bamsongiGo = new List<GameObject>();

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            bamsongiGo.Add(Object.Instantiate(BamsongiPrefeb));
        }

        if(bamsongiGo.Count > 10)
        {
            bamsongiGo.Remove(BamsongiPrefeb);
        }
    }
}
