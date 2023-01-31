using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractionCatcher : MonoBehaviour
{
    public event UnityAction<InteractableItem> InteractableItemEntered;
    public event UnityAction InteractableItemExited;
    public event UnityAction Interacted;

    private InteractableItem _currentInteractableItem;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<InteractableItem>(out InteractableItem interactable))
        {
            _currentInteractableItem = interactable;

            InteractableItemEntered?.Invoke(interactable);
        }                    
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.TryGetComponent<InteractableItem>(out InteractableItem interactable))
        {
            _currentInteractableItem = null;

            InteractableItemExited?.Invoke();
        }
    }

    public void OnInteract()
    {
        if (_currentInteractableItem == null)
            return;

        _currentInteractableItem.Interact();
        Interacted?.Invoke();
    }
}
