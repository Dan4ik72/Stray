using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushableCube : InteractableItem
{
    public override void Interact()
    {
        Debug.Log("interacted with " + name);
    }
}
