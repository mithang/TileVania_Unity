using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // configuration parameters
    [SerializeField] float moveSpeed = 1f;

    // cached references
    Rigidbody2D myRigidBody;

    private void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (IsFacingRight())
        {
            myRigidBody.velocity = new Vector2(moveSpeed, 0);
        }
        else
        {
            myRigidBody.velocity = new Vector2(-moveSpeed, 0);
        }
    }

    private bool IsFacingRight()
    {
        return transform.localScale.x > 0;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.localScale = new Vector2(-Mathf.Sign(myRigidBody.velocity.x), 1f);
    }
}
