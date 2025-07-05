using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectItem : MonoBehaviour
{
    private Coroutine destroyCoroutine;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //Managers.InventoryManager.Increase();

            if (destroyCoroutine == null)
            {
                Messenger.Broadcast(GameEvents.ColletableItem);
                destroyCoroutine = StartCoroutine(Destroy());
            }
        }
    }

    private IEnumerator Destroy()
    {
        yield return new WaitForSeconds(1.0f);
        Destroy(gameObject);
    }
}
