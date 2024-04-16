using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Refrences")]
    public Transform Player;

    [Header("Adjustments")]
    public float cameraHeight;

    void Update()
    {
        transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y + cameraHeight, transform.position.z);
    }
}
