using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Author: D. DiMuzio
/// Attached to ball object, listens for collisions to call game over or increment core and move the goal
/// </summary>
public class BallScript : MonoBehaviour {

    public float minX = -23f;
    public float minY = 6f;
    public float minZ = -20f;
    public float maxX = 23f;
    public float maxY = 25f;
    public float maxZ = 20f;
    private int score;
    private GameObject goal;
    private Text scoreGUILbl;

    /// <summary>
    /// Scene init
    /// </summary>
    void Start ()
    {
        this.score = 0;
        this.goal = GameObject.FindGameObjectWithTag("Goal");
        this.scoreGUILbl = GameObject.FindGameObjectWithTag("PlayerScore").GetComponent<Text>();
    }

    /// <summary>
    /// Collision listener for ball
    /// </summary>
    /// <param name="collision"></param>
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Ground")
        {
            // call "GameOver" function in script attached to "Ground" object
            GameObject.FindGameObjectWithTag("Ground").GetComponent<GameUI>().GameOver(this.score);
        }
        else if (collision.collider.tag == "Goal")
        {
            // move goal to new random location in game field
            float x = Random.Range(minX, maxX);
            float y = Random.Range(minY, maxY);
            float z = Random.Range(minZ, maxZ);

            Vector3 newPos = new Vector3(x, y, z);
            this.goal.transform.position = newPos;

            this.scoreGUILbl.text = (this.score + 1).ToString();
            this.score += 1;
        }
    }
}
