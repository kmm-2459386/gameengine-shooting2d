using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BardController : MonoBehaviour
{
    GameObject player;
    public Transform target; // �ǔ�����Ώہi�v���C���[�Ȃǁj
    public float speed = 100f; // �~�T�C���̑��x
    void Start()
    {
        player = GameObject.Find("Player");
        target = player.transform;
    }
    void Update()
    {
        if (target != null)
        {
            // �^�[�Q�b�g�����̌v�Z
            Vector3 direction = target.position - transform.position;
            direction.Normalize();

            // �����I�Ɉړ�
            transform.position += direction * speed * Time.deltaTime;
        }
    }
}