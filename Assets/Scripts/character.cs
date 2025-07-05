using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float maxHP = 100;
    public float currentHP;
    public Canvas canvas;
    private GameObject GameOverPanel;
    private TMP_Text HPBar;
    public GameObject Camera;
    private bool isDead = false;
    
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
        if (GetComponent<WanderingAI>() is WanderingAI ai)
        {
            Messenger.Broadcast(GameEvents.EnemyKilled);
            ai.enabled = false;

            this.gameObject.transform.Translate(0, -0.8f, 0);
            this.gameObject.transform.Rotate(-70, -38, 0);
            yield return new WaitForSeconds(1.5f);
        }
        if (Camera != null)
        {
            Camera.GetComponent<RayShooter>().enabled = false;
            Camera.GetComponent<PlayerRotation>().enabled = false;
            Camera.transform.parent = null;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        Destroy(this.gameObject);
    }
    void Start()
    {
        currentHP = maxHP;
        if (canvas != null)
        {
            GameOverPanel = canvas.transform.Find("GameOverPanel").gameObject;
            HPBar = canvas.transform.Find("HPBar").GetComponent<TextMeshProUGUI>();
        }

    }

    void Update()
    {
        if (canvas != null)
        {
            HPBar.text = $"{currentHP}/100";
        }
        if (currentHP > maxHP) currentHP = maxHP;
    }
}
