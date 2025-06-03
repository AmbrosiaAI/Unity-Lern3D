using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    public static float Heal=25f;
    private float _heal = Heal*-1;
    
    private void OnTriggerEnter(Collider collision)
    {
        if (collision != null)
        {
            Character character = collision.gameObject.GetComponent<Character>();
            if (character != null)
            {
                character.getDamage(_heal);
                Destroy(this.gameObject);
            }
        }
    }
}
