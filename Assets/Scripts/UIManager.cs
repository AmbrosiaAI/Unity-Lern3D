using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI CoinCountTMP;
    [SerializeField] TextMeshProUGUI EnemyCountTMP;
    [SerializeField] TextMeshProUGUI PressE;

    private void Start()
    {
        Messenger<int>.AddListener(GameEvents.CoinCollected, AddCoins);
        Messenger<int>.AddListener(GameEvents.EnemyCountIncrease, AddEnemy);
        Messenger<bool>.AddListener(GameEvents.ShowPressE, PressEControll);
    }

    private void AddCoins(int count)
    {
        CoinCountTMP.text = "Coins: " + count;
    }

    private void AddEnemy(int count)
    {
        EnemyCountTMP.text = "Kills: " + count;
    }

    private void PressEControll(bool state)
    {
        PressE.gameObject.SetActive(state);
        Debug.Log("Press E Control get " + state);
    }
}
