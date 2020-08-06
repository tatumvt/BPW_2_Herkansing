using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killPlayer : MonoBehaviour
{

    public GameObject deadSplat;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (deadSplat != null)
            {
                Instantiate(deadSplat, gameObject.transform.position, Quaternion.identity);
            }
            levelManager.instance.Respawn();
           
        }
    }
}
