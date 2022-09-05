using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public GameObject cannonBall;

    GameController gameController;

    public Transform EnemyCannon;
    public Transform firepoint;

    public Cannon player;

    Spawner spawner;

    
    public float waitTime = 3f;
    public float elapsedTime =0;

    [SerializeField]float BallSpeed = 5f;
    public float ballspeed {get {return BallSpeed;}}

    private bool IsOnTarget =false;
    public bool ontarget {get  { return IsOnTarget; }set {IsOnTarget = value;} }

    float enemymultiplier=0;

    float RotationSpeed = 0.1f;

    float moveSpeed = 3f;

    Vector3 newpos;
    Vector3 spawnPosition;
    // Start is called before the first frame update
    void Start()
    {
            gameController = FindObjectOfType<GameController>();
            spawner = FindObjectOfType<Spawner>();
            player = FindObjectOfType<Cannon>();
            enemymultiplier = spawner.totalenemyspawned*0.5f;
            spawnPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        moveenemy();
        elapsedTime += Time.deltaTime;
        /* if(firepoint.rotation.z >45)
        {
            RotateCannon(-1);
        }
        if(firepoint.rotation.z <45)
        {
            RotateCannon(+1);
        } */
        ChangePower(CalculateAim(player.transform));

        if(Input.GetKey(KeyCode.J))
        {
            RotateCannon(-1);
        }
        if(Input.GetKey(KeyCode.L))
        {
            RotateCannon(1);
        }
        if(elapsedTime >= waitTime && IsOnTarget)
        {
            Shoot();
        }
    }



    public void Shoot()
    {
   
        GameObject enemyBall = Instantiate(cannonBall, firepoint.position, firepoint.rotation);
        enemyBall.GetComponent<Rigidbody2D>().velocity = firepoint.transform.right * BallSpeed;
        enemyBall.GetComponent<Projectile>().isEnemy =true;   
        elapsedTime =0;
    }

    public void ChangePower(float _value)
    {
        if(BallSpeed<_value)
        {
            BallSpeed += BallSpeed*RotationSpeed*Time.deltaTime*gameController.difficulty*enemymultiplier;
        }

        if(BallSpeed>_value)
        {
            BallSpeed -= BallSpeed*RotationSpeed*Time.deltaTime*gameController.difficulty*enemymultiplier;
        }
        /* if(BallSpeed<= _value-0.1f &&BallSpeed >= _value+0.1f)
        {
            BallSpeed =_value;
        } */
    }

    public void RotateCannon(float _direction)
    {
        EnemyCannon.rotation =Quaternion.Euler(EnemyCannon.rotation.eulerAngles +new Vector3(0,0, _direction)*Time.deltaTime);
    }


    public void SetSpeed()
    {

    }

    public float CalculateAim(Transform _target)
    {
        float distance = transform.position.x -_target.transform.position.x;
        float radangle = Mathf.PI*EnemyCannon.localEulerAngles.z/180;
        float SpeedNecessary = Mathf.Sqrt((distance*Mathf.Abs(Physics2D.gravity.y))/(Mathf.Sin(2*radangle)));

        return SpeedNecessary;
    }

    private void OnDestroy() 
    {
        spawner.enemycount --;
        spawner.timeelapsed =0;
    }


    public void moveenemy() {
         Vector3 posA =spawnPosition;
         posA.x =spawnPosition.x -3f;
         Vector3 posB =spawnPosition;
         posB.x = spawnPosition.x + 3;
         if (transform.position.x <= posA.x) {
             newpos = posB;
         }
         else if (transform.position.x >= posB.x) {
             newpos = posA;
         }
         
         gameObject.transform.position = Vector3.MoveTowards(transform.position, newpos, Time.deltaTime * moveSpeed); 
     }
    

    }

        //transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0,0,HorizontalRotation*RotationSpeed*-1));


    




