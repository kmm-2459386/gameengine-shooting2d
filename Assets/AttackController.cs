using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    public Transform player; // プレイヤーオブジェクトのTransformを指定するためのフィールド
    public float damage = 10f; // 攻撃のダメージ量

    void Start()
    {
        if (player != null)
        {
            // プレイヤーの位置を取得して、このオブジェクトの位置に設定する
            transform.position = player.position;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // EnemyController を使用する
        EnemyController enemy = collision.gameObject.GetComponent<EnemyController>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage); // 敵にダメージを与える
            Destroy(gameObject); // 攻撃オブジェクトを破壊
        }
    }
        
    void Update()
    {
        // フレームごとに等速で上に飛ばす
        transform.Translate(0, 0.1f, 0);

        // 画面外に出たらオブジェクトを破壊する
        if (transform.position.y > 6.0f)
        {
            Destroy(gameObject);
        }
    }
}