using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sight : MonoBehaviour
{
    public GameObject Player1;
    
    
    public GameObject Enemy1;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 Player = Player1.transform.position;
        Vector2 Enemy = Enemy1.transform.position;
        float dot = Vector2.Dot(Player, Enemy);
        float mag = ((Player.x * Player.x) + (Player.y * Player.y)) * ((Enemy.x * Enemy.x) + (Enemy.y * Enemy.y));

        float results = Mathf.Acos(dot / mag)* Mathf.Rad2Deg;
        Debug.Log(results + "$$$$");
        if(results <= 25 || results >= 50)
        {
            //gameObject.GetComponent<Pathfinding.AIDestinationSetter>().enabled = true;
            //gameObject.GetComponent<JimsCrazySolution>().enabled = false;
        }
        else 
        { 
            gameObject.GetComponent<Pathfinding.AIDestinationSetter>().enabled = false;
            gameObject.GetComponent<JimsCrazySolution>().enabled = true;
        }
    }
}
