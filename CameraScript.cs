using UnityEngine;

/// <summary>
/// Author: D. DiMuzio
/// Script attached to Camera game object, 
/// </summary>
public class CameraScript : MonoBehaviour
{
    public GameObject vent;
	private float speed = 150.0f;
    //private Vector3 OffsetForCam;

    /// <summary>
    /// Scene init
    /// </summary>
	void Start ()
    {
		// set default camera offset from player
        //OffsetForCam = transform.position - vent.transform.position;
	}

	/// <summary>
    /// Every scene frame after "Update"
    /// </summary>
	void FixedUpdate()
    {
        // rotate camera around vent based on initial camera offset and player input
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.RotateAround(vent.transform.position, Vector3.up, speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.RotateAround(vent.transform.position, Vector3.up, -speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.RotateAround(vent.transform.position, vent.transform.TransformDirection(Vector3.right), speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.RotateAround(vent.transform.position, vent.transform.TransformDirection(Vector3.right), -speed * Time.deltaTime);
        }

        transform.LookAt(vent.transform); // set camera to always be looking at vent
    }

    /// <summary>
    /// Use collider hack to make anything inbetween the camera and the player invsible, except for the ground
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player" && other.tag != "Ground" && other.tag !=  "Floating" && other.tag != "Ball" && other.tag != "Goal")
        {
            other.gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
    }

    /// <summary>
    /// When collider exits, show previously collider visible again
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerExit(Collider other)
    {
        other.gameObject.GetComponent<MeshRenderer>().enabled = true;
    }
}
