using System.Collections;
using System.Collections.Generic;
using TMPro;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class DialogueHandler : MonoBehaviour
{
    public event UnityAction DialogueEnded;

    [SerializeField] private TMP_Text _name;
    [SerializeField] private TMP_Text _line;

    [SerializeField] private float _textSpeed;
    
    private DialogueInfo _dialogueInfo;

    private Coroutine _textRenderCoroutine;

    private int _lineIndex;

    public void StartDialogue(DialogueInfo dialogueInfo)
    {
        _dialogueInfo = dialogueInfo;

        ResetDialogue();     

        RenderNextLine();
    }

    public void RenderNextLine()
    {
        if (_textRenderCoroutine != null)
        {
            StopCoroutine(_textRenderCoroutine);
            _textRenderCoroutine = null;

            _line.text = _dialogueInfo.Lines[_lineIndex - 1].Line;

            return;
        }

        if (_lineIndex > _dialogueInfo.Lines.Count - 1)
        {
            EndDialogue();

            return;
        }

        _line.text = string.Empty;

        _name.text = _dialogueInfo.Lines[_lineIndex].Name;

        _textRenderCoroutine = StartCoroutine(RenderLine());

        _lineIndex++;
    }

    private IEnumerator RenderLine()
    {
        var waitForSecondsBetweenChars = new WaitForSecondsRealtime(_textSpeed);

        foreach (char c in _dialogueInfo.Lines[_lineIndex].Line)
        {
            _line.text += c;

            yield return waitForSecondsBetweenChars;
        }

        _textRenderCoroutine = null;
    }

    private void EndDialogue()
    {
        DialogueEnded?.Invoke();

        _line.text = string.Empty;

        gameObject.SetActive(false);
    }

    private void ResetDialogue()
    {
        _lineIndex = 0;

        _textRenderCoroutine = null;
    }
}
