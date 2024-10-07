using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : EnemyController
{
    float maxHP = 60f; // Enemy1 �̍ő�HP
    public int damage = 30; // �v���C���[�ɗ^����_���[�W��
    protected override void Start()
    {
        base.Start(); // ���N���X�� Start ���\�b�h���Ăяo��
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
        // Enemy1 �̎��S����
        Destroy(gameObject); // �Q�[���I�u�W�F�N�g��j��
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
    }