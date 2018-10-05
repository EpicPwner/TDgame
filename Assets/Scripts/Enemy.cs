using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyStates{
    idle,
    walk,
    attack,
    stagger
        
}

public class Enemy : MonoBehaviour {


    public EnemyStates currentState;
    public string enemyName;
    public int health;
    public int baseAttack;
    public float moveSpeed;
    public float staggerTime;

    public void KnockBack(Rigidbody2D myRigidBody,float knockTime) {

        StartCoroutine(KnockBackCo(myRigidBody, knockTime));
    }

    private IEnumerator KnockBackCo(Rigidbody2D myRigidbody, float knockTime)
    {
        if (myRigidbody != null)
        {
            yield return new WaitForSeconds(knockTime);         //After knocktime
            myRigidbody.velocity = Vector2.zero;                      //Reset object velocity
            yield return new WaitForSeconds(staggerTime);       //Wait
            currentState = EnemyStates.idle; // Change states
            myRigidbody.velocity = Vector2.zero;                      //Reset object velocity


        }
    }

}
