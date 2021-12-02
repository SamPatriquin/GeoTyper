using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    [FormerlySerializedAs("Screen")] public GameObject screen;
    [FormerlySerializedAs("Message")] public Text message;
    [FormerlySerializedAs("ScoreDisplay")] public Text scoreDisplay;
    [FormerlySerializedAs("WPMDisplay")] public Text wpmDisplay;
    [FormerlySerializedAs("ReplayButton")] public Button replayButton;
    [FormerlySerializedAs("ExitButton")] public Button exitButton;
    
    // Start is called before the first frame update
    void Start()
    {
        replayButton.onClick.AddListener(ReplayScene);
        exitButton.onClick.AddListener(ExitScene);
    }

    public void Activate(int score, float wpm)
    {
        screen.SetActive(true);
        Debug.Log($"Score: {score}; WPM: {wpm:F1}");
        scoreDisplay.text = $"Score: {score}";
        wpmDisplay.text = $"WPM: {wpm:F1}";
        if (wpm >= 20)
        {
            message.text = "Good work!";
        }
        else
        {
            message.text = "Not bad, but you could use some more practice. Try to aim for about 20 words per minute.";
        }
    }

    private void ReplayScene()
    {
        // add method for saving high score later
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void ExitScene()
    {
        // add method for saving high score later
        SceneManager.LoadScene(0);
    }

    public bool IsActive()
    {
        return screen.activeInHierarchy;
    }
}
