using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeMake : MonoBehaviour
{
    [SerializeField] public static int mapSize = 51;
    int[,] maze;
    int cnt = 0;

    [SerializeField]
    GameObject wallObject;

    [SerializeField]
    GameObject groundObject;

    [SerializeField]
    GameObject GoalObject;



    // Start is called before the first frame update
    void Start()
    {
        int endNum = ((mapSize + 1) / 2) * ((mapSize + 1) / 2) - 1;

        maze = new int[mapSize + 2, mapSize + 2];

        while(endNum > cnt) {
            int x = Random.Range(0, (mapSize + 1) / 2) * 2;
            int y = Random.Range(0, (mapSize + 1) / 2) * 2;

            if (cnt == 0) maze[x + 1, y + 1] = 1;
            if (maze[x + 1, y + 1] == 1) WallDig(x, y, 0);
        }


        Output();

        Instantiate(GoalObject, new Vector3(mapSize, mapSize, 0), Quaternion.identity);

    }

    void WallDig(int x, int y, int oldVec) {
        int[] vx = { 0, 2, 0, -2 };
        int[] vy = { -2, 0, 2, 0 };

        bool retFlg = false;

        int r = Random.Range(0, 4);

        if (r == 0 && y <= 0) retFlg = true;
        if (r == 1 && (x + 2) >= mapSize) retFlg = true;
        if (r == 2 && (y + 2) >= mapSize) retFlg = true;
        if (r == 3 && x <= 0) retFlg = true;

        if(retFlg) {
            WallDig(x, y, oldVec);
            return;
        }

        if (maze[x + 1 + vx[r], y + 1 + vy[r]] == 0) {
            maze[x + 1 + vx[r], y + 1 + vy[r]] = 1;
            maze[x + 1 + vx[r] / 2, y + 1 + vy[r] / 2] = 1;
            cnt++;

            WallDig(x + vx[r], y + vy[r], r);
        }
    }
    
    void Output() {
        GameObject obj = new GameObject();
        obj.name = "Maze";

        for(int x = 0; x < mapSize + 2; x++) {
            for(int y = 0; y < mapSize + 2; y++) {
                if(maze[x, y] == 0) {
                    Instantiate(wallObject, new Vector3(x, y, 0), Quaternion.identity).transform.parent = obj.transform;

                } else {
                    Instantiate(groundObject, new Vector3(x, y, 0), Quaternion.identity).transform.parent = obj.transform;
                }
            }
        }
    }
}
