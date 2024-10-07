using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGenerator : MonoBehaviour
{
    public GameObject BossPrefab;
    float span = 75.0f;
    float delta = 0;
    private bool bossSpawned = false; // ボスが召喚されたかどうかのフラグ
    void Start()
    {
        
    }

    
    void Update()
    {
        if (!bossSpawned) // ボスがまだ召喚されていない場合
        {
            delta += Time.deltaTime;
            if (delta >= span)
            {
                GameObject go = Instantiate(BossPrefab, transform.position, Quaternion.identity);
                go.transform.position = new Vector3(0, 7, 0);
                bossSpawned = true; // ボスを召喚したのでフラグを立てる
            }
        }

    }
}
