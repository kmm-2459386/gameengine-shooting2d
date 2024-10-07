using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class MapController : MonoBehaviour
{
    public float moveSpeed = 1f;
    public Vector3 startPosition;
    public Vector3 endPosition;
    private bool movingDown = true;
    void Start()
    {
        startPosition = transform.position;
        endPosition = new Vector3(startPosition.x, startPosition.y - 30, startPosition.z); // 下に10の距離移動
    }

    // Update is called once per frame
    void Update()
    {
        if (movingDown)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPosition, moveSpeed * Time.deltaTime);
            if (transform.position == endPosition)
            {
                movingDown = false;
                //StartCoroutine(Respawn());
            }
            // 画面外に出たらオブジェクトを破壊する
            if (transform.position.y < -11.0f)
            {
                Destroy(gameObject);
            }
        }
       
    }
}
