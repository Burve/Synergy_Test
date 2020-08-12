using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;

public class InputController : MonoSingleton<InputController>
{
    void Awake()
    {
        Instance = this;
        _input = new MasterInput();
        _input.GlobalInput.PrimaryTouchPos.performed += ctx => _primaryPoint = ctx.ReadValue<Vector2>();
        _input.GlobalInput.PrimaryTouchPos.canceled += ctx => _primaryPoint = Vector2.zero;
        _input.GlobalInput.PrimaryTouchPress.performed += ctx => _primaryDown = ctx.ReadValueAsButton();
        _input.GlobalInput.PrimaryTouchPress.canceled += ctx => _primaryDown = false;
        EnableInput();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _primaryTap = !_primaryDown && _lastPrimaryTapValue;
        _lastPrimaryTapValue = _primaryDown;


    }

    public void EnableInput()
    {
        _input.Enable();
    }

    public void DisableInput()
    {
        _input.Disable();
    }

    #region Fields

    private MasterInput _input;

    private Vector2 _primaryPoint;
    private bool _primaryDown;
    private bool _primaryTap;
    private bool _lastPrimaryTapValue;

    #endregion

    #region Properties

    public Vector2 PrimaryPoint => _primaryPoint;
    public Vector3 PrimaryPointV3 => _primaryPoint;

    public bool PrimaryDown => _primaryDown;

    public bool PrimaryTap => _primaryTap;


    #endregion
}
