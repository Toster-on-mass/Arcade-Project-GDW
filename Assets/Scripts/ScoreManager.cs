using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public PackageManager packageManager;

    public TextMeshProUGUI textPackages;
    public TextMeshProUGUI textCaught;
    public TextMeshProUGUI gameWon;
    public TextMeshProUGUI textPressToRestart;

    public int packagesDelivered = 0;
    public int timesCaught = 0;

    public int packagesNeededForWin = 10;
    public int timesCaughtNeededForWin = 10;

    private bool gameOver = false;

    private void Start()
    {
        gameWon.text = "";
        textPressToRestart.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (gameOver && (Input.GetKeyUp(KeyCode.KeypadEnter) || Input.GetKeyUp(KeyCode.Return)))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void IncreasePackagesDelivered(int amount)
    {
        if (amount != 0 && !gameOver)
        {
            packagesDelivered += amount;
            packageManager.ResetPackages();
            textPackages.text = "Packages Got: " + packagesDelivered;
            if (packagesDelivered >= packagesNeededForWin)
            {
                gameWon.text = "Deliverer wins!";
                gameOver = true;
                textPressToRestart.gameObject.SetActive(true);
            }
        }
        
    }

    public void IncreaseTimesCaught(int amount)
    {
        if (!gameOver)
        {
            timesCaught += amount;
            textCaught.text = "Times Caught: " + timesCaught;

            if (timesCaught >= timesCaughtNeededForWin)
            {
                gameWon.text = "Catcher wins!";
                gameOver = true;
                textPressToRestart.gameObject.SetActive(true);
            }
        }
        

    }
}
