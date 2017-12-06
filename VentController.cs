using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Attached to "Vent" Game Object.
/// </summary>
public class VentController : MonoBehaviour
{
    public float speed;
    public Vector3 size;
    private AudioSource airSound;
    public Image powerBar;
    private GameObject air;
    private Vector3 airSpeed;
    private float originalAirPosY;

    /// <summary>
    /// Scene init
    /// </summary>
    void Start()
    {
        speed = 0.2f;
        this.airSound = gameObject.GetComponentInChildren<AudioSource>();
        this.powerBar = GameObject.FindObjectsOfType<Image>()[0];
        this.air = GameObject.FindGameObjectWithTag("Air");
        this.originalAirPosY = air.transform.position.y;
        this.airSpeed = new Vector3(0, 0.5f, 0);
        Physics.IgnoreLayerCollision(9, 0, true); // set air layer to ignore default layer (ball is in its own layer)
        Physics.gravity = new Vector3(0, -1.0F, 0);
        this.air.GetComponent<MeshRenderer>().enabled = false;
    }

    /// <summary>
    /// Every scene frame after "Update" - listener for keyboard press
    /// </summary>
    void FixedUpdate()
    {
        // get current vent position
        Vector3 pos = this.transform.position;

        // listen for keyboard input and change vent position based
        if (Input.GetKey(KeyCode.A))
        {
            pos.x += -speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            pos.x += speed;
        }
        if (Input.GetKey(KeyCode.W))
        {
            pos.z += speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            pos.z += -speed;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            this.powerBar.fillAmount -= 0.01f;
        }
        else
        {
            this.powerBar.fillAmount += .005f;
        }

        this.transform.position = pos; // update vent's position
    }

    /// <summary>
    /// Every scene frame
    /// </summary>
    void Update()
    {
        // play air sound if "space" is currently being pressed and change battery level
        if (Input.GetKeyDown("space"))
        {
            if (this.powerBar.fillAmount <= 0.1f)
            {
                this.airSound.Stop();
            }
            else
            {
                this.airSound.Play();
            }
        }
        else if (Input.GetKeyUp("space"))
        {
            this.airSound.Stop();
        }

        //   Score += 15 - (FloatingObject.transform.position.y - rb.transform.position.y);
        //FloatingObjectPos = FloatingObject.transform.position;
        if (Input.GetKey(KeyCode.Space) && this.powerBar.fillAmount > 0.0009f) // listen for space bar press and move if theirs enough battery
        {
            if (this.air.transform.position.y < 25f) // set max range of air
            {
                this.air.transform.position += this.airSpeed; // move "air" in y direction
            }        
        }
        else
        {
            this.air.transform.position = new Vector3(this.air.transform.position.x, this.originalAirPosY, this.air.transform.position.z);
        }
    }
}
