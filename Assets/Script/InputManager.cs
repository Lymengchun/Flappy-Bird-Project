using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private TouchControl touchControl;
    public BirdScript birdScript;

    private void Awake()
    {
        touchControl = new TouchControl();
    }

    private void OnEnable()
    {
        touchControl.Enable();
    }

    private void OnDisable()
    {
        touchControl.Disable();
    }


    private void Start()
    {
        touchControl.Touch.TouchPress.started += ctx => StartTouch(ctx);
        touchControl.Touch.TouchPress.canceled += ctx => EndTouch(ctx);
    }

    private void StartTouch(InputAction.CallbackContext context)
    {
        Debug.Log("Touch Started");
        birdScript.BirdJump();
    }

    private void EndTouch(InputAction.CallbackContext context)
    {
        Debug.Log("Touch Ended");
    }
}
