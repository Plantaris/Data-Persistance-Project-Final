using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEngine;

public class PlayerNameDisplay : MonoBehaviour
{

    public TMP_Text playerNameText;  // reference to the TextMEshPro text entry element
    public MainManager mainManager;

    private int highScore;
    private string playerName;

    
    // Start is called before the first frame update
    void Start()
    {
        mainManager = FindAnyObjectByType<MainManager>();

        // Get the current player name
        playerName = GameData.PlayerName;
        string highScoreKey = playerName + "_HighScore";

        // Load the high score from PlayerPrefs using the player-specific key
        highScore = PlayerPrefs.GetInt(highScoreKey, 0);
        playerNameText.text = playerName + "'s High Score: " + highScore;  // Sets the text to the entered player name and high score

        if (mainManager != null)
        {
            mainManager.OnScoreChanged += UpdateScoreDisplay;
            mainManager.AddPoint(0);
        }
    }

    private void UpdateScoreDisplay(int newScore)
    {
        if (newScore > highScore)
        {
            highScore = newScore;
            string highScoreKey = playerName + "_HighScore";
            PlayerPrefs.SetInt(highScoreKey, highScore);  // Save the new high score using the player-specific key
        }
        playerNameText.text = playerName + "'s High Score: " + highScore;
    }

    private void OnDestroy()
    {
        if (mainManager != null)
        {
            mainManager.OnScoreChanged -= UpdateScoreDisplay;
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }

   
}
