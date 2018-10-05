using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Breakable"))  //If the object has a breakable Tag ...
        {
            other.GetComponent<Pot>().Smash(); // Then call the method smash from the component/script "Pot" from the collided object
            
        }
    }
}
