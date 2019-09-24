using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    float posX = 0;
    float posY = 0;

    float mapWidth = 100;
    float mapHeight = 100;
    float blockWidth = 0.8f;
    float blockHeight = 0.8f;

    // Start is called before the first frame update
    void Start()
    {
        while (true)
        {
            Instantiate(Resources.Load("Prefabs/walls/wall_wood"), new Vector3(posX, posY, 0), Quaternion.identity);

            posX += blockWidth;

            if (posX > mapWidth)
            {
                posX = 0f;
                break;
            }

        }


        while (true)
        {
            Instantiate(Resources.Load("Prefabs/walls/wall_wood"), new Vector3(posX, posY, 0), Quaternion.identity);

            posY += blockHeight;

            if (posY > mapHeight)
            {
                posY = 0f;
                break;
            }

        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
