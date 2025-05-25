using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShooter : MonoBehaviour
{
    private Camera _camera;

    private IEnumerator SphereIndicator(Vector3 pos)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = pos;
        for (float i = 3; i >= 0; i--)
        {
            yield return new WaitForSeconds(1);
            Debug.Log($"До удаления осталось {i} секунд.");
        }
        Destroy(sphere);
        yield return null;
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
            Vector3 point = new Vector3(
                _camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);
            Ray ray = _camera.ScreenPointToRay(point);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {

                if (hit.collider != null)
                {
                    character enemy = hit.collider?.GetComponent<character>();
                    if (enemy != null)
                    {
                        enemy.getDamage(50);
                    } else { StartCoroutine(SphereIndicator(hit.point)); }
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
