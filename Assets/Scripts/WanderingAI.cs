using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingAI : MonoBehaviour
{
    public float speed = 3.0f;
    public float obstracleRange = 2.0f;

    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
        
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.SphereCast(ray, 0.75f, out hit))
        {
            if ((hit.distance < obstracleRange) && !hit.collider?.GetComponent<CharacterController>())
            {
                float angle = Random.Range(-110, 110);
                transform.Rotate(0, angle, 0);
            }
        }
    }
}

