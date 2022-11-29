using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    Camera Cam;
    Vector2 MousePosition;
    float MaxDistance = 15f;

    void Start()
    {
        Cam = GetComponent<Camera>();
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MousePosition = Input.mousePosition;
            MousePosition = Cam.ScreenToWorldPoint(MousePosition);
            RaycastHit2D hit = Physics2D.Raycast(MousePosition, transform.forward, MaxDistance);

            if (hit)
            {
                Destroy(hit.collider.gameObject);
            }
        }
    }
}
