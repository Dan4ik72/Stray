using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS : MonoBehaviour
{
    [SerializeField] private int _targetFps;

    private void OnValidate()
    {
        Application.targetFrameRate = _targetFps;
    }
}
