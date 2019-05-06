using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMoveScript : MonoBehaviour
{

    [Range(1f, 20f)]
    public float scrollSpeed = 1f;
    public float scrollOffset;

    Vector2 startPos;

    float newPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        newPos = Mathf.Repeat(Time.time * -scrollSpeed, scrollOffset);
        transform.position = startPos + Vector2.right * newPos;
    }
}
