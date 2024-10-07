using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireballDirector : MonoBehaviour
{
    public GameObject FireballPrefab; // ファイアーボールのプレハブ
    public Image powerGaugeForeground; // パワーゲージの前景
    public float powerRecoveryRate = 0.1f; // パワー回復速度
    public float Maxpower = 6f;       //最大パワーゲージ量
    private float power = 0f; // 現在のパワー
    public Transform playerTransform;     // プレイヤーの Transform を参照する変数
    private void Start()
    {
        
    }
    void Update()
    {
        // パワーゲージの回復
        if (power < 1f)
        {
            power += powerRecoveryRate * Time.deltaTime;
            power = Mathf.Clamp(power, 0f, 1f);
            powerGaugeForeground.fillAmount = power; // 前景のサイズを更新
        }
        // スペースキーでファイアーボールを発射
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }
    }

    public void Fire()
    {
        // パワーがある場合のみファイアーボールを発射
        if (power >= 0.16666667f)
        {
            GameObject go = Instantiate(FireballPrefab);
            go.transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y, 0);
            power -= 0.16666667f; // パワーを消費
            powerGaugeForeground.fillAmount = power; // 前景のサイズを更新
        }
    }
}