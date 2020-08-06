using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelManager : MonoBehaviour
{
    public static levelManager instance;

    public Transform spawnPoint;
    public GameObject playerObject;
    public GameObject playerMovePoint;
    public Transform spawnPointRight;
    public GameObject playerObjectRight;
    public GameObject playerMovePointRight;

    private void Awake()
    {
        instance = this;
    }

    public void Respawn()
    {
        //player side view
        playerObject.transform.position = spawnPoint.position;
        playerMovePoint.transform.position = spawnPoint.position;
        //player top down view
        playerObjectRight.transform.position = spawnPointRight.position;
        playerMovePointRight.transform.position = spawnPointRight.position;
    }
}
