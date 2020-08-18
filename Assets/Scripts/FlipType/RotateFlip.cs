using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateFlip : MonoBehaviour, IFlip
{
    public void Do(Player player)
    {
       player.mainRigidbody.angularVelocity = new Vector3(0,0,player.mainRigidbody.angularVelocity.z+2);
    }
}
