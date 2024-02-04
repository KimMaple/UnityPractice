using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatEscapeGameDirector : MonoBehaviour
{
    [SerializeField] private Image hpGauag;
    private GameObject hpGo;
    private Text hpText;
    private float hp;
    [SerializeField] private float arrowDamage = 25f;

    private void Start()
    {
        this.hpGo = GameObject.Find("hp");
        this.hpText = hpGo.GetComponent<Text>();
    }

    private void Update()
    {
        this.hp = Mathf.RoundToInt(this.hpGauag.fillAmount * 100);
        this.hpText.text = $"남은 체력 : {this.hp} " +
            $"\n {Time.realtimeSinceStartup:0.00}";

        if (this.hp == 0)
        {
            this.hpText.text = "죽었어요.";
        }

        if( Time.realtimeSinceStartup > 30) 
        {
            this.arrowDamage = 50f;
        }
    }

    public void DecreaseHP()
    {
        this.hpGauag.fillAmount -= (arrowDamage * 0.01f);
        if (this.hpGauag.fillAmount < 0)
        {
            this.hpGauag.fillAmount = 0;
        }
    }
}
