using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Obstacles : MonoBehaviour
{
    [SerializeField] private Rigidbody2D obstacleRigidBody;
    private GameObject obstacleObject;
    private bool isScored;
    private AudioSource gameOverSound;
    private AudioSource score;
    // Start is called before the first frame update
    void Start()
    {   
        AudioSource[] soundComponents=GetComponents<AudioSource>();
        obstacleObject=obstacleRigidBody.gameObject;
        addVelocity(obstacleRigidBody);
        isScored=false;
        gameOverSound=soundComponents[0];
        score=soundComponents[1];
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        destroyObstacle(obstacleObject);
        if(obstacleRigidBody.position.x<=0 && !isScored && PlayerManager.isAlive){
            score.Play();
            GameHandler.Score++;
            isScored=true;
        }
    }

    void addVelocity(Rigidbody2D obstacle){
        Vector2 velocity=new Vector2(-25,0);
        obstacle.velocity=velocity;
    }

    void destroyObstacle(GameObject obstacle){
        if(obstacle.transform.position.x<=-114){
            Destroy(obstacle);
        }
    }

    void OnTriggerEnter2D(Collider2D col){
        if(PlayerManager.isAlive){
            Rigidbody2D playerRigidBody=col.GetComponentInParent<Rigidbody2D>();
            gameOverSound.Play();
            playerRigidBody.velocity=new Vector2(0,100);
            playerRigidBody.AddTorque(500);
            PlayerManager.isAlive=false;
        }    
    }
}
