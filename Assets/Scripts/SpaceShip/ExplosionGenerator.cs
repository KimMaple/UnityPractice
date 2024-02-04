using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionGenerator : MonoBehaviour
{
    [SerializeField] private GameObject prefab;

    public GameObject CreateExplosion()
    {
        return Instantiate(prefab);
    }
}
