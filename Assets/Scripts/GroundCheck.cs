using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public int touches;
    // kollar ifall man nudar marken
    private void OnTriggerEnter2D(Collider2D collision)
    {
        touches++;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        touches--;
    }
}
