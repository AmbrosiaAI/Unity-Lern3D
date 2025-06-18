using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AppleManager : MonoBehaviour
{

    [SerializeField] private GameObject objectPrefab;
    private GameObject _object;
    public float max_X = 1;
    public float min_X = 0;
    public float max_Z = 1;
    public float min_Z = 0;
    void Update()
    {
        if (_object == null)
        {
            Vector3 spawnPosition = new Vector3(UnityEngine.Random.Range(min_X, max_X), this.transform.position.y, UnityEngine.Random.Range(min_Z, max_Z));
            //Vector3 spawnPosition = new Vector3 (0,0,0);

            if (!Physics.CheckSphere(spawnPosition, 3f, 1))
            {
                _object = Instantiate(objectPrefab) as GameObject;
                _object.transform.position = spawnPosition;
                float angle = UnityEngine.Random.Range(0, 360);
                _object.transform.Rotate(0, angle, 0);
            }
            else { Debug.Log($"Неправильный спавн объекта {objectPrefab}"); }
        }
    }
}