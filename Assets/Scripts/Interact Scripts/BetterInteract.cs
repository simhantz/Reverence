using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
/// <summary>
/// Huvud Interact-scriptet som hanterar det mesta
/// </summary>
public class BetterInteract : MonoBehaviour
{
    [SerializeField] private KeyCode useKey = KeyCode.F;
    [SerializeField] private float interactRange = 1f;

    // Eftersom att detta script bara kommer sitta på spelaren tar jag och gör en static så jag har lätt tillgång
    public static InventoryManager playerInventory;

    private void Awake()
    {
        playerInventory = GetComponent<InventoryManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(useKey))
        {
            // Gör en cirkel med radiusen "interact range" och lägger in alla colliders som den krockar med
            Collider2D[] colliderArray = Physics2D.OverlapCircleAll(transform.position, interactRange);

            foreach (Collider2D col in colliderArray)
            {
                // Om colliders gameObject har rätt komponent så kör vi methoden i det scriptet
                if (col.TryGetComponent<IInteract>(out IInteract interact))
                {
                    Debug.Log("Do interact thingy");
                    interact.Interact();
                }
            }
        }
    }

    // Gizmos så jag kan se hur lång "interact range" jag har
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, interactRange);
    }

}
