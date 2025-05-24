using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class character : MonoBehaviour
{
    public float maxHP = 100;
    public float currentHP;
    private bool isDead = false;
    // Start is called before the first frame update

    void getDamage(float damage)
    {
        currentHP -= damage;
        if (currentHP <= 0) { Debug.Log($"{this} is dead."); Destroy(gameObject); }
    }
    void Start()
    {
        currentHP = maxHP;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
