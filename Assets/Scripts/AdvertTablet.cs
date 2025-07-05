using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvertTablet : MonoBehaviour
{
    [SerializeField] private float Radius = 5f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            Messenger<bool>.Broadcast(GameEvents.ShowPressE, true);

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            Messenger<bool>.Broadcast(GameEvents.ShowPressE, false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
            if (Input.GetKeyDown(KeyCode.E))
                Messenger.Broadcast(GameEvents.PressE);
    }
}
