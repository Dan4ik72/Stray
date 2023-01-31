using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public abstract class Transition : MonoBehaviour
{
    [SerializeField] private State _targetState;

    protected bool _isAbleToTransit;

    public State TargetState => _targetState;
    public bool IsAbleToTransit => _isAbleToTransit;

    public void OnEnable()
    {
        ResetByDefault();
    }

    public void ResetByDefault()
    {
        _isAbleToTransit = false;
    }
}
