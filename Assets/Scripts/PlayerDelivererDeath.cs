using UnityEngine;

public class PlayerDelivererDeath : MonoBehaviour
{
    private Vector3 startPos;
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Catcher"))
        {
            transform.position = startPos;
        }
    }
}
