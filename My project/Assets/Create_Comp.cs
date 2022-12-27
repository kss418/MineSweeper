using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Create_Comp : MonoBehaviour
{
    public GameObject One,Two,Three,Four,Five,Six,Seven,Eight;
    public GameObject Bomb;
    public int Bomb_Count = 99;
    public int[,] arr = new int[40,40];
    public int[,] num_list = new int[40,40];

    void Create_Bomb(int x,int y,float Box_size)
    {
        for(int i = 0; i < 2 * x; i++)
        {
            for (int j = 0; j < 2 * y; j++)
            {
                arr[i, j] = 0;
            }
        }

        while (Bomb_Count > 0)
        {
            for(int i = 0; i < 2 * x; i++)
            {
                for(int j = 0; j < 2 * y; j++)
                {
                    if (Bomb_Count == 0)
                    {
                        break;
                    }

                    if (arr[i,j] == 1)
                    {
                        continue;
                    }

                    int cur = Random.Range(0,6);
                    if(cur == 0)
                    {
                        arr[i, j] = 1;
                        Instantiate(Bomb, new Vector3((i - x) * Box_size, (j - y) * Box_size, 1), Quaternion.identity);
                        Bomb_Count--;
                    }
                }
            }
        }
    }

    void Create_Num(int x, int y, float Box_size)
    {
        for(int i = 0; i < 2 * x; i++)
        {
            for(int j = 0; j < 2 * y; j++)
            {
                if (arr[i,j] == 1)
                {
                    continue;
                }

                int cnt = 0;
                for(int l = -1;l <= 1; l++)
                {
                    for (int k = -1; k <= 1; k++)
                    {            
                        if(l == 0 && k == 0)
                        {
                            continue;
                        }

                        if(l + i < 0 || j + k < 0)
                        {
                            continue;
                        }

                        if(l + i > 2 * x || j + k > 2 * y)
                        {
                            continue;
                        }

                        if (arr[i + l ,j + k] == 1)
                        {
                            cnt++;
                        }
                    }
                }
                
                num_list[i, j] = cnt;
                if (cnt == 0)
                {
                    continue;
                }
                else {
                    if (cnt == 1)
                    {
                        Instantiate(One, new Vector3((i - x) * Box_size, (j - y) * Box_size, 1), Quaternion.identity);
                    }
                    else if (cnt == 2)
                    {
                        Instantiate(Two, new Vector3((i - x) * Box_size, (j - y) * Box_size, 1), Quaternion.identity);
                    }
                    else if (cnt == 3)
                    {
                        Instantiate(Three, new Vector3((i - x) * Box_size, (j - y) * Box_size, 1), Quaternion.identity);
                    }
                    else if (cnt == 4)
                    {                       
                        Instantiate(Four, new Vector3((i - x) * Box_size, (j - y) * Box_size, 1), Quaternion.identity);
                    }
                    else if (cnt == 5)
                    {
                        Instantiate(Five, new Vector3((i - x) * Box_size, (j - y) * Box_size, 1), Quaternion.identity);
                    }
                    else if (cnt == 6)
                    {
                        Instantiate(Six, new Vector3((i - x) * Box_size, (j - y) * Box_size, 1), Quaternion.identity);
                    }
                    else if (cnt == 7)
                    {
                        Instantiate(Seven, new Vector3((i - x) * Box_size, (j - y) * Box_size, 1), Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(Eight, new Vector3((i - x) * Box_size, (j - y) * Box_size, 1), Quaternion.identity);
                    }
                }
            }
        }
    }

    void refresh()
    {
        if (Input.GetKey(KeyCode.F5))
        {
            GameObject.Find("Box_Generator").GetComponent<Create_Box>().Start();
            GameObject.Find("Main Camera").GetComponent<Main>().alive = 1;
        }
    }

    void Start()
    {
        int x = GameObject.Find("Box_Generater").GetComponent<Create_Box>().x;
        int y = GameObject.Find("Box_Generater").GetComponent<Create_Box>().y;
        float Box_size = GameObject.Find("Box_Generater").GetComponent<Create_Box>().Box_size;

        Create_Bomb(x, y, Box_size);
        Create_Num(x, y, Box_size);
    }
}
