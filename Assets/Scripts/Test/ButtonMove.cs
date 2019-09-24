using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMove : MonoBehaviour
{ 
    public Logcat player;
    public float speed;
    public bool a,b,c,d;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Logcat>();
    }
    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void Move() {
        if (a) {
            player.transform.position += Vector3.right * speed * Time.deltaTime;
        }
        if (b) {
            player.transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if (c) {
            player.transform.position += Vector3.down * speed * Time.deltaTime;
        }
        if (d) {
            player.transform.position += Vector3.up * speed * Time.deltaTime;
        }
    }
    
    public void Right()
    {
        a = false;
    }
    public void RightDown()
    {
        a = true;
    }
    public void Left()
    {
        b = false;
    }
    public void LeftDown()
    {
        b = true;
    }
    public void Down()
    {
        c = false;
    }
    public void ContraryDown()
    {
        c = true;
    }
    public void Up()
    {
        d = false;
    }
    public void ContraryUp()
    {
        d = true;
    }

    
}
