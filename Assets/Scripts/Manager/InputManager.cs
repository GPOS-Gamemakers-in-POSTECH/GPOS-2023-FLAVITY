using System;
using System.Numerics;
using UnityEngine.InputSystem;

public class InputManager : MonoSingleton<InputManager>
{
    public InputAction inputAction;
    public Action<Vector2> inputActionCallback;
    private FlavityInputSystem inputActions;
    
    public void SetActionMap()
    {
        inputActions.Player.Enable();
    }

    public void AddInputAction()
    {
        Vector2 asdf = inputActions.Player.View.ReadValue<Vector2>();
    }
}