using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : EnemyController
{
    float maxHP = 60f; // Enemy1 の最大HP
    public int damage = 30; // プレイヤーに与えるダメージ量
    protected override void Start()
    {
        base.Start(); // 基底クラスの Start メソッドを呼び出す
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
        // Enemy1 の死亡処理
        Destroy(gameObject); // ゲームオブジェクトを破壊
    }
        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();

                if (playerHealth != null)
                {
                    playerHealth.TakeDamage(damage);  // プレイヤーにダメージを与える
                }
                Destroy(gameObject);
            }
        }
    }