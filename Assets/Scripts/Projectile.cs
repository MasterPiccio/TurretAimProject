using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public bool isEnemy;

    public int Damage = 20;

    float TimeToDestruction =10f;
    float WaitedTime =0;

    GameController gameController;

    public LayerMask layer;
    // Start is called before the first frame update
    void Start()
    {
        gameController = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        WaitedTime +=Time.deltaTime;
        if(WaitedTime >=TimeToDestruction)
        {
            Destroy(gameObject);
        }
    }


    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.transform.tag == "Player" && !isEnemy)
        {
            Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(),other.collider);
        }
        
        if(other.transform.tag == "Enemy" && isEnemy)
        {
            Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), other.collider);
        }

        if(other.transform.tag=="Enemy" && !isEnemy)
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            gameController.IncreaseScore(10);
        }
        if(other.transform.tag =="Player" && isEnemy)
        {   

            other.gameObject.GetComponent<Cannon>().TakeDamage(Damage);
        }

        Destroy(gameObject);
    }




}
