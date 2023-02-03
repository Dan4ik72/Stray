using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionDesk : MonoBehaviour
{
    [SerializeField] private InteractionCatcher _interactionCatcher;

    [SerializeField] private InteractionView _template;
    [SerializeField] private Transform _itemContainer;

    private void Start()
    {
        _template.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        _interactionCatcher.InteractableItemEntered += AddInteraction;
        _interactionCatcher.InteractableItemExited += RemoveInteraction;
        _interactionCatcher.Interacted += RemoveInteraction;
    }

    private void OnDisable()
    {
        _interactionCatcher.InteractableItemEntered -= AddInteraction;
        _interactionCatcher.InteractableItemExited -= RemoveInteraction;
        _interactionCatcher.Interacted -= RemoveInteraction;
    }

    public void AddInteraction(InteractableItem newInteraction)
    {
        if (_template.gameObject.activeSelf == true)
            return;

        _template.gameObject.SetActive(true);

        _template.Init(newInteraction);
    }

    public void RemoveInteraction()
    {
        if (_template.gameObject.activeSelf == false)
            return;

        _template.gameObject.SetActive(false);

    }
}
