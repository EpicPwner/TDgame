using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogEnemy : Enemy {

    private Rigidbody2D enemyRigibody;
    public Transform homePosition; 
    public Transform target;
    public float chaseRadius;
    public float attackRadius;


	// Use this for initialization
	void Start () {

        currentState = EnemyStates.idle;
        enemyRigibody = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player").transform; // get the transform of the Player object.
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        CheckDistance();    
	}

    void CheckDistance()
    {
        if (Vector3.Distance(target.position, transform.position) <= chaseRadius && Vector3.Distance(target.position, transform.position) > attackRadius)      //if the position of target (Player) and the position of the object with this script (Distance Vector3) is less or equals to the chaseRadius...
        {                                                                                                                                                       //...and if Distance Vector3 is greater than the attackRadius...
            if (currentState == EnemyStates.idle || currentState == EnemyStates.walk && currentState != EnemyStates.stagger)
            {
            Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime); //...then store a MoveToward vector( <inicial position>, <end position>, <units to move by time elapsed> ) in the objects transform
            enemyRigibody.MovePosition(temp); //use that MoveToward vector (temp) with the method RigidBody2D.MovePosition
            ChangeState(EnemyStates.walk);   //Change state to walk (method ChangeState) to the Enemy script derived enum EnemyStates
            }
        }
    }

    private void ChangeState (EnemyStates newState)         //Method that takes in one state from the EnemyStates enum
    {
        if (currentState != newState)    //if the current state is already the new state...
        {
            currentState = newState;    //...then change the current state to the new state
        }
    }

}
