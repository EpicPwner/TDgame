using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack : MonoBehaviour {

    public float thrust;  //base knockback: 20
    public float knockTime;  //base knockTime: 0.05

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Breakable") && this.gameObject.CompareTag("Player" ))  //If the object has a breakable Tag ...
        {
            other.GetComponent<Pot>().Smash(); // Then call the method smash from the component/script "Pot" from the collided object

        }

        if (other.gameObject.CompareTag("Enemies") || other.gameObject.CompareTag("Player") )  //If the object is an enemy....
        {
            Rigidbody2D hit = other.GetComponent<Rigidbody2D>();      //get the other object rigidbody
            if (hit != null)  //If tje enemy has a rigidbody ...
            {
                Vector2 difference = hit.transform.position - transform.position; //get a vector between the enemy and the player
                difference = difference.normalized * thrust;  //normalize transforms the vector into length 1, then multiply by thrust (Obtain the direction and true length of the force
                hit.AddForce(difference, ForceMode2D.Impulse);    //add a force to other object (enemY) of type Impulse
                if (other.gameObject.CompareTag("Enemies"))
                {
                    hit.GetComponent<Enemy>().currentState = EnemyStates.stagger; //change states of the Enemy Script of the object/enemy to stagger
                    other.GetComponent<Enemy>().KnockBack(hit, knockTime);      //Runs the knockback method from the Enemy Script
                }
                if (other.gameObject.CompareTag("Player"))
                {
                    hit.GetComponent<PlayerMovement>().currentState = PlayerState.stagger; //change states of the PlayerMovement Script of the object/player to stagger
                    other.GetComponent<PlayerMovement>().KnockBack(knockTime);  //Runs the knockback method from the PlayerMovement Script
                }
            }
        }


    }

}
