using System.Collections;

using System.Collections.Generic;

using UnityEngine;



public class PlayerCamera : MonoBehaviour
{
    public float smoothTimeX, smoothTimeY;

    public Vector2 velocity;

    public Vector2 minPos, maxPos;

    public bool bound;

    public static int pn = 0;

    private float xDistance, yDistance;
    private void Start() {
        Vector2 distance = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0));
        xDistance = distance.x;
        yDistance = distance.y;
    }

    // 캐릭터의 위에 따라 카메라가 이동하도록 하는 메서드

    void FixedUpdate()
    {

        transform.position = new Vector3(ArrangeManager.GetInstance().GetPlayer(pn).transform.position.x, ArrangeManager.GetInstance().GetPlayer(pn).transform.position.y, 0);
        transform.Translate(0, 0, -10); //카메라를 원래 z축으로 이동

        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, -0.5f + xDistance, 52.5f - xDistance),
            Mathf.Clamp(transform.position.y, -0.5f + yDistance, 52.5f - yDistance),
            -10);
    


        if (bound)
        {

            //Mathf.Clamp(현재값, 최대값, 최소값);  현재값이 최대값까지만 반환해주고 최소값보다 작으면 그 최소값까지만 반환합니다.

            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -0.5f + xDistance, 52.5f - xDistance),

                Mathf.Clamp(transform.position.y, -0.5f + yDistance, 52.5f + yDistance),

                -10

            );

        }

    }

}