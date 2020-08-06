using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cleanup : MonoBehaviour
{
    public float cleanupTime = 3;

    private void Awake()
    {
        Destroy(gameObject, cleanupTime);
    }
}
