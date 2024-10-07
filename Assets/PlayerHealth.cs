using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 90;  // �v���C���[�̍ő�HP
    private int currentHealth;   // ���݂�HP
    public Image HealthBer;
    void Start()
    {
        currentHealth = maxHealth;  // ����HP���ő�HP�ɐݒ�
        UpdateHealthBar();
    }

    // �G�̍U���ŌĂяo����郁�\�b�h
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;  // HP������������
        UpdateHealthBar();
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();  // HP��0�ȉ��ɂȂ�����v���C���[�����S����
        }
    }
   void Update()
    {
        UpdateHealthBar();
        if (currentHealth >= 90)
        {
            currentHealth = 90;
        }
    }
    private void UpdateHealthBar()
    {
        if(HealthBer != null)
        {
            float healthwari = (float)currentHealth / (float)maxHealth;
            HealthBer.fillAmount = healthwari;
        }
    }
    private void Die()
    {
        // �v���C���[�����S�������̏���
        Debug.Log("Player has died!");
        Destroy(gameObject);
        SceneManager.LoadScene("GameOverSene");
        // �Ⴆ�΁A�Q�[���I�[�o�[��ʂ�\������A���X�^�[�g����A�Ȃ�
    }
}