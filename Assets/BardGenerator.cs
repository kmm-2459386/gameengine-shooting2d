using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BardGenerator : MonoBehaviour
{
    public GameObject projectilePrefab;  // 攻撃のプレハブ（弾など）
    public Transform attackPoint;        // 攻撃を発射する位置
    public float attackRate = 2f;        // 攻撃の間隔（秒）

    private float nextAttackTime = 0f;

    void Update()
    {
        // 現在の時間が次の攻撃時間を過ぎていれば攻撃する
        if (Time.time >= nextAttackTime)
        {
            Attack();
            nextAttackTime = Time.time + 1f / attackRate;
        }
    }

    void Attack()
    {
        // 攻撃を発射する
        if (projectilePrefab != null && attackPoint != null)
        {
            Instantiate(projectilePrefab, attackPoint.position, attackPoint.rotation);
        }
    }
}