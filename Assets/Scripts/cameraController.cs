using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{

    public BoxCollider2D boundBox;
    private Vector3 minBounds;
    private Vector3 maxBounds;
    public GameObject player;

    private Camera theCamera;
    private float halfHeight;
    private float halfWidth;

    // Start is called before the first frame update
    void Start()
    {
        minBounds = boundBox.bounds.min;
        maxBounds = boundBox.bounds.max;
        theCamera = GetComponent<Camera>();
        halfHeight = theCamera.orthographicSize;
        halfWidth = halfHeight * Screen.width / Screen.height;

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3( player.transform.position.x, player.transform.position.y, transform.position.z);
        float clampedX = Mathf.Clamp(transform.position.x, minBounds.x + halfWidth, maxBounds.x - halfWidth);
        float clampedY = Mathf.Clamp(transform.position.y, minBounds.y + halfHeight, maxBounds.y - halfHeight);
        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }
    //nani
}
