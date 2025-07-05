using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShooter : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    private Camera _camera;
    public float reloadTime = 1f;
    public Material material;
    private bool onReload = false;
    private IEnumerator SphereIndicator(Vector3 pos)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.GetComponent<Renderer>().material = material;
        sphere.GetComponent<Collider>().enabled = false;
        sphere.transform.position = pos;
        for (float i = 3; i >= 0; i--)
        {
            yield return new WaitForSeconds(1);
            Debug.Log($"До удаления осталось {i} секунд.");
        }
        Destroy(sphere);
        yield return null;
    }

    private IEnumerator relaod()
    {
        yield return new WaitForSeconds(reloadTime);
        onReload = false;

    }

    private void Start()
    {
        _camera = GetComponent<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!onReload)
            {
                Messenger.Broadcast(GameEvents.PlayerAttacking);
                onReload = true;
                StartCoroutine(relaod());

                Vector3 point = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);
                Ray ray = _camera.ScreenPointToRay(point);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    
                    if (hit.collider != null)
                    {
                        Character enemy = hit.collider?.GetComponent<Character>();
                        if (enemy != null)
                        {
                            enemy.getDamage(50);
                        }
                        else { StartCoroutine(SphereIndicator(hit.point)); }
                    }
                }
            }
        }
    }
    private void OnGUI()
    {
        int size = 12;
        float posX = _camera.pixelWidth / 2 - size / 4;
        float posY = _camera.pixelHeight / 2 - size / 2;
        GUI.Label(new Rect(posX, posY, size, size), "*");
    }
}
