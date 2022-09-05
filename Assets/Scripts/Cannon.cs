using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{

    public GameObject cannonBall;
    float RotationSpeed = 0.025f;
    public Transform shootPoint;

    private float BallSpeed = 5f;
    public float ballspeed {get {return BallSpeed;}}
    public float moveSpeed= 0.01f;

    float HorizontalRotation;
    float PowerDirection;

    int maxHealth = 100;

    int currentHealth;
    float timetoshoot =1f;
    float shoottime =0;

    bool isDead =false;
    public bool isdead {get{return isDead;}}


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        shoottime=timetoshoot;
    }

    // Update is called once per frame
    void Update()
    {   
        shoottime +=Time.deltaTime;
        Movement();
        increasePower();
        if (Input.GetKeyDown(KeyCode.Space) && shoottime>=timetoshoot)
        {
            Shoot();
        }

        if(currentHealth<=0)
        {
            Destroy(gameObject);
            isDead =true;
        }


        

    }

    public void Shoot()
    {
        GameObject newBall = Instantiate(cannonBall, shootPoint.position, shootPoint.rotation);
        newBall.GetComponent<Rigidbody2D>().velocity = shootPoint.transform.right * BallSpeed;
        newBall.GetComponent<Projectile>().isEnemy =false;
        shoottime =0;
    }


    public void Movement()
    {
        HorizontalRotation = Input.GetAxis("Horizontal");
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0,0,HorizontalRotation*RotationSpeed*-1));
        if(Input.GetKey(KeyCode.Q))
        {
            transform.position += Vector3.left*moveSpeed*Time.deltaTime;

            if(transform.position.x<= -10)
            {
                transform.position = new Vector3 (-10, transform.position.y, 0);
            }
        }
        if(Input.GetKey(KeyCode.E))
        {
            transform.position += Vector3.right*moveSpeed*Time.deltaTime;

            if(transform.position.x >= -7)
            {
                transform.position = new Vector3 (-7, transform.position.y, 0);
            }
        }
    }

    public void increasePower()
    {
        PowerDirection = Input.GetAxis("Vertical");
        BallSpeed += PowerDirection *RotationSpeed ;
    }

    public void TakeDamage(int _damage)
    {
        currentHealth -= _damage;

    }
}
