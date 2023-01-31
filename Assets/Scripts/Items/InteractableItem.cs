using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractableItem : MonoBehaviour
{
    [SerializeField] private string _interactionDescription;
    [SerializeField] private Sprite _interactionIcon;

    public string Description => _interactionDescription;
    public Sprite Icon => _interactionIcon;

    public abstract void Interact();
    
}
