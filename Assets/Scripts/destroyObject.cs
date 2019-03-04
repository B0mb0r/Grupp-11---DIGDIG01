using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{

    public float destroyTimer = 1f;

    void Start()
    {
        Destroy(gameObject, destroyTimer);
    }
}
