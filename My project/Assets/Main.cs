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
    RaycastHit2D[] hits, hits2, hits3;

    void Delete()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MousePosition = Input.mousePosition;
            MousePosition = Cam.ScreenToWorldPoint(MousePosition);
            hits = Physics2D.RaycastAll(MousePosition, transform.forward, MaxDistance);
            int Box_Check = 0;

            for(int k = 0; k < hits.Length; k++)
            {
                RaycastHit2D hit = hits[k];
                if(hit.collider.name == "Flag(Clone)")
                {
                    break;
                }

                else if (hit.collider.name == "Box(Clone)")
                {
                    Destroy(hit.collider.gameObject);
                    Box_Check = 1;
                    if(hits.Length == 1)
                    {
                        List<List<float>> vector = new List<List<float>>();
                        vector.Add(new List<float> { MousePosition.x, MousePosition.y });
                        while (vector.Count > 0)
                        {
                            List<float> cur = vector[0];
                            vector.RemoveRange(0, 1);
                            float[] curx = { 0, 0, -0.2f, 0.2f };
                            float[] cury = { -0.2f, 0.2f, 0, 0 };
                            for (int i = 0; i < 4; i++)
                            {
                                hits3 = Physics2D.RaycastAll(new Vector2(cur[0] + curx[i], cur[1] + cury[i]), transform.forward, MaxDistance);
                                if (hits3.Length == 1 && hits3[0].collider.name == "Box(Clone)")
                                {
                                    Destroy(hits3[0].collider.gameObject);
                                    vector.Add(new List<float> { cur[0] + curx[i], cur[1] + cury[i] });
                                }
                                else if(hits3.Length == 2 && hits3[0].collider.name== "Box(Clone)" && hits3[1].collider.name == "Num(Clone)")
                                {
                                    Destroy(hits3[0].collider.gameObject);
                                }
                            }
                        }
                    }
                }

                else if (hit.collider.name == "Bomb(Clone)")
                {
                    alive = 0;
                }

                else if (hit.collider.name == "Num(Clone)" && Box_Check == 0)
                {
                    int cnt = 0;
                    for (float i = -0.2f; i <= 0.2f; i += 0.2f)
                    {
                        for (float j = -0.2f; j <= 0.2f; j += 0.2f)
                        {
                            RaycastHit2D curhit = Physics2D.Raycast(MousePosition, transform.forward, MaxDistance);
                            if(curhit.collider.name == "Flag(Clone)")
                            {
                                cnt++;
                            }
                        }
                    }

                    for (float i = -0.2f;i <= 0.2f; i += 0.2f)
                    {
                        for (float j = -0.2f; j <= 0.2f; j += 0.2f)
                        {
                            hits2 = Physics2D.RaycastAll(new Vector2(MousePosition.x + i,MousePosition.y + j), transform.forward, MaxDistance);
                            for (int l = 0; l < hits2.Length; l++)
                            {
                                RaycastHit2D hit2 = hits2[l];
                                if (hit2.collider.name == "Flag(Clone)")
                                {
                                    break;
                                }

                                else if (hit2.collider.name == "Box(Clone)")
                                {
                                    Destroy(hit2.collider.gameObject);
                                }

                                else if (hit2.collider.name == "Bomb(Clone)")
                                {
                                    alive = 0;
                                }
                            }
                        }
                    }
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
                    float x = (int)(5 * (MousePosition.x));
                    float y = (int)(5 * (MousePosition.y));
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
