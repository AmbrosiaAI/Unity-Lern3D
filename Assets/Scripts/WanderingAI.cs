using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class WanderingAI : MonoBehaviour
{
    public float speed = 3.0f;
    public float obstacleRange = 1.0f;
    [SerializeField] private GameObject fireballPrefab;
    private GameObject _fireball;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip hitAudioClip;
    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
        
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.SphereCast(ray, 1f, out hit))
        {
            PlayerMovable player = hit.collider.GetComponent<PlayerMovable>();
            if (player != null)
            {
                // Логика создания и направления Fireball
                if (_fireball == null)
                {
                    this.GetComponent<AudioSource>().PlayOneShot(hitAudioClip);
                    _fireball = Instantiate(fireballPrefab);
                    _fireball.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
                    _fireball.transform.rotation = transform.rotation;
                }
            }
            if (hit.distance < obstacleRange)
            {
                float angle = UnityEngine.Random.Range(-110, 110);
                transform.Rotate(0, angle, 0);
            }
        }
    }

}

