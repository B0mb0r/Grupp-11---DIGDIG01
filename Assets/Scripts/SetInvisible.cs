using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetInvisible : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {//gör att ett objekt inte syns i spelet. brukar användas till t.ex skyboxes
        GetComponent<SpriteRenderer>().enabled = false;
    }


}
