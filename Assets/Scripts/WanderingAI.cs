using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class WanderingAI : MonoBehaviour
{
    public float speed = 3.0f;
    public float obstacleRange = 2.0f;
    [SerializeField] private GameObject fireballPrefab;
    private GameObject _fireball;
    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
        
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.SphereCast(ray, 1.75f, out hit))
        {
            PlayerMovable playerMove = hit.collider.GetComponent<PlayerMovable>();
            Character character = hit.collider.GetComponent<Character>();


            if (character != null)
            {
                // Логика создания и направления Fireball
                if (_fireball == null)
                {
                    _fireball = Instantiate(fireballPrefab);
                    _fireball.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
                    _fireball.transform.rotation = transform.rotation;
                }
            }
            else
            if (hit.distance < obstacleRange)
            {
                float angle = UnityEngine.Random.Range(-110, 110);
                transform.Rotate(0, angle, 0);
            }
        }
    }

}

