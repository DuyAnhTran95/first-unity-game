
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

[DefaultExecutionOrder(-1)]
public class InputManager : Singleton<InputManager>
{
    private void Awake()
    {
        EnhancedTouchSupport.Enable();
    }

    private void Update()
    {
        if (Touch.activeTouches.Count > 0)
        {
            Move(Touch.activeTouches[0]);
        }
    }

    private void Move(Touch touch)
    {
        PlayerController.Instance?.MoveTo(touch.screenPosition);
        DotController.Instance?.MoveTo(touch.screenPosition);
    }
}
