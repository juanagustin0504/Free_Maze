using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ControllerScript :  LivingEntity
{

    public Joystick joystick;

    private Vector3 _moveVector;
    private Transform _transform;

    public LayerMask layerMask;

    private float xDistance, yDistance;

    // Use this for initialization
    void Start()
    {
        _transform = transform;
        _moveVector = Vector3.zero;
        joystick = FindObjectOfType<Joystick>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
    }

    private void FixedUpdate()
    {
        JoysticMove();
    }

    public void HandleInput()
    {
        _moveVector = poolInput();
    }

    public Vector3 poolInput()
    {
        float h = joystick.GetHorizontalValue();
        float v = joystick.GetVerticalValue();
        Vector3 moveDir = new Vector3(h, v, 0).normalized;

        return moveDir;
    }

    void JoysticMove() {
        if (_playerHp == 0) return;
        
        Vector2 moveDirection = _moveVector.normalized;
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
     void OnCollisionEnter2D(Collision2D other)
   {
        if(other.transform.CompareTag("Goal"))
        SceneManager.LoadScene(2);
   }

}