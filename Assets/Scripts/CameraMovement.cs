using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public Transform target;
    public float smoothing;
    public Vector2 maxPosition;
    public Vector2 minPosition;


	void Start ()
    {
		

	}
	

	void LateUpdate ()
    {

        if (transform.position != target.position) //If the position of the camera is diferent from the target position
        {
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
            targetPosition.x = Mathf.Clamp(target.position.x, minPosition.x, maxPosition.x);
            targetPosition.y = Mathf.Clamp(target.position.y, minPosition.y, maxPosition.y);
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing); //Lerp: Move a percentage (smoothing) from point A (transform.position) to point B (target.postion)

        }
	}
}
