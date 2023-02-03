using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueInteraction : InteractableItem
{
    [SerializeField] private DialogueDesk _dialogueDesk;
    [SerializeField] private DialogueInfo _dialogueInfo;

    public override void Interact()
    {
        _dialogueDesk.StartDialogue(_dialogueInfo);
    }
}
