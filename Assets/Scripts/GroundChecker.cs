using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    public bool isGrounded;
    public float fallingSpeedMin;
    public float addToCounter;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            //Våran variabel som kollar om vi är på marken sätts som sann
            isGrounded = true;
            if (cameraMovementTest.landingCounter >= fallingSpeedMin)
            {
                cameraMovementTest.landShake++;
            }
        }

    }
    //När jag lämnar kontakten med triggern så händer något
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            //Variabeln byts till falsk
            isGrounded = false;
            cameraMovementTest.landingCounter = addToCounter;
        }
    }
}
