using System.Collections;
using UnityEngine;

public class PlayerDelivererMovement : MonoBehaviour
{

    public float playerSpeed = 100.0f;
    public float playerDashSpeed = 300.0f;
    public float dashLengthCooldown = 0.2f;
    public float dashCooldown = 0.5f;
    private bool canDash = true;

    // 0 - Normal movement
    // 1 - Dash
    public int movementState = 0; 

    private PlayerInputConnector inputConnector;
    private Rigidbody playerRB;

    private Vector3 dashDir;
    

    void Start()
    {
        inputConnector = gameObject.GetComponent<PlayerInputConnector>();
        playerRB = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (movementState == 0)
        {
            BasicMovementState();
        }
        else if (movementState == 1)
        {
            DashMovementState();
        }
        else
        {
            Debug.Log("Oh no! The state isn't real!");
        }
    }

    void BasicMovementState()
    {
        Vector2 inputDir = inputConnector.GetPlayerInputDirection();
        Vector3 moveDir = new Vector3(inputDir.x, 0.0f, inputDir.y);
        playerRB.linearVelocity = (moveDir) * playerSpeed;

        if (canDash && inputConnector.ButtonPressed())
        {
            StartCoroutine(DashLengthWait());
            dashDir = moveDir;
            movementState = 1;
        }

    }
    void DashMovementState()
    {
        playerRB.linearVelocity = (dashDir) * playerDashSpeed;
    }

    IEnumerator DashLengthWait()
    {
        canDash = false;
        yield return new WaitForSeconds(dashLengthCooldown);
        Debug.Log("Past1");
        movementState = 0;
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
        Debug.Log("Past2");

    }

}
