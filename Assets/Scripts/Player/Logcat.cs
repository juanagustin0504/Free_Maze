using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logcat : LivingEntity
{
    [Header("Joystic")]
    public Joystick joystick;

    public LayerMask layerMask;

    private Rigidbody2D _rigid;

    private bool _isBlind = false;

    private int _passiveCnt = 3;

    private float xDistance, yDistance;

    private void Start() {
        _rigid = GetComponent<Rigidbody2D>();
        joystick = FindObjectOfType<Joystick>();
    }

    private void Update() {
        //JoysticMove();
        KeybordMove();
    }

    protected override void Passive() {
        if(_isBlind) {
            if(_passiveCnt > 0) {
                _isBlind = false;
            }
        }
    }


    void JoysticMove() {
        if (_playerHp == 0) return;
        Vector2 moveVec = joystick.GetInputVector(); // 조이스틱 이용하여 플레이어 이동

        Vector2 moveDirection = moveVec.normalized;
        Vector2 moveVelocity = moveDirection * _velocity;

        // 이동 관련 애니메이션
        /*_animator.SetFloat("DirX", moveVec.x);
        _animator.SetFloat("DirY", moveVec.y);
        */

/*      _playerHp 관련 애니메이션
        if (moveVec != Vector2.zero) { // 변경부분
            if (_playerHp != 0)
                _animator.SetBool("Walking", true);
            else
                _animator.SetBool("Walking", false);
        } else
            _animator.SetBool("Walking", false);*/

        Ray2D ray = new Ray2D(transform.position, moveDirection);

        RaycastHit2D rayHit = Physics2D.Raycast(ray.origin, ray.direction, (_velocity * Time.deltaTime) + 0.75f, layerMask);

        if (rayHit.collider == null) {
            transform.Translate(moveVelocity * Time.deltaTime, Space.World);
        }

        transform.Translate(moveVelocity * Time.deltaTime, Space.World);
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, -0.5f + xDistance, 52.5f - xDistance),
            Mathf.Clamp(transform.position.y, -0.5f + yDistance, 52.5f - yDistance),
            0);


    }
    void KeybordMove() {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        Vector2 moveVec = new Vector2(moveX, moveY);

        moveVec.x = Mathf.RoundToInt(moveVec.x);
        moveVec.y = Mathf.RoundToInt(moveVec.y);

        Vector2 moveDirection = moveVec.normalized;
        Vector2 moveVelocity = moveDirection * _velocity;
/*
        _animator.SetFloat("DirX", moveVec.x);
        _animator.SetFloat("DirY", moveVec.y);
*/
        /*if (moveVec != Vector2.zero) // 변경부분
            _animator.SetBool("Walking", true);
        else
            _animator.SetBool("Walking", false);*/

        transform.Translate(moveVelocity * Time.deltaTime, Space.World);
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, -0.5f, 52.5f),
            Mathf.Clamp(transform.position.y, -0.5f, 52.5f),
            0);


    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.transform.CompareTag("Wall"))
        {

        }
        
    }
}
