using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiveAttack : MonoBehaviour, IAttack
{
    public void Do ()
    {
        Debug.Log ("Attack");
    }
}