using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BardGenerator : MonoBehaviour
{
    public GameObject projectilePrefab;  // �U���̃v���n�u�i�e�Ȃǁj
    public Transform attackPoint;        // �U���𔭎˂���ʒu
    public float attackRate = 2f;        // �U���̊Ԋu�i�b�j

    private float nextAttackTime = 0f;

    void Update()
    {
        // ���݂̎��Ԃ����̍U�����Ԃ��߂��Ă���΍U������
        if (Time.time >= nextAttackTime)
        {
            Attack();
            nextAttackTime = Time.time + 1f / attackRate;
        }
    }

    void Attack()
    {
        // �U���𔭎˂���
        if (projectilePrefab != null && attackPoint != null)
        {
            Instantiate(projectilePrefab, attackPoint.position, attackPoint.rotation);
        }
    }
}