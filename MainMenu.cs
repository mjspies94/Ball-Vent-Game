using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public Texture MainMenuBackgroundTexture;
    public Font titleFont;

    /// <summary>
    /// Runs at start of game, if no high score exists then set default of 500.
    /// </summary>
    void Start()
    {

        //PlayerPrefs.DeleteAll ();// TEMP : for the love of God please delete this line or comment it out - Dom

        // set default "High Score" if none exists
        if (!PlayerPrefs.HasKey("High Score"))
        {
            PlayerPrefs.SetInt("High Score", 3);
            PlayerPrefs.SetString("Top Player", "---");
        }
    }

    /// <summary>
    /// Create GUI
    /// </summary>
    public void OnGUI()
    {

        // display background texture
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), MainMenuBackgroundTexture);

        // style volume label component
        GUI.skin.label.fontSize = 85;
        GUI.skin.label.normal.textColor = Color.blue;
        GUI.skin.label.font = titleFont;

        GUI.Label(new Rect(Screen.width * 0.5f - 215, Screen.height * 0.5f - 300, 470, 100), "Ball Vent Game");

        // ** "if" statements are essentially click listeners

        // start button
        if (GUI.Button(new Rect(Screen.width * 0.5f - 250, Screen.height * 0.5f - 150, 500, 75), "Start Game"))
        {
            SceneManager.LoadScene("MainGame");
        }

        // high score button
        if (GUI.Button(new Rect(Screen.width * 0.5f - 250, Screen.height * 0.5f - 50, 500, 75), "High Score"))
        {
            SceneManager.LoadScene("HighScoreScene");
        }

        // controls button
        if (GUI.Button(new Rect(Screen.width * 0.5f - 250, Screen.height * 0.5f + 50, 500, 75), "Controls"))
        {
            SceneManager.LoadScene("ControlsScene");
        }

        // options button
        //if (GUI.Button(new Rect(Screen.width * 0.5f - 250, Screen.height * 0.5f + 150, 500, 75), "Settings"))
        //{
        //    SceneManager.LoadScene("Settings");
        //}

        // quit button
        if (GUI.Button(new Rect(Screen.width * 0.5f - 250, Screen.height * 0.5f + 250, 500, 75), "Quit"))
        {

            Application.Quit();
        }
    }
}
