using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CharacterController))]
public class character : MonoBehaviour
{
    public float maxHP = 100;
    public float currentHP;
    public GameObject GameOverPanel;
    private bool isDead = false;
    // Start is called before the first frame update

    void getDamage(float damage)
    {
        currentHP -= damage;
        if (currentHP <= 0) 
        { 
            Debug.Log($"{this} is dead."); 
            GameOverPanel.SetActive(true);
            Destroy(gameObject); 
        }
    }
    void Start()
    {
        currentHP = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead) { getDamage(10 * Time.deltaTime); }
    }
}