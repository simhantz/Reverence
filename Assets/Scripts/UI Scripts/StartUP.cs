using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartUP : MonoBehaviour
{
    private GameObject child;

    private void Awake()
    {
        child = transform.GetChild(0).gameObject;
    }
    private void Start()
    {
        child.SetActive(true);
        child.SetActive(false);
    }
}
