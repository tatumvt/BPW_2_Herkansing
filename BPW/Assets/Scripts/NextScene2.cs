using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextScene2 : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player2")
        {
            nextScene.playerreach = nextScene.playerreach + 1;
        }
    }
}
