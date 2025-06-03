using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{

    public float speed = 30f;
    public float damage = 40f;
    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }
    private void OnTriggerEnter (Collider collision)
    {
        if (collision != null)
        {
            Character character = collision.gameObject.GetComponent<Character>();
            if (character != null)
            {
                character.getDamage(damage);
            }
            Destroy(this.gameObject);
        }
    }
}
