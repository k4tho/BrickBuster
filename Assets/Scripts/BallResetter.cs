using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallResetter : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Game.Instance.LoseBall();
    }
}
