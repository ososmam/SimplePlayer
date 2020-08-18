using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalJump : MonoBehaviour, IJump
{
    public void Do (Player player)
    {
        player.mainRigidbody.AddForce (new Vector2 (0, 400f));
    }
}