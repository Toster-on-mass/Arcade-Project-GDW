using Unity.VisualScripting;
using UnityEngine;

public class PlayerCatcherMovement : MonoBehaviour
{

    public GameObject prototypeChargeDisplay;

    public float dashCharge = 0.0f;
    public float maxDashCharge = 100.0f;
    public float dashIncrease = 10.0f; // How much the dash charge increases when button is pressed
    public float dashBoost = 1000.0f;
    public float dashDrain = 10.0f; // How much the charge drains every second
    public float dashHoldDrainMult = 1.0f; // How much/quickly staying at over half charge causes a drain faster
    private float currentDashDrain = 10.0f;
    public float overchargePercent = 0.25f;


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

        // Increases the speed of the drain the longer the player has the dash charge over half
        if (dashCharge > maxDashCharge * overchargePercent)
        {
            currentDashDrain += Time.deltaTime * dashHoldDrainMult;
        }
        else
        {
            currentDashDrain = dashDrain;
        }

        // Charges the dash
        if (inputConnector.ButtonPressed())
        {
            IncreaseDashCharge(dashIncrease);
        }
        else // Uncharges the dash
        {
            dashCharge -= currentDashDrain * Time.deltaTime;
            if (dashCharge < 0)
            {
                dashCharge = 0;
            }
        }
        
        if (inputConnector.StickPressed())
        {
            Vector2 inputDir = inputConnector.GetPlayerInputDirection();
            BoostPlayer(new Vector3(inputDir.x, 0, inputDir.y));
        }

        prototypeChargeDisplay.transform.localScale = new Vector3(0.001f * dashCharge, prototypeChargeDisplay.transform.localScale.y, prototypeChargeDisplay.transform.localScale.z);


    }

    void FixedUpdate()
    {
        
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
        playerRB.linearVelocity = new Vector3();
        playerRB.AddForce(direction * dashCharge * dashBoost, ForceMode.Impulse);
        dashCharge = 0.0f;
    }
}
