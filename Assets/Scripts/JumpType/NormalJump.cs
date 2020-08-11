using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalJump : MonoBehaviour, IJump
{
    public void DoJump(Rigidbody rigidbody)
    {
        rigidbody.AddForce(new Vector2(0, 400f));
    }
}
