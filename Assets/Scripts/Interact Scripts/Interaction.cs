using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interaction : MonoBehaviour
{
    public KeyCode interactButton;
    public UnityEvent InteractionEvent;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(interactButton))
        {
            InteractionEvent.Invoke();
        }
    }
}
