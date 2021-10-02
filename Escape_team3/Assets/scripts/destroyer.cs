using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyer : MonoBehaviour
{
    private void Update()
    {
        if(transform.position.y < -12f)
        {
            Destroy(gameObject);
        }
    }
}
