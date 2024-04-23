using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Gör så att kameran följer spelaren
/// </summary>
public class CameraFollow : MonoBehaviour
{
    private Vector3 _offset = new Vector3(0f, 0, -10f);
    private Vector3 _velocity = Vector3.zero;

    [Header("References")]
    [SerializeField] private Transform _player;

    [Header("Adjustments")]
    [SerializeField] private float _cameraHeight;
    [SerializeField] private float _smoothTime = 0.25f;
    private void Start()
    {
        // Sätter offset höjden till det man har valt
        _offset = new Vector3(_offset.x, _cameraHeight,_offset.z);
    }

    void Update()
    {
        // Lägger ihop vektorerna för att få en position för kameran
        Vector3 offsetPosition = _player.position + _offset;

        // Gör så att kameran långsamt går över mot spelarens exakt position
        transform.position = Vector3.SmoothDamp(transform.position, offsetPosition, ref _velocity, _smoothTime);
    }
}
