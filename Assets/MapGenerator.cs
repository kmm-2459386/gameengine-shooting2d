using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator: MonoBehaviour
{
    public GameObject MapPrefab;
    float span = 10.0f;
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
            GameObject go = Instantiate(MapPrefab);
            go.transform.position = new Vector3(-0.07f, 10.0f, 0f);
        }
        
    }

}
