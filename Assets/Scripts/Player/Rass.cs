using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rass : LivingEntity
{
    private Transform _treasurePos;

    private void Start() {
        _treasurePos = GameObject.FindGameObjectWithTag("treasure").transform;
    }

    protected override void Passive() {
        // 화살표 UI 방향을 treasurePos 방향으로
    }
}
