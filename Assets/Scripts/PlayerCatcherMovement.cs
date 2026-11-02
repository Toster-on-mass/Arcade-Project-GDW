using Unity.VisualScripting;
using UnityEngine;

public class PlayerCatcherMovement : MonoBehaviour
{

    public float dashCharge = 0.0f;
    public float maxDashCharge = 100.0f;
    public float dashIncrease = 10.0f; // How much the dash charge increases when button is pressed
    public float dashBoost = 1000.0f;


    // Refer to this when getting player inputs so we can switch the player controls
    private PlayerInputConnector inputConnector;
    private Rigidbody playerRB;

    void Start()
    {
        inputConnector = gameObject.GetComponent<PlayerInputConnector>();
        playerRB = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Charges the dash
        if (inputConnector.ButtonPressed())
        {
            Debug.Log("Message 1"); // Shows inputs are working
            Debug.Log(dashCharge);
            IncreaseDashCharge(dashIncrease);
        }
        if (inputConnector.StickPressed())
        {
            Vector2 inputDir = inputConnector.GetPlayerInputDirection();
            BoostPlayer(new Vector3(inputDir.x, 0, inputDir.y));
        }
    }

    void IncreaseDashCharge(float amount)
    {
        dashCharge += amount;
        if (dashCharge > maxDashCharge)
        {
            dashCharge = maxDashCharge;
        }
    }

    void BoostPlayer(Vector3 direction)
    {
        Debug.Log("Message 2"); // Shows this function is being run
        Debug.Log(dashCharge);
        playerRB.AddForce(direction * dashCharge * dashBoost, ForceMode.Impulse);
        dashCharge = 0.0f;
        Debug.Log(dashCharge);
    }
}
