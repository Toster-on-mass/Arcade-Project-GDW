using UnityEngine;

public class PlayerPackageCollection : MonoBehaviour
{
    public ScoreManager scoreManager;
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
        else if (other.CompareTag("Delivery Spot"))
        {
            scoreManager.IncreasePackagesDelivered(packagesCollected);
            ResetCollectedPackages();
        }
    }
}
