using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyObject : MonoBehaviour
{

    public float destroyTimer = 1f;

    void Start()
    {
        Destroy(gameObject, destroyTimer);
    }
}
