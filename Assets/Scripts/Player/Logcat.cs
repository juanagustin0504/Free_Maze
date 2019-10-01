using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logcat : LivingEntity
{

    

    private Rigidbody2D _rigid;

    private bool _isBlind = false;

    private int _passiveCnt = 3;

    

    private void Start() {
        _rigid = GetComponent<Rigidbody2D>();
    }

    private void Update() {
    }    

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.transform.CompareTag("Wall"))
        {

        }
        
    }
}
