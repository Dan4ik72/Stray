using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private PlayerInputHandler _input;
    [SerializeField] private Transform _camera;
    [SerializeField] private GroundChecker _groundChecker;

    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _runSpeed;
    [SerializeField] private float _smoothRotationTime = 0.2f;

    [SerializeField] private SurfaceSlider _surfaceSlider;

    private Rigidbody _rigidbody;

    private float _smoothRotationVelocity;
    private Vector3 _currentDirection;
    private Vector3 _currentSpeed;
    private float _targetYRotateAngle;

    public float CurrentSpeed => _currentSpeed.magnitude;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Move(Vector3 direction)
    {
        _currentDirection = new Vector3(direction.x, 0f, direction.y).normalized;

        if (_currentDirection.magnitude <= 0.1f)
            return;

        Vector3 directionAlongSurface = _surfaceSlider.Project(_currentDirection);

        _targetYRotateAngle = Mathf.Atan2(directionAlongSurface.x, directionAlongSurface.z) * Mathf.Rad2Deg + _camera.localEulerAngles.y;

        Vector3 moveDirection = Quaternion.Euler(0, _targetYRotateAngle, 0) * Vector3.forward;
        _rigidbody.velocity = new Vector3(moveDirection.x * _moveSpeed, _rigidbody.velocity.y, moveDirection.z * _moveSpeed);
    }
    
    private void Rotate()
    {
        if (_currentDirection.magnitude <= 0.1f)
            return;

        float smoothRotationAngle = Mathf.SmoothDampAngle(transform.localEulerAngles.y, _targetYRotateAngle, ref _smoothRotationVelocity, _smoothRotationTime);

        /* probably I should rework this stuff
        _rigidbody.MoveRotation(Quaternion.Euler(_surfaceSlider.GetSurfaceEulerRotation().x, smoothRotationAngle,_surfaceSlider.GetSurfaceEulerRotation().z));
        */

        _rigidbody.MoveRotation(Quaternion.Euler(0f, smoothRotationAngle, 0f));
    }

    private void Update()
    {       
        Rotate();

        _currentSpeed = new Vector2(_rigidbody.velocity.x, _rigidbody.velocity.z);

        if (_groundChecker.IsOnTheGround)
            _rigidbody.drag = 20f;
        else
            _rigidbody.drag = 0;
    }

    public void Jump()
    {        
        if (_groundChecker.IsOnTheGround)
        {
            _rigidbody.velocity += new Vector3(0, _jumpForce, 0);
        }
    }
}
