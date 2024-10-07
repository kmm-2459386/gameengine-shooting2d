using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
using UnityEngine.UI; 
public class GameDirector : MonoBehaviour
{
    GameObject HPGauge;
    public Image hpGauge; // HP�Q�[�W
    private float maxHP = 90f; // �ő�HP
    private float currentHP; // ���݂�HP

    void Start()
    {
        currentHP = maxHP; // �Q�[���J�n����HP��ݒ�
        UpdateHPBar(); // HP�Q�[�W���X�V
        this.HPGauge = GameObject.Find("HPgauge");
    }
    private void Update()
    {
        //if (this.HPGauge.GetComponent<Image>().fillAmount == 0)
        //{
        //    SceneManager.LoadScene("GameOverScene");   //HP���O�ɂȂ�ƁA�Q�[���I�[�o�[��ʂɑJ��
        //}
    }
    public void TakeDamage(float damage)
    {
        currentHP -= damage; // �_���[�W���󂯂�HP�����炷
        if (currentHP <= 0)
        {
            currentHP = 0;  //HP���O�ȉ��ɂȂ�Ȃ��悤�O�Ƃ��čX�V
            PlayerDie();   //HP���O�ɂȂ�����v���C���[�����S
        }
        UpdateHPBar(); // HP�Q�[�W���X�V
    }

    void UpdateHPBar()
    {
        hpGauge.fillAmount = currentHP / maxHP; // �Q�[�W�̊������X�V
    }
    void PlayerDie()
    {
        //Debug.Log("Player has died");
    }
}