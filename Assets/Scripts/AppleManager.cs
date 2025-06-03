using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AppleManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    private GameObject _apple;
    void Update()
    {
        if (_apple == null)
        {
            _apple = Instantiate(enemyPrefab) as GameObject;
            _apple.transform.position = new Vector3(UnityEngine.Random.Range(-9, 8), this.transform.position.y, UnityEngine.Random.Range(-15, 1));
            float angle = UnityEngine.Random.Range(0, 360);
            _apple.transform.Rotate(0, angle, 0);
        }
    }
}