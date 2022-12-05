using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create_Comp : MonoBehaviour
{
    public GameObject Bomb, Num;
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
                if(cnt == 0)
                {
                    continue;
                }
                Instantiate(Num, new Vector3((i - x) * Box_size, (j - y) * Box_size, 0.5), Quaternion.identity);
            }
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
