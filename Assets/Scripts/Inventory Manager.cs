using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    private int coinCount = 0;
    private int enemyCount = 0;

    private void Start()
    {
        Messenger.AddListener(GameEvents.ColletableItem, IncreaseCoin);
        Messenger.AddListener(GameEvents.EnemyKilled, IncreaseEnemy);
    }
    public void IncreaseCoin()
    {
        coinCount++;
        Messenger<int>.Broadcast(GameEvents.CoinCollected, coinCount);
    }

    public void IncreaseEnemy()
    {
        enemyCount++;
        Messenger<int>.Broadcast(GameEvents.EnemyCountIncrease, enemyCount);
    }
}
