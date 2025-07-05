using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class GameEvents : MonoBehaviour
{
    public const string UpdateInventory = "UpdateInventory";
    public const string ColletableItem = "ColletableItem";
    public const string PlayerAttacking = "PlayerAttacking";
    public const string CoinCollected = "CoinCollected";
    public const string EnemyKilled = "EnemyKilled";
    public const string EnemyCountIncrease = "EnemyCountIncrease";
    public const string ShowPressE = "ShowPressE";
    public const string PressE = "PressE";
}
