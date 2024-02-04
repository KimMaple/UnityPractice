using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameDirector : MonoBehaviour
{
    private GameObject carGo;
    private GameObject flagGo;
    private GameObject distanceGo;
    private Text distanceText;
    

    // Start is called before the first frame update
    void Start()
    {
        this.carGo = GameObject.Find("car");
        Debug.LogFormat("this.carGo : {0}", this.carGo);  // car ���� ������Ʈ�� �ν��Ͻ�
        
        this.flagGo = GameObject.Find("flag");
        Debug.LogFormat("this.flagGo : {0}", this.flagGo);  // car ���� ������Ʈ�� �ν��Ͻ�
        
        this.distanceGo = GameObject.Find("distance");
        Debug.LogFormat("this.distanceGo: {0}", this.distanceGo);

        this.distanceText = distanceGo.GetComponent<Text>();
        Debug.LogFormat("distanceText: {0}", distanceText);

    }

    // Update is called once per frame
    void Update()
    {
        float length = this.flagGo.transform.position.x - 
            this.carGo.transform.position.x;
        Debug.Log(length);
        this.distanceText.text = $"���� �Ÿ� : {length:0.0}";
        if (length <= 0)
        {
            this.distanceText.text = "����!!";
        }
    }
}
