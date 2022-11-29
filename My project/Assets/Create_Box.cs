using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create_Box : MonoBehaviour
{
    GameObject Box;
    void Start()
    {
        int x = 20, y = 40;
        for(int i = -x; i <= x; i++)
        {
            for(int j= -y;j <= y; j++)
            {
                Instantiate(Box, new Vector2(i, j), Quaternion.identity);
            }
        }
    }
}
