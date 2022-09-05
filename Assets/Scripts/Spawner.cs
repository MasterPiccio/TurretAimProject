using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab;

    Enemy ActiveEnemy;
    int enemyCount;
    public int enemycount {get { return enemyCount;} set {enemyCount = value;}}
    int EnemySpawned =0;
    public int totalenemyspawned {get {return EnemySpawned;}set{ EnemySpawned =value;}}
    

    public Vector3 SpawnPos;

    float timetospawn = 3f;
    float Elapsed =0;
    public float timeelapsed {get {return Elapsed;} set {Elapsed = value;}}



    // Start is called before the first frame update
    void Start()
    {
        EnemySpawned = 0;
        enemyCount = FindObjectsOfType<Enemy>().Length;
        ActiveEnemy = FindObjectOfType<Enemy>();
        SpawnPos = ActiveEnemy.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        timeelapsed += Time.deltaTime;
        if(enemyCount<=0 && timeelapsed>=timetospawn)
        {
            SpawnNewEnemy(SpawnPos);
        }
    }



    public void SpawnNewEnemy(Vector3 _pos)
    {
        float randomxpos = Random.Range(SpawnPos.x-3,SpawnPos.x+2);
        _pos.x = randomxpos;
        Instantiate(enemyPrefab,_pos,Quaternion.identity);
        enemyCount ++;
        EnemySpawned++;

    }
}
