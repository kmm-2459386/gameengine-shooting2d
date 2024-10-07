using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyController : MonoBehaviour
{
    public float maxHP = 10f; // 最大HP
    protected float currentHP; // 現在のHP
    public int Damage = 30;
    public GameObject HeartHealPrefab;
    int healdrop = 1;

    protected virtual void Start()
    {
        currentHP = maxHP; // ゲーム開始時のHPを設定
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if(playerHealth != null)
            {
                playerHealth.TakeDamage(Damage);
            }
            Destroy(gameObject);
        }
    }
    public void TakeDamage(float damage)
    {
        currentHP -= damage; // ダメージを受けてHPを減らす
        if (currentHP <= 0)
        {
            DropItem();
            Die(); // HPが0以下になったら死亡処理
        }
            
    }
    public void DropItem()
    {
        if (currentHP <= 0)
        {
            int random = Random.Range(1, 7);
            if (this.healdrop == random)
            {
                GameObject go = Instantiate(HeartHealPrefab);
                go.transform.position = new Vector3(transform.position.x, transform.position.y, 0);
            }
        }

    }

    protected abstract void Die(); // 死亡処理を各敵で実装する
}