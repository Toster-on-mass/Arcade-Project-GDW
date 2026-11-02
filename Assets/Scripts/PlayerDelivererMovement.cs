using UnityEngine;

public class PlayerDelivererMovement : MonoBehaviour
{
    // Refer to this when getting player inputs so we can switch the player controls
    private PlayerInputConnector inputConnector;

    void Start()
    {
        inputConnector = gameObject.GetComponent<PlayerInputConnector>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
