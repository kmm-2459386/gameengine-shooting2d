using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyController : MonoBehaviour
{
    public float maxHP = 10f; // �ő�HP
    protected float currentHP; // ���݂�HP
    public int Damage = 30;
    public GameObject HeartHealPrefab;
    int healdrop = 1;

    protected virtual void Start()
    {
        currentHP = maxHP; // �Q�[���J�n����HP��ݒ�
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
        currentHP -= damage; // �_���[�W���󂯂�HP�����炷
        if (currentHP <= 0)
        {
            DropItem();
            Die(); // HP��0�ȉ��ɂȂ����玀�S����
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

    protected abstract void Die(); // ���S�������e�G�Ŏ�������
}