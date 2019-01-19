using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomTrigger : MonoBehaviour
{

    public GameObject player;
    public GameObject GameInfo;
    public Camera cam;

    public Vector3 playerDestination;
    public Vector3 cameraDestination;
    public Text roomDescription;
    public string roomTitle;
    public bool sceneSwitch;

    public Vector2 newMaxPosition;
    public Vector2 newMinPosition;

    public bool exit;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (sceneSwitch == false)
        {
            if (collision.CompareTag("Player"))
            {
                if (exit == false)
                {
                    cam.GetComponent<CameraMovement>().enabled = false;
                    cam.transform.position = cameraDestination;
                    collision.transform.position = playerDestination;
                    StartCoroutine("RoomTextFade");
                }

                else if (exit == true)
                {
                    collision.transform.position = playerDestination;
                    cam.transform.position = cameraDestination;
                    cam.GetComponent<CameraMovement>().enabled = true;
                }

            }
        }
        if(sceneSwitch == true)
        {
            if(collision.CompareTag("Player"))
            {
                collision.transform.position = playerDestination;
                cam.transform.position = cameraDestination;
                cam.GetComponent<CameraMovement>().maxPosition = newMaxPosition;
                cam.GetComponent<CameraMovement>().minPosition = newMinPosition;
            }
        }
        
    }

    private IEnumerator RoomTextFade()
    {
        roomDescription.enabled = true;
        roomDescription.GetComponent<Text>().text = roomTitle;
        roomDescription.GetComponent<Text>().CrossFadeAlpha(0, 3.0f, false);
        yield return new WaitForSeconds(4.0f);
        roomDescription.enabled = false;

    }
}
