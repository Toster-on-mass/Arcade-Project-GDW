using UnityEngine;

public class PlayerCatcherMovement : MonoBehaviour
{
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
