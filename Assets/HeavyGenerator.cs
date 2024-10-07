using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyGenerator : MonoBehaviour
{
    public GameObject HeavyPrefab;
    float span = 30.0f;
    float delta = 0;
    void Start()
    {

    }

    void Update()
    {
        this.delta += Time.deltaTime;
        if (this.delta > this.span)
        {
            this.delta = 0;
            GameObject go = Instantiate(HeavyPrefab);
            int px = Random.Range(-2, 2);
            go.transform.position = new Vector3(px, 6, 0);
        }
    }
}
