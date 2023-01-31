using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InteractionView : MonoBehaviour
{
    [SerializeField] private Image _interactionIcon;
    [SerializeField] private TMP_Text _interactionName;

    private Image _defaultInteractionIcon;
    private TMP_Text _defaultInteractionName;

    private void Start()
    {
        _defaultInteractionIcon = _interactionIcon;
        _defaultInteractionName = _interactionName;
    }

    public void Init(InteractableItem item)
    {
        _interactionName.text = item.Description;
        _interactionIcon.sprite = item.Icon;
    }

    public void ResetInteraction()
    {
        _interactionName.text = _defaultInteractionName.text;
        _interactionIcon.sprite = _defaultInteractionIcon.sprite;
    }
}
