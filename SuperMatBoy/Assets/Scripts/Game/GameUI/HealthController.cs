using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    GameManager gm;
    public Sprite[] hearthsArray;
    void Start()
    {
        gm = GameManager.GetInstance();
    }
    void Update()
    {
        ChangeSprite();

        //REMOVER DEPOIS
        if (Input.GetKeyDown(KeyCode.H))
        {
            if (gm.lifes > 0)
            {
                gm.lifes--;
            }
        }
    }

    void ChangeSprite()
    {
        if(gm.lifes < 0){
            return;
        }
        gameObject.GetComponent<Image>().sprite = hearthsArray[gm.lifes];
    }
}
