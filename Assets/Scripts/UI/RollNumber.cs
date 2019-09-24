using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollNumber : MonoBehaviour {

    public int speed = 10;
    public bool isJumpping = false;

    public GameObject dice;

    private Rigidbody rb;
    // Use this for initialization
    void Start() {
        rb = dice.transform.GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update() {

    }

    public void MoveCube() {
        if (!isJumpping) {
            this.isJumpping = true;
            rb.AddForce(transform.up * 5);
            rb.AddTorque(Random.Range(0, 500), Random.Range(0, 500), Random.Range(0, 500));
            rb.velocity = Vector3.up * this.speed;
        }
    }


    private void OnCollisionEnter(Collision collision) {
        if (collision.transform.tag == "Ground") {
            this.isJumpping = false;
        }
    }

}