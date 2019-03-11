﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovementTest : MonoBehaviour
{

    public BoxCollider2D boundBox; // länkas till en box som läggs över hela kartan
    private Vector3 minBounds;
    private Vector3 maxBounds;

    private Camera theCamera;
    private float halfHeight;
    private float halfWidth;

    public Transform target;
    public float smoothSpeed = 0.13f;
    public Vector3 offset;



    // Start is called before the first frame update
    void Start()
    {
        minBounds = boundBox.bounds.min;
        maxBounds = boundBox.bounds.max;

        theCamera = GetComponent<Camera>();
        halfHeight = theCamera.orthographicSize;
        halfWidth = halfHeight * Screen.width / Screen.height;
    }

    private void FixedUpdate()
    {
     

        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
        //transform.LookAt(target);


        if (transform.position.x <= minBounds.x + halfWidth)
        {
            transform.position = new Vector3(minBounds.x + halfWidth, transform.position.y, -10 );
        }
        if (transform.position.x >= maxBounds.x - halfWidth)
        {
            transform.position = new Vector3(maxBounds.x - halfWidth, transform.position.y, -10);
        }
        if (transform.position.y <= minBounds.y + halfHeight)
        {
            transform.position = new Vector3(transform.position.x, minBounds.y + halfHeight, -10);
        }
        if (transform.position.y <= maxBounds.y - halfHeight)
        {
            transform.position = new Vector3(transform.position.x, maxBounds.y - halfHeight, -10);
        }
    }





}

