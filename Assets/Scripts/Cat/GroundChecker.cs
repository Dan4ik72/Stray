using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    private bool _isOnTheGround;

    public bool IsOnTheGround => _isOnTheGround;

    private void OnTriggerExit(Collider other)
    {
        _isOnTheGround = false;
    }

    private void OnTriggerStay(Collider other)
    {
        _isOnTheGround = true;
    }
}
