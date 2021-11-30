using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerInteracting : MonoBehaviour
{
    private bool _shouldInteract = true;

    [SerializeField]
    private float radiousSearch;

    private Interactable closestInteractable;

    public void AllowPlayerToInteract (bool value)
    {
        _shouldInteract = value;
    }

    void Update ()
    {
        if (!_shouldInteract) return;

        var gotInteractable = SearchForInteractable();

        if (gotInteractable != closestInteractable)
        {
            if (gotInteractable != null) gotInteractable.Select();
            if (closestInteractable != null) closestInteractable.Deselect();
            closestInteractable = gotInteractable;
        }

        if (Input.GetKeyDown(KeyCode.E) && closestInteractable != null)
        {
            closestInteractable.Interact();
        }
    }

    public Interactable SearchForInteractable ()
    {
        var interactables = new List<Interactable>();
        var colliders = Physics2D.OverlapCircleAll(this.transform.position, this.radiousSearch);

        // searching for interactables
        foreach (var collider in colliders)
        {
            var interactable = collider.GetComponent<Interactable>();

            if (interactable != null)
            {
                interactables.Add(interactable);
            }
        }

        if (interactables.Count > 0)
        {
            interactables.Sort((i1, i2) => {
                float d1 = i1.GetDistanceToInteractable(this.gameObject);
                float d2 = i2.GetDistanceToInteractable(this.gameObject);
                return d1 <= d2 ? -1 : 1;
            });
            return interactables[0];

            // foreach (var interactable in interactables)
            // {
            //     if (Vector2.Distance(this.transform.position, interactable.transform.position) < Vector2.Distance(this.transform.position, closestInteractable.transform.position))
            //     {
            //         closestInteractable = interactable;
            //     }
            // }

            // closestInteractable;
        }

        return null;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(this.transform.position, this.radiousSearch);
    }
}
