using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour
{
    private float duration = 0.5f;

    public void Explode()
    {
        StartCoroutine(this.CoExplode());
    }

    private IEnumerator CoExplode()
    {
        yield return new WaitForSeconds(duration);

        Destroy(gameObject);
    }
}
