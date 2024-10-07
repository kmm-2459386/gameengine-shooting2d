using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiderGenerator : MonoBehaviour
{
    public GameObject RiderPrefab;
    float span = 5.0f;
    float delta = 0;
    void Start()
    {
        
    }

    void Update()
    {
        this.delta += Time.deltaTime;
        if(this.delta > this.span){
            this.delta = 0;
            GameObject go = Instantiate(RiderPrefab);
            int px = Random.Range(-2, 2);
            go.transform.position = new Vector3(px, 6, 0);
        }
    }
}

