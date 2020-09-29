using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTheObject : MonoBehaviour
{
    public Transform obj;
    void FixedUpdate()
    {
        Vector3 newPos = new Vector3(obj.position.x, obj.position.y, transform.position.z);
        transform.position = newPos;
        transform.rotation = obj.rotation;  
 
    }
}
