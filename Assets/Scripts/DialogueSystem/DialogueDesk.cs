using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueDesk : MonoBehaviour
{
    [SerializeField] private DialogueHandler _dialogueHandler;
    [SerializeField] private PlayerInputHandler _playerInput;

    private void OnEnable()
    {
        _dialogueHandler.DialogueEnded += EndDialogue;
    }

    private void OnDisable()
    {
        _dialogueHandler.DialogueEnded -= EndDialogue;
    }

    public void StartDialogue(DialogueInfo dialogueInfo)
    {
        _playerInput.DisableInput();

        _dialogueHandler.gameObject.SetActive(true);
        _dialogueHandler.StartDialogue(dialogueInfo);
    }

    private void EndDialogue()
    {
        _playerInput.EnableInput();
    }
}
