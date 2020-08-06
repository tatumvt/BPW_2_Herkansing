using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killMovePoint : MonoBehaviour
{
     private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            
            Debug.Log("ded");
            levelManager.instance.Respawn();
        }
    }
}
