using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    [SerializeField] private string _name;
    [SerializeField, TextArea(1, 5)] private string _line;

    public string Name => _name;
    public string Line => _line;    
}
