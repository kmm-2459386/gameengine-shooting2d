using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy4 : EnemyController
{
    float maxHP = 30f; // Enemy4 の最大HP
    protected override void Start()
    {
        
        base.Start();
    }
    private void Update()
    {
        // 画面外に出たらオブジェクトを破壊する
        if (transform.position.y < -6.0f)
        {
            Destroy(gameObject);
        }
    }
    protected override void Die()
    {
        // Enemy4 の死亡処理
        Destroy(gameObject);
    }
}
