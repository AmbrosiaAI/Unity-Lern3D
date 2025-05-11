using UnityEngine;

public class Rotate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start game");
    }

    bool UpDownSwitch = false;
    // Update is called once per frame
    void Update()
    {
        if (transform.position.y >= 10) { UpDownSwitch = false; }
        else if (transform.position.y <= 0) { UpDownSwitch = true; }
        switch (UpDownSwitch)
        {
            case true:
                transform.Translate(0, 0.01f, 0);
            break;
            case false:
                transform.Translate(0, -0.01f, 0);
            break;
        }

        transform.Rotate(0, 10 / 60f, 0);
    }
}
