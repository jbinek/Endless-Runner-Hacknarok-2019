using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadnomSpawn : MonoBehaviour
{

    public float probability;
    public GameObject collect2;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(">>");
        Debug.Log(collect2);
        float lotto = Random.Range(0, 1);
        GameObject go;
        go = (Instantiate(collect2)) as GameObject;
        go.transform.position = transform.position;
      


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
