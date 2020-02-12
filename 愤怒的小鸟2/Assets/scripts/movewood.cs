using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movewood : MonoBehaviour
{
    public Transform wood;
    private float i = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        wood.position = new Vector3(wood.position.x + i, wood.position.y, wood.position.z);
        i -= 0.002f * Time.deltaTime;
    }
}
