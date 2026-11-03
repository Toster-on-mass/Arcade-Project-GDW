using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public PackageManager packageManager;

    public TextMeshProUGUI textPackages;
    public TextMeshProUGUI textCaught;

    public int packagesDelivered = 0;
    public int timesCaught = 0;
    

    public void IncreasePackagesDelivered(int amount)
    {
        if (amount != 0)
        {
            packagesDelivered += amount;
            packageManager.ResetPackages();
            textPackages.text = "Packages Got: " + packagesDelivered;
        }
        
    }

    public void IncreaseTimesCaught(int amount)
    {
        timesCaught += amount;
        textCaught.text = "Times Caught: " + timesCaught;
    }
}
