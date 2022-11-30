using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create_Comp : MonoBehaviour
{
    public GameObject Bomb, Num;
    public int Bomb_Count = 99;
    public int[,] arr = new arr[16,30];
    void Create_Bomb(float x, float y)
    {
        while (Bomb_Count > 0)
        {
            for(float i = 0; i < 2 * x; i++)
            {
                for(float j = 0; j < 2 * y; j++)
                {
                    if (Bomb_Count == 0)
                    {
                        break;
                    }

                    int cur = Random.Range(0,6);
                    if(cur == 0)
                    {
                        arr[i, j] = 1;
                        Bomb_Count--;
                    }
                }
            }
        }
    }

    void Create_Num(float x, float y)
    {
        for(int i = 0; i < 2 * x; i++)
        {
            for(int j = 0; j < 2 * y; j++)
            {
                for(int l = -1;l <= 1; l++)
                {
                    for (int k = -1; k <= 1; k++)
                    {
                        if(l == 0 && k == 0)
                        {
                            continue;
                        }

                    }
                }
            }
        }
    }

    void Start()
    {
        float x = GameObject.Find("Box_Generater").GetComponent<Create_Box>().x;
        float y = GameObject.Find("Box_Generater").GetComponent<Create_Box>().y;
        float Box_size = GameObject.Find("Box_Generater").GetComponent<Create_Box>().Box_size;

        Create_Bomb(x, y, Box_size);
        Create_Num(x, y);
    }
}
