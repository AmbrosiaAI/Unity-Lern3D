using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioManager))]
[RequireComponent(typeof(InventoryManager))]
[RequireComponent(typeof(UIManager))]
public class Managers : MonoBehaviour
{
    public static AudioManager AudioManager { get; set; }
    public static InventoryManager InventoryManager { get; set; }
    public static UIManager UIManager { get; set; }

    private void Awake()
    {
        UIManager = GetComponent<UIManager>();
        AudioManager = GetComponent<AudioManager>();
        InventoryManager = GetComponent<InventoryManager>();
    }
}
