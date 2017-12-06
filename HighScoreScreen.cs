using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Author: D. DiMuzio
/// Attached to High Score Scene's camera, shows current top player
/// </summary>
public class HighScoreScreen : MonoBehaviour {

    private int highScore;
    private string topPlayer;
    public Texture MainMenuBackgroundTexture;
    private GUIStyle scoreStyle;

    /// <summary>
    /// Scene init
    /// </summary>
    void Start ()
    {
        // get current top player and their score, if none found set default values
        this.highScore = PlayerPrefs.GetInt("High Score", 3);
        this.topPlayer = PlayerPrefs.GetString("Top Player", "---");

        this.scoreStyle = new GUIStyle();
        this.scoreStyle.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
        this.scoreStyle.fontSize = 42;
        this.scoreStyle.normal.textColor = Color.blue;
    }

    /// <summary>
    /// Renders UI
    /// </summary>
    public void OnGUI()
    {
        // display background texture
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), MainMenuBackgroundTexture);

        // "High Score"
        GUI.Label(new Rect(Screen.width * 0.5f - 160, Screen.height * 0.5f - 300, 450, 100), "High Score");

        // "PLayer: score"
        GUI.Label(new Rect(Screen.width * 0.5f - 80, Screen.height * 0.5f - 100, 300, 300), this.topPlayer + ": " + this.highScore, this.scoreStyle);

        // "Back" button
        if (GUI.Button(new Rect(Screen.width * 0.5f - 150, Screen.height * 0.5f + 150, 300, 75), "Back"))
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
