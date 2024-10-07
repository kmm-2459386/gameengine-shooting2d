using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : EnemyController
{
    public GameObject BardPrefab;
    float span = 5.0f;
    float delta = 0;
    public int damage = 15; // �v���C���[�ɗ^����_���[�W��
    float maxHP = 50f; // Enemy3 �̍ő�HP
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
        
            // ��ʊO�ɏo����I�u�W�F�N�g��j�󂷂�
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
                playerHealth.TakeDamage(damage);  // �v���C���[�Ƀ_���[�W��^����
            }
            Destroy(gameObject);
        }
    }
    protected override void Die()
    {
        // Enemy3 �̎��S����
        Destroy(gameObject);
    }
}
