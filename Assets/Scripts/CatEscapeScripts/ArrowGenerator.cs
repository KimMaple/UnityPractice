using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowGenerator : MonoBehaviour
{
    [SerializeField] private GameObject arrowPrefab;
    private float delta;
    [SerializeField] private Image hpGauag;
    private GameObject arrowGo;
    private GameObject go;


    void Update()
    {
        arrowGo = GameObject.Find("arrow(Clone)");

        if (hpGauag.fillAmount > 0)
        {
            delta += Time.deltaTime; // ���� �����Ӱ� ���� ������ ���� �ð�
            //Debug.LogFormat("delta = {0}", delta);

            if (delta > 1.3) // 3�� ���� ũ�ٸ�
            {
                //����
                go = Object.Instantiate(this.arrowPrefab);
                // ��ġ �� ����
                float randx = Random.Range(-8, 9);    // -8~7

                go.transform.position
                    = new Vector3(randx, go.transform.position.y, go.transform.position.z);
                delta = 0;  // �ʱ�ȭ
            }
        }
        else if (hpGauag.fillAmount == 0)
        {
            Destroy(arrowGo);
        }
    }
}