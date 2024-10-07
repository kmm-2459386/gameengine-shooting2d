using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
using UnityEngine.UI; 
public class GameDirector : MonoBehaviour
{
    GameObject HPGauge;
    public Image hpGauge; // HPゲージ
    private float maxHP = 90f; // 最大HP
    private float currentHP; // 現在のHP

    void Start()
    {
        currentHP = maxHP; // ゲーム開始時のHPを設定
        UpdateHPBar(); // HPゲージを更新
        this.HPGauge = GameObject.Find("HPgauge");
    }
    private void Update()
    {
        //if (this.HPGauge.GetComponent<Image>().fillAmount == 0)
        //{
        //    SceneManager.LoadScene("GameOverScene");   //HPが０になると、ゲームオーバー画面に遷移
        //}
    }
    public void TakeDamage(float damage)
    {
        currentHP -= damage; // ダメージを受けてHPを減らす
        if (currentHP <= 0)
        {
            currentHP = 0;  //HPを０以下にならないよう０として更新
            PlayerDie();   //HPが０になったらプレイヤーが死亡
        }
        UpdateHPBar(); // HPゲージを更新
    }

    void UpdateHPBar()
    {
        hpGauge.fillAmount = currentHP / maxHP; // ゲージの割合を更新
    }
    void PlayerDie()
    {
        //Debug.Log("Player has died");
    }
}