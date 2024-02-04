using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeGenerator : MonoBehaviour
{
    [SerializeField] private GameObject lifePrefab;
    [SerializeField] private SpaceShipController player;

    private int playerHp;
    private List<GameObject> lifeList = new List<GameObject>();
    private List<Image> lifeImage = new List<Image>();
    private void Start()
    {
        playerHp = player.GetPlayerHp();

        this.StartCoroutine(CoHpUp(playerHp));
        this.StartCoroutine(CoHpDown(playerHp));
    }

    private IEnumerator CoHpUp(int hp)
    {
        lifeList.Add(Instantiate(lifePrefab));
        yield return null;
    }

    private IEnumerator CoHpDown(int hp)
    {
        if(hp > player.GetPlayerHp())
        {
            hp--;
            player.SetPlayerHp(hp);

        }
        yield return null;
    }


}
