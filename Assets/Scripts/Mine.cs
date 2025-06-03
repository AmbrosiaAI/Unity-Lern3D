using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision != null)
        {
            Character character = collision.gameObject.GetComponent<Character>();
            if (character != null)
            {
                character.getDamage(character.currentHP/2);
                Destroy(this.gameObject);
            }
        }
    }
}
