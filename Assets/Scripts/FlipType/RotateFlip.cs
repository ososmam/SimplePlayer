using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateFlip : MonoBehaviour, IFlip
{
    public void DoFlip(Rigidbody rigidbody)
    {
        rigidbody.angularVelocity = new Vector3(0,0,rigidbody.angularVelocity.z+2);
    }
}
