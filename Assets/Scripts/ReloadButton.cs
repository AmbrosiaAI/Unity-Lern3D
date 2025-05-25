using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ReloadButton : MonoBehaviour
{

    private void ReloadGame()
    {
        Debug.Log("reloading...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void Start()
    {
        Button reload = GetComponent<Button>();
        reload.onClick.AddListener(ReloadGame);
    }
}
