using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeadDetect : MonoBehaviour
{
    // Start is called before the first frame update
    
    GameObject boss;
     public int health;
    public int damage;
    private float timeBtwDamage = 1.5f;
    public Animator camAnim;
    public Slider healthBar;
    private Animator anim;

    GameManager gm;

    void Start()
    {
        boss = gameObject.transform.parent.gameObject;
        gm = GameManager.GetInstance();
    }

    void Update()
    {
        if (health <= 5) {
        }

        if (health <= 0) {
            Destroy(boss);
            gm.win = true;
            
        }

        if (timeBtwDamage > 0) {
            timeBtwDamage -= Time.deltaTime;
        }

        healthBar.value = health;
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            health--;
            // Vector3 movement = new Vector3(Random.Range(-10,10),0f, 0f);
            // boss.transform.position += movement;
        }
    }
}
