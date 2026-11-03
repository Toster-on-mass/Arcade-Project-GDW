// The purpose of this script is for it to be called by the player controlers so we can easily switch what player is controling each character

using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputConnector : MonoBehaviour
{
    public int playerNumber = 1;
    private InputSystem_Actions controls;

    private void Start()
    {
        controls = new InputSystem_Actions();
        SetPlayerControlEnable();
    }
    public bool ButtonPressed()
    {
        // WasPressedThisFrame may be the incorrect way to go about it tbh
        if (playerNumber == 1 && controls.Player1.Any.WasPressedThisDynamicUpdate())
        {
            return true;
        }
        if (playerNumber == 2 && controls.Player2.Any.WasPressedThisDynamicUpdate())
        {
            return true;
        }

        return false;
    }

    // Checks for the first input of the stick
    // For the dash only player control
    public bool StickPressed()
    {
        if (playerNumber == 1 && controls.Player1.Move.WasPressedThisDynamicUpdate())
        {
            return true;
        }
        if (playerNumber == 2 && controls.Player2.Move.WasPressedThisDynamicUpdate())
        {
            return true;
        }

        return false;
    }

    public Vector2 GetPlayerInputDirection()
    {
        if (playerNumber == 1)
        {
            return controls.Player1.Move.ReadValue<Vector2>();
        }
        if (playerNumber == 2)
        {
            return controls.Player2.Move.ReadValue<Vector2>();
        }

        Debug.Log("NO CORRECT PLAYER NUMBER FOUND");
        return new Vector2();
    }

    // Call to set the player inputs
    // Currently called when starting, but whenever changing the playerNumber change as well
    // (if this was godot I would have it be called whenever the varible is changed, but it is not and I don't want to have it check every frame)
    private void SetPlayerControlEnable()
    {
        if (playerNumber == 1)
        {
            controls.Player1.Enable();
            controls.Player2.Disable();
        }
        else if (playerNumber == 2)
        {
            controls.Player1.Disable();
            controls.Player2.Enable();
        }
    }
}
