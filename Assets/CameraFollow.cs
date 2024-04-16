using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Vector3 offset = new Vector3(0f, 0, -10f);
    private Vector3 velocity = Vector3.zero;
    [Header("Refrences")]
    public Transform player;

    [Header("Adjustments")]
    public float cameraHeight;
    public float smoothTime = 0.25f;
    private void Start()
    {
        offset = new Vector3(offset.x, cameraHeight,offset.z);
    }

    void Update()
    {
        Vector3 offsetPosition = player.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, offsetPosition, ref velocity, smoothTime);
    }
}
