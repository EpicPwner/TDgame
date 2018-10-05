using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState     //enums are similar to bool but instead of having only two states (true or false) can have has many has it wants
{
    walk,
    attack,
    interact,
    stagger,
    idle
}                           //This enum let's us change the state of the players actions to control it in game and in script

public class PlayerMovement : MonoBehaviour {


    public PlayerState currentState;        //Declare a variable for the current state of PlayerState, only one state active at a time.
    public float speed;
    public float staggerTime;
    private Rigidbody2D myRigidbody; //Name a reference to the objects rigidbody
    private Vector3 change;
    private Animator animator;  //Name a reference to the objects animator


	// Use this for initialization
	void Start ()
    {
        currentState = PlayerState.walk;   //Initialize the state has walk state.
        animator = GetComponent<Animator>();    //complete the referen to the objects component (animator)
        myRigidbody = GetComponent<Rigidbody2D>(); //complete the reference to the objects component (rigidbody)
        animator.SetFloat("moveX", 0);
        animator.SetFloat("moveY", -1); //These two lines fix the animator so only the right hitboxes show up at the correct orientation
    }
	
	// Update is called once per frame
	void Update ()
    {
        change = Vector2.zero; //Every frame resets the ammount of change
        change.y = Input.GetAxisRaw("Vertical");    //Side tip: GetAxis has a progression associated with it's value
        change.x = Input.GetAxisRaw("Horizontal");  // GetAxisRaw has no progression and transforms the value instantly

        if (Input.GetButtonDown("attack") && currentState != PlayerState.attack && currentState != PlayerState.stagger)  //the button attack is setup in : Edit > Project Settings > Input, after that add 1 to size to create a duplicate of the last button. Costumize it.
        {                                                                           //If the player state is different than attack and the attack key was pressed
            StartCoroutine(AttackCo());
        }
        else if (currentState == PlayerState.walk || currentState == PlayerState.idle)
        {
            UpdateAnimationAndMove();
        }
        
    }

    private IEnumerator AttackCo()
    {

        animator.SetBool("attacking", true);    //change the animator bool "attacking" to true (runs the attack animation)
        currentState = PlayerState.attack;      //change the current state to attack.    
        yield return null;  //wait only one frame
        animator.SetBool("attacking", false); //change the animator bool "attacking" to false (switches animation to idle)
        yield return new WaitForSeconds(0.2f);
        currentState = PlayerState.walk;
    }

    void UpdateAnimationAndMove()
    {
        if (change != Vector3.zero) //If there is a change
        {
            MoveCharacter();        //Call Method for movement
            // Animations
            animator.SetFloat("moveX", change.x); // Animator Float moveX is updated to the current change value for X
            animator.SetFloat("moveY", change.y); // Animator Float moveY is updated to the current change value for Y
            animator.SetBool("moving", true);
        }
        else
        {
            animator.SetBool("moving", false);
        }
    }

    void MoveCharacter()
    {
        change.Normalize();
        myRigidbody.MovePosition(transform.position + change * speed * Time.deltaTime); //Transform Position by the amount of change
    }

    public void KnockBack(float knockTime)
    {
        StartCoroutine(KnockBackCo(knockTime));
    }

    private IEnumerator KnockBackCo(float knockTime)
    {
        if (myRigidbody != null)
        {
            yield return new WaitForSeconds(knockTime);         //After knocktime
            myRigidbody.velocity = Vector2.zero;                      //Reset object velocity
            yield return new WaitForSeconds(staggerTime);       //Wait
            currentState = PlayerState.idle; // Change states
            myRigidbody.velocity = Vector2.zero;
        }
    }

}
