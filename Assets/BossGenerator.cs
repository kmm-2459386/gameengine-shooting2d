using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGenerator : MonoBehaviour
{
    public GameObject BossPrefab;
    float span = 75.0f;
    float delta = 0;
    private bool bossSpawned = false; // �{�X���������ꂽ���ǂ����̃t���O
    void Start()
    {
        
    }

    
    void Update()
    {
        if (!bossSpawned) // �{�X���܂���������Ă��Ȃ��ꍇ
        {
            delta += Time.deltaTime;
            if (delta >= span)
            {
                GameObject go = Instantiate(BossPrefab, transform.position, Quaternion.identity);
                go.transform.position = new Vector3(0, 7, 0);
                bossSpawned = true; // �{�X�����������̂Ńt���O�𗧂Ă�
            }
        }

    }
}
