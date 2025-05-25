using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class character : MonoBehaviour
{
    public float maxHP = 100;
    public float currentHP;
    public GameObject GameOverPanel;
    private bool isDead = false;
    // Start is called before the first frame update

    public void getDamage(float damage)
    {
        currentHP -= damage;
        if (currentHP <= 0) 
        { 
            Debug.Log($"{this} is dead.");
            if (GameOverPanel != null)
            {
                GameOverPanel.SetActive(true);
            }
            StartCoroutine(Death());
        }
    }

    private IEnumerator Death()
    {
        this.gameObject.transform.Rotate(-75,-38,0);
        yield return new WaitForSeconds(1.5f);
        Destroy(this.gameObject);
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