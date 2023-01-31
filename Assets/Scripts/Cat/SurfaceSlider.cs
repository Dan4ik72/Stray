using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurfaceSlider : MonoBehaviour
{
    private Vector3 _normal;
    private GameObject _currentSurface;

    public Vector3 Project(Vector3 direction)
    {
        return direction - Vector3.Dot(direction, _normal) * _normal;
    }

    public Vector3 GetSurfaceEulerRotation()
    {
        var currentSurfaceRotation = _currentSurface == null ? Vector3.zero: _currentSurface.transform.localEulerAngles;

        Debug.Log(currentSurfaceRotation);

        return currentSurfaceRotation;
    }

    private void OnCollisionStay(Collision collision)
    {
        var contactPoint = collision.contacts[0];

        _currentSurface = contactPoint.otherCollider.gameObject;
        _normal = contactPoint.normal.x == 0 ? contactPoint.normal : _normal;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawLine(transform.position, transform.position + _normal * 3);
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Project(transform.position));
    }
}
