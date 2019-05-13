using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dustCloud : MonoBehaviour
{

    [SerializeField]
    GameObject dCloud;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Ground")) Instantiate(dCloud, transform.position, dCloud.transform.rotation);
    }
}
