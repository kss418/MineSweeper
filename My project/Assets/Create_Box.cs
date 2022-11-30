using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create_Box : MonoBehaviour
{
    public GameObject Box;
    public float x = 15, y = 8, Box_size = 0.2f;

    void Start()
    {
        for(float i = -x; i <= x; i += Box_size)
        {
            for(float j= -y;j <= y; j += Box_size)
            {
                Instantiate(Box, new Vector2(i, j), Quaternion.identity);
            }
        }
    }
}
