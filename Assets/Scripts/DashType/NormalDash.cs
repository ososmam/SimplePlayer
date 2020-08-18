using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalDash : MonoBehaviour, IDash
{
    public void Do(Player player)
    {
        Debug.Log ("Normal Dash");
    }
}
