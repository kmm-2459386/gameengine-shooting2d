using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : EnemyController
{
    public GameObject BardPrefab;
    float span = 5.0f;
    float delta = 0;
    public int damage = 15; // プレイヤーに与えるダメージ量
    float maxHP = 50f; // Enemy3 の最大HP
    protected override void Start()
    {
        
        base.Start();
    }
    void Update()
    {
        
            this.delta += Time.deltaTime;
            if (this.delta > this.span)
            {
                this.delta = 0;
                GameObject go = Instantiate(BardPrefab);
            go.transform.position = new Vector3(transform.position.x, transform.position.y, 0);
            }
        
            // 画面外に出たらオブジェクトを破壊する
            if (transform.position.y < -6.0f)
            {
                Destroy(gameObject);
            }
        
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
    protected override void Die()
    {
        // Enemy3 の死亡処理
        Destroy(gameObject);
    }
}
