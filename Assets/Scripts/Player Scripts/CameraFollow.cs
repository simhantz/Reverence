using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// G�r s� att kameran f�ljer spelaren
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
        // S�tter offset h�jden till det man har valt
        _offset = new Vector3(_offset.x, _cameraHeight,_offset.z);
    }

    void Update()
    {
        // L�gger ihop vektorerna f�r att f� en position f�r kameran
        Vector3 offsetPosition = _player.position + _offset;

        // G�r s� att kameran l�ngsamt g�r �ver mot spelarens exakt position
        transform.position = Vector3.SmoothDamp(transform.position, offsetPosition, ref _velocity, _smoothTime);
    }
}
