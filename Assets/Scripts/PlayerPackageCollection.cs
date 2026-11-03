using UnityEngine;

public class PlayerPackageCollection : MonoBehaviour
{
    public int packagesCollected = 0;
    void Start()
    {
        
    }



    public void ResetCollectedPackages()
    {
        packagesCollected = 0;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Package"))
        {
            Destroy(other.gameObject);
            packagesCollected++;
        }
    }
}
