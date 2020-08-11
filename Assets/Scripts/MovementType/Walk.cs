using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : MonoBehaviour,IMovement
{
    public void DoMove(Rigidbody rigidbody, int direction)
    {
     rigidbody.velocity = new Vector2 (direction * 5, rigidbody.velocity.y);
    }
}
