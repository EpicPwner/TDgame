using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomMovement : MonoBehaviour {

    public Vector2 cameraChange;
    public Vector3 playerChange;
    private CameraMovement cam;  //Declare a reference to the CameraMovement script
    public bool needText;
    public string placeName;
    public GameObject text;
    public Text placeText;

	// Use this for initialization
	void Start () {
        cam = Camera.main.GetComponent<CameraMovement>(); //Complete the reference for the Camera Script, gives you acess to the Scripts vars and methods
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) //Compare Tag of RoomTransfer Object with PlayerObject
        {
            cam.minPosition += cameraChange;
            cam.maxPosition += cameraChange;
            other.transform.position += playerChange;
            if (needText)
            {
                StartCoroutine(placeNameCO());

            }

        }

    }

    private IEnumerator placeNameCO()
    {

        text.SetActive(true);
        placeText.text = placeName;
        yield return new WaitForSeconds(3f);
        text.SetActive(false);
    }
}
