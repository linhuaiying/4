using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movepig : MonoBehaviour
{ public Transform wood;
    public GameObject right;
    public GameObject lose;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(wood.position.x, transform.position.y, transform.position.z);
        if(transform.position.x<right.transform.position.x)
        {
            lose.SetActive(true);
            return;
        }
    }
}
