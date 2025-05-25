using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class character : MonoBehaviour
{
    public float maxHP = 100;
    public float currentHP;
    public GameObject GameOverPanel;
    public GameObject Camera;
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
        if (GetComponent<WanderingAI>() is WanderingAI ai)
            ai.enabled = false;

        this.gameObject.transform.Translate(0, -0.8f, 0);
        this.gameObject.transform.Rotate(-70, -38, 0);
        yield return new WaitForSeconds(1.5f);
        if (Camera != null) {
            Camera.transform.parent = null;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
                }
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