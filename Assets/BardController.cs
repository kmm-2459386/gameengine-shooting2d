using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BardController : MonoBehaviour
{
    GameObject player;
    public Transform target; // 追尾する対象（プレイヤーなど）
    public float speed = 100f; // ミサイルの速度
    void Start()
    {
        player = GameObject.Find("Player");
        target = player.transform;
    }
    void Update()
    {
        if (target != null)
        {
            // ターゲット方向の計算
            Vector3 direction = target.position - transform.position;
            direction.Normalize();

            // 直線的に移動
            transform.position += direction * speed * Time.deltaTime;
        }
    }
}