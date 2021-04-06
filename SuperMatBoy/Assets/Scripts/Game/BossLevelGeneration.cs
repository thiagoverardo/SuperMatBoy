using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossLevelGeneration : MonoBehaviour
{
    public Transform startingPosition;
    public GameObject[] rooms; // index 0 --> LR, index 1 --> LRB, index 2 --> LRT, index 3 --> LRBT
    private int direction;
    private bool stopGeneration;
    private int downCounter;
    private float timeBtwSpawn;
    public LayerMask whatIsRoom;
    public GameObject flag;
    private void Start()
    {
        transform.position = startingPosition.position;
        Instantiate(rooms[0], transform.position, Quaternion.identity);
        direction = Random.Range(1, 6);
    }

    private void Update()
    {
    }
}
