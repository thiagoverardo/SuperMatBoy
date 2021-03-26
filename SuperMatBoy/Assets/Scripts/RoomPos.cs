using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomPos : MonoBehaviour
{
    public float waitTime;
    public LayerMask whatIsRoom;
    bool hasRoom;
    public GameObject[] rooms;

    void Update()
    {
        Collider2D room = Physics2D.OverlapCircle(transform.position, 1, whatIsRoom);
        if (room != null)
        {
            hasRoom = true;
        }

        if (waitTime <= 0)
        {
            if (!hasRoom)
            {
                int randRoom = Random.Range(0, rooms.Length);
                Instantiate(rooms[randRoom], transform.position, Quaternion.identity);
            }
        }
        else
        {
            waitTime -= Time.deltaTime;
        }
    }
}
