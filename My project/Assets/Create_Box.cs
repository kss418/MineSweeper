using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create_Box : MonoBehaviour
{
    public GameObject Box;
    public int x = 15, y = 8;
    public float Box_size = 0.2f;

    public void Start()
    {
        for(float i = -x * Box_size ; i <= x * Box_size; i += Box_size)
        {
            for(float j= -y * Box_size;j <= y * Box_size; j += Box_size)
            {
                Instantiate(Box, new Vector2(i, j), Quaternion.identity);
            }
        }
    }
}
