using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circlemove : MonoBehaviour
{
    public Transform wood;
    public Transform pos;

    // Update is called once per frame
    void Update()
    {   
        wood.Rotate(0, 0, 5);
        wood.position = new Vector3( pos.position.x,wood.position.y,wood.position.z);
    }
}
