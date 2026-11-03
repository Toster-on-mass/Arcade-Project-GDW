using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public PackageManager packageManager;

    public int packagesDelivered = 0;
    public int timesCaught = 0;
    

    public void IncreasePackagesDelivered(int amount)
    {
        if (amount != 0)
        {
            packagesDelivered += amount;
            packageManager.ResetPackages();
        }
        
    }

    public void IncreaseTimesCaught(int amount)
    {
        timesCaught += amount;
    }
}
