using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Enemy2 : EnemyController
{
    public int damage = 45; // �v���C���[�ɗ^����_���[�W��
    public GameObject HeartHealPrefab;
    int healdrop = 8;
    float maxHP = 200f; // Enemy2 �̍ő�HP
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
                playerHealth.TakeDamage(damage);  // �v���C���[�Ƀ_���[�W��^����
            }
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        // ��ʊO�ɏo����I�u�W�F�N�g��j�󂷂�
        if (transform.position.y < -6.0f)
        {
            Destroy(gameObject);
        }
    }
    protected override void Die()
    {
        
        // Enemy2 �̎��S����
        Destroy(gameObject);
    
    }
}
