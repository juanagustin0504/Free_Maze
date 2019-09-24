using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LivingEntity : MonoBehaviour
{
    protected int _playerHp = 3;

    [SerializeField]
    protected float _velocity = 5f;

    protected abstract void Passive();

    public void DoAnimation() {

    }

    protected void Hit(int dmg) {
        _playerHp -= dmg;
        Die();
    }

    private void Die() {
        if (_playerHp <= 0) {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        
    }

}
