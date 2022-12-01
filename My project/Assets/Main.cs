using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    Camera Cam;
    Vector2 MousePosition;
    float MaxDistance = 15f;
    Text Bomb_Display;
    int Bomb_Count = 99;

    void Delete()
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

    void Display_Bomb_Count()
    {
        Bomb_Display.text = Bomb_Count.ToString();
    }

    void Flag()
    {
        if (Input.GetMouseButtonDown(1))
        {
            MousePosition = Input.mousePosition;
            MousePosition = Cam.ScreenToWorldPoint(MousePosition);
            RaycastHit2D hit = Physics2D.Raycast(MousePosition, transform.forward, MaxDistance);

            if (hit)
            {

            }
        }
    }

    void Start()
    {
        Bomb_Display = GameObject.Find("Bomb_Display").GetComponent<Text>();
        Cam = GetComponent<Camera>();
    }


    void Update()
    {
        Display_Bomb_Count();
        Delete();
        Flag();
    }
}
