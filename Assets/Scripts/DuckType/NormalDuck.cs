using UnityEngine;

public class NormalDuck : MonoBehaviour, IDuck
{
    public void Do (Player player)
    {
        Debug.Log ("Normal Duck");
    }
}