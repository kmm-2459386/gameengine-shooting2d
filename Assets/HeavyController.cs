using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Enemy2 : EnemyController
{
    public int damage = 45; // プレイヤーに与えるダメージ量
    public GameObject HeartHealPrefab;
    int healdrop = 8;
    float maxHP = 200f; // Enemy2 の最大HP
    protected override void Start()
    {
        
        base.Start();
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
        
        // Enemy2 の死亡処理
        Destroy(gameObject);
    
    }
}
