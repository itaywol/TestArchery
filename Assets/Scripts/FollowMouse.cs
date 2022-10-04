using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    void Update()
    {
        Vector3 position = Camera.main.ScreenToWorldPoint( Input.mousePosition );
        position.z = 0;
        transform.position = position;
    }
}
