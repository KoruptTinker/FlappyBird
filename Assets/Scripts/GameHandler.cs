using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
public class GameHandler : MonoBehaviour
{
    public static int Score;
    [SerializeField] private GameObject obstacle;
    private GameObject previousSpawned;
    private float obstacleHeight;

    // Start is called before the first frame update
    void Start()
    {
        Score=0;
    }
    // Update is called once per frame
    void Update()
    {
        if(!PlayerManager.isPlaying){
            return;
        }

        if(PlayerManager.isPlaying && previousSpawned==null){
            previousSpawned=SpawnObstacles(obstacle);
        }

        if(previousSpawned.GetComponent<Rigidbody2D>().position.x<=69){
            previousSpawned=SpawnObstacles(obstacle);
        }
    }

    GameObject SpawnObstacles(GameObject obstacle){
        obstacleHeight=Random.Range(-31,31);
        Vector3 location=new Vector3(114,obstacleHeight,0);
        return Instantiate(obstacle,location,Quaternion.identity);
    }
    
}
