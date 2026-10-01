using UnityEngine;
using UnityEngine.InputSystem;

public class GameController : MonoBehaviour
{
    [SerializeField] private float _gravityScale = 1.0f;
    private float _gravity = 9.81f;
    private PlayerInput _playerInput;
    private InputAction _upDownAction;
    private InputAction _MoveAction;
    private Vector3 _velocity = Vector3.zero;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       _playerInput = GetComponent<PlayerInput>();
         _upDownAction = _playerInput.actions["UpDown"];
        _MoveAction = _playerInput.actions["Move"];
        _upDownAction.Enable();
        _MoveAction.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        var moveInput = _MoveAction.ReadValue<Vector2>();

        _velocity.x = moveInput.x;
        _velocity.z = moveInput.y;

        if (_upDownAction.WasPressedThisFrame())
        
            _velocity.y = 1f;
        if (_upDownAction.WasReleasedThisFrame())
            _velocity.y = -1f;

        Physics.gravity = _velocity * _gravity * _gravityScale;

    }

}
