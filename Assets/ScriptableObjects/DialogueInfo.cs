using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue" , menuName = "Dialogue/Create new dialogue")]
public class DialogueInfo : ScriptableObject
{
    [SerializeField] private List<Dialogue> _lines;

    public IReadOnlyList<Dialogue> Lines => _lines;
}


