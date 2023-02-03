using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GroundChecker : MonoBehaviour
{
    public event UnityAction OffTheGround;
    public event UnityAction Landed;

    private bool _isOnTheGround;

    public bool IsOnTheGround => _isOnTheGround;

    private void OnTriggerExit(Collider other)
    {
        _isOnTheGround = false;

        OffTheGround?.Invoke();
    }

    private void OnTriggerEnter(Collider other)
    {
        _isOnTheGround = true;

        Landed?.Invoke();
    }

    private void OnTriggerStay(Collider other)
    {
        _isOnTheGround = true;
    }
}
