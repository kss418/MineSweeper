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
    int alive = 1;
    public GameObject flag;
    RaycastHit2D[] hits;

    void Delete()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MousePosition = Input.mousePosition;
            MousePosition = Cam.ScreenToWorldPoint(MousePosition);
            hits = Physics2D.RaycastAll(MousePosition, transform.forward, MaxDistance);

            for(int i = 0; i < hits.Length; i++)
            {
                RaycastHit2D hit = hits[i];
                if(hit.collider.name == "Flag(Clone)")
                {
                    break;
                }

                else if (hit.collider.name == "Box(Clone)")
                {
                    Destroy(hit.collider.gameObject);
                }

                else if (hit.collider.name == "Bomb(Clone)")
                {
                    alive = 0;
                }
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
                if(hit.collider.name == "Flag(Clone)")
                {
                    Bomb_Count++;
                    Destroy(hit.collider.gameObject);
                }
                else if(hit.collider.name == "Box(Clone)")
                {
                    Bomb_Count--;
                    float Box_size = GameObject.Find("Box_Generater").GetComponent<Create_Box>().Box_size;
                    float x = (int)(5 * (MousePosition.x - 0.1f));
                    float y = (int)(5 * (MousePosition.y - 0.1f));
                    x *= Box_size;
                    y *= Box_size;
                    Instantiate(flag, new Vector3(x, y, -1), Quaternion.identity);
                }
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
        if (alive == 1)
        {
            Display_Bomb_Count();
            Delete();
            Flag();
        }
        else
        {

        }
    }
}
