using UnityEngine;

public class PlayerDelivererMovement : MonoBehaviour
{

    public float playerSpeed = 100.0f;

    private PlayerInputConnector inputConnector;
    private Rigidbody playerRB;

    void Start()
    {
        inputConnector = gameObject.GetComponent<PlayerInputConnector>();
        playerRB = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 inputDir = inputConnector.GetPlayerInputDirection();
        Debug.Log(inputDir);
        playerRB.linearVelocity = (new Vector3(inputDir.x, 0.0f, inputDir.y)) * playerSpeed;
        Debug.Log(playerRB.linearVelocity);
    }
}
