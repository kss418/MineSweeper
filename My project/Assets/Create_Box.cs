using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create_Box : MonoBehaviour
{
    public GameObject Box;
    void Start()
    {
        float x = 15, y = 8;
        float Box_size = 0.2f;
        for(float i = -x; i <= x; i += Box_size)
        {
            for(float j= -y;j <= y; j += Box_size)
            {
                Instantiate(Box, new Vector2(i, j), Quaternion.identity);
            }
        }
    }
}
