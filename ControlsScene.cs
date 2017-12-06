using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Author: D. DiMuzio
/// Attached to Controls Scene camera, displays UI for game controlz
/// </summary>
public class ControlsScene : MonoBehaviour
{
    public Texture MainMenuBackgroundTexture;
    public Texture aswd;
    public Texture arrows;
    private GUIStyle directionsStyle;

    /// <summary>
    /// Scene init
    /// </summary>
    void Start()
    {
        this.directionsStyle = new GUIStyle();
        this.directionsStyle.fontSize = 28;
        this.directionsStyle.normal.textColor = Color.blue;
    }

    /// <summary>
    /// Render UI
    /// </summary>
    public void OnGUI()
    {
        // display background texture
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), MainMenuBackgroundTexture);
        GUI.skin.label.font = Resources.GetBuiltinResource<Font>("Arial.ttf");

        // "Controls"
        GUI.Label(new Rect(Screen.width * 0.5f - 170, Screen.height * 0.5f - 300, 450, 100), "Controls");

        // "aswd" image
        GUI.DrawTexture(new Rect(Screen.width * 0.5f - 350, Screen.height * 0.5f - 175, 200, 150), this.aswd);
        // "aswd" directions
        GUI.Label(new Rect(Screen.width * 0.5f - 140, Screen.height * 0.5f - 100, 400, 100), "--> Vent directional movement", this.directionsStyle);

        // "arrows" image
        GUI.DrawTexture(new Rect(Screen.width * 0.5f - 350, Screen.height * 0.5f + 50, 200, 150), this.arrows);
        // "arrows" directions
        GUI.Label(new Rect(Screen.width * 0.5f - 140, Screen.height * 0.5f + 100, 450, 100), "--> Camera rotation controls", this.directionsStyle);

        // back button
        if (GUI.Button(new Rect(Screen.width * 0.5f - 150, Screen.height * 0.5f + 250, 300, 75), "Back"))
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
