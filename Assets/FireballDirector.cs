using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireballDirector : MonoBehaviour
{
    public GameObject FireballPrefab; // �t�@�C�A�[�{�[���̃v���n�u
    public Image powerGaugeForeground; // �p���[�Q�[�W�̑O�i
    public float powerRecoveryRate = 0.1f; // �p���[�񕜑��x
    public float Maxpower = 6f;       //�ő�p���[�Q�[�W��
    private float power = 0f; // ���݂̃p���[
    public Transform playerTransform;     // �v���C���[�� Transform ���Q�Ƃ���ϐ�
    private void Start()
    {
        
    }
    void Update()
    {
        // �p���[�Q�[�W�̉�
        if (power < 1f)
        {
            power += powerRecoveryRate * Time.deltaTime;
            power = Mathf.Clamp(power, 0f, 1f);
            powerGaugeForeground.fillAmount = power; // �O�i�̃T�C�Y���X�V
        }
        // �X�y�[�X�L�[�Ńt�@�C�A�[�{�[���𔭎�
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }
    }

    public void Fire()
    {
        // �p���[������ꍇ�̂݃t�@�C�A�[�{�[���𔭎�
        if (power >= 0.16666667f)
        {
            GameObject go = Instantiate(FireballPrefab);
            go.transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y, 0);
            power -= 0.16666667f; // �p���[������
            powerGaugeForeground.fillAmount = power; // �O�i�̃T�C�Y���X�V
        }
    }
}