using System.Collections;
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


    public Vector3 shakeSet;
    public float shakeTimer;
    public float cameraX;
    public float cameraY;
    public float shakeMax;
    public float shakeMin;

    public static float shake;
    public float shakeReduce;

    public float holdDownTime = 0;
    public bool otherActions;
    public Vector3 aheadTarget;
    public float xPos;
    public float yPos;

    public static float landingCounter;
    
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


        offset = new Vector3(xPos, yPos, -10);

        Vector3 desiredPosition = target.position + offset; 

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
        //transform.LookAt(target);


        if (transform.position.x <= minBounds.x + halfWidth)
        {
            transform.position = new Vector3(minBounds.x + halfWidth, transform.position.y, -10);
        }
        if (transform.position.x >= maxBounds.x - halfWidth)
        {
            transform.position = new Vector3(maxBounds.x - halfWidth, transform.position.y, -10);
        }

        if (transform.position.y <= minBounds.y + halfHeight)
        {
            transform.position = new Vector3(transform.position.x, minBounds.y + halfHeight, -10);
        }
        if (transform.position.y >= maxBounds.y - halfHeight)
        {
            transform.position = new Vector3(transform.position.x, maxBounds.y - halfHeight, -10);
        }

        // adda +1 till shake för kort screenshake
        if (Input.GetKey(KeyCode.P))
        {
            shake++;
        }
        if (shake > 0)
        {
            cameraX = transform.position.x;
            cameraY = transform.position.y;


                shakeSet = new Vector3(cameraX + Random.Range(shakeMax, shakeMin), cameraY + Random.Range(shakeMax, shakeMin), -10);
                transform.position = shakeSet;
            
            shake-=shakeReduce;
        }

        if (PlayerMovement.isJumping== false)
        {
            landingCounter += Time.deltaTime;
        }
       else
        {
            landingCounter = 0;
        }

    }



    
    private void Update()
    {
        if (transform.position.y >= maxBounds.y - halfHeight)
        {
            transform.position = new Vector3(transform.position.x, maxBounds.y - halfHeight, -10);
        }
        // om holdDownTime är mer än 0.5 så åcker camerans y position -4 och annars åcker camerans posiotion till 0
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.Mouse1))
        {
            otherActions = true;
        }
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            otherActions = false;
        }
        if (Input.GetKey(KeyCode.S) && (otherActions == false) || (Input.GetKey(KeyCode.W) && (otherActions == false)))
        {
            holdDownTime += Time.deltaTime;
        }
        else
        {
            holdDownTime = 0;
        }
        if (holdDownTime > 0.5 && Input.GetKey(KeyCode.S))
        {
            yPos = -4;
        }
        else if (holdDownTime > 0.5 && Input.GetKey(KeyCode.W))
        {
            yPos = 4;
        }
        else
        {
            yPos = 0;
        }
    }
    private void LateUpdate()
    {
        if (Input.GetKey(KeyCode.D))
        {
            xPos = 0.75f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            xPos = -0.75f;
        }
    }

}
