using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create_Comp : MonoBehaviour
{
    public GameObject Bomb, Num;
    public int Bomb_Count = 99;

    void Create_Bomb(float x, float y, float Box_size)
    {
        while (Bomb_Count > 0)
        {
            for(float i = -x; i <= x; i += Box_size)
            {
                for(float j = -y; j <= y; j += Box_size)
                {
                    Bomb_Count--;
                }
            }
        }
    }

    void Create_Num()
    {

    }

    void Start()
    {
        float x = GameObject.Find("Box_Generater").GetComponent<Create_Box>().x;
        float y = GameObject.Find("Box_Generater").GetComponent<Create_Box>().y;
        float Box_size = GameObject.Find("Box_Generater").GetComponent<Create_Box>().Box_size;

        Create_Bomb(x, y, Box_size);
        Create_Num();
    }
}
