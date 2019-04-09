using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    public bool isGrounded;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Våran variabel som kollar om vi är på marken sätts som sann
        isGrounded = true;
    }
    //När jag lämnar kontakten med triggern så händer något
    private void OnTriggerExit2D(Collider2D collision)
    {
        //Variabeln byts till falsk
        isGrounded = false;
    }
}
