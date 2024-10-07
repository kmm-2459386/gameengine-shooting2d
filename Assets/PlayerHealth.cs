using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 90;  // プレイヤーの最大HP
    private int currentHealth;   // 現在のHP
    public Image HealthBer;
    void Start()
    {
        currentHealth = maxHealth;  // 初期HPを最大HPに設定
        UpdateHealthBar();
    }

    // 敵の攻撃で呼び出されるメソッド
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;  // HPを減少させる
        UpdateHealthBar();
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();  // HPが0以下になったらプレイヤーが死亡する
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
        // プレイヤーが死亡した時の処理
        Debug.Log("Player has died!");
        Destroy(gameObject);
        SceneManager.LoadScene("GameOverSene");
        // 例えば、ゲームオーバー画面を表示する、リスタートする、など
    }
}