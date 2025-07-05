using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    [SerializeField] private AudioClip hitAudioClip;
    [SerializeField] private AudioClip advertAudioClip;

    private void Start()
    {
        Messenger.AddListener(GameEvents.PlayerAttacking, PlaySound);
        Messenger.AddListener(GameEvents.PressE, PlayAdvertSound);
    }
    private void PlaySound()
    {
        Managers.AudioManager.PlaySound(hitAudioClip);
    }
    private void PlayAdvertSound()
    {
        Managers.AudioManager.PlaySound(advertAudioClip);
    }
}
