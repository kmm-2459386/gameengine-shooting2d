using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy4 : EnemyController
{
    float maxHP = 30f; // Enemy4 �̍ő�HP
    protected override void Start()
    {
        
        base.Start();
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
        // Enemy4 �̎��S����
        Destroy(gameObject);
    }
}
