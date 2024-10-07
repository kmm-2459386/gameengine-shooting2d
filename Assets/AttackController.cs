using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    public Transform player; // �v���C���[�I�u�W�F�N�g��Transform���w�肷�邽�߂̃t�B�[���h
    public float damage = 10f; // �U���̃_���[�W��

    void Start()
    {
        if (player != null)
        {
            // �v���C���[�̈ʒu���擾���āA���̃I�u�W�F�N�g�̈ʒu�ɐݒ肷��
            transform.position = player.position;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // EnemyController ���g�p����
        EnemyController enemy = collision.gameObject.GetComponent<EnemyController>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage); // �G�Ƀ_���[�W��^����
            Destroy(gameObject); // �U���I�u�W�F�N�g��j��
        }
    }
        
    void Update()
    {
        // �t���[�����Ƃɓ����ŏ�ɔ�΂�
        transform.Translate(0, 0.1f, 0);

        // ��ʊO�ɏo����I�u�W�F�N�g��j�󂷂�
        if (transform.position.y > 6.0f)
        {
            Destroy(gameObject);
        }
    }
}