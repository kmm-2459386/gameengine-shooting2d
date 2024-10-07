using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackGenerator : MonoBehaviour
{
    public GameObject AttackEfectPrefab;
    public Transform playerTransform;     // プレイヤーの Transform を参照する変数
    float span = 0.325f;
    float delta = 0;
    //public KeyCode attackKey = KeyCode.Space; // 攻撃を発射するためのキー

    void Start()
    {
        
    }
    void Update()
    {
        AttackButon();
    }
        // Update is called once per frame
        public void AttackButon()
    {
        this.delta += Time.deltaTime;
        if (this.delta > this.span)
        // ボタンが押されたかをチェック
        {
            this.delta = 0;
            GameObject go = Instantiate(AttackEfectPrefab);
            go.transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y, 0);
        }
    }
        
}
