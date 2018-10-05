using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class sign : MonoBehaviour {

    public GameObject dialogBox;
    public Text dialogText;
    public string dialog;
    public bool PlayerInRange;
    
    

	void Start () {
		
        
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Space) && PlayerInRange)
        {
            if (dialogBox.activeInHierarchy)
            {

                dialogBox.SetActive(false);
            }
            else
            {
                dialogBox.SetActive(true);
                dialogText.text = dialog;
            }

        }

	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInRange = true;
            transform.GetChild(0).gameObject.SetActive(true);

        }
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInRange = false;
            dialogBox.SetActive(false);
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}

