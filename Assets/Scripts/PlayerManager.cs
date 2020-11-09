using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerManager : MonoBehaviour
{
    [SerializeField] private Rigidbody2D playerRigidBody;
    private GameObject player;
    private bool isGoingUp;
    public static bool isAlive;
    public static bool isPlaying;
    private AudioSource jumpSound;
    // Start is called before the first frame update
    void Start()
    {
        player=playerRigidBody.gameObject;
        isGoingUp=false;
        isAlive=true;
        isPlaying=false;
        jumpSound=GetComponent<AudioSource>();
        playerRigidBody.gravityScale=0;
    }

    // Update is called once per frame
    void Update(){
        if(!isAlive){
            return;
        }

        if(playerRigidBody.velocity[1]>=0){
            isGoingUp=true;
        }

        if((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))){
            jumpSound.Play();
            if(!isPlaying){
                playerRigidBody.gravityScale=29;
                isPlaying=true;
            }
            playerRigidBody.velocity= new Vector2(0,0);
            playerRigidBody.AddForce(Vector2.up/2);
            addDownForce(isGoingUp,playerRigidBody);
        }

    }

    void FixedUpdate(){

        if(playerRigidBody.position.y<=-47 && isAlive){
            playerRigidBody.velocity=new Vector2(0,100);
            playerRigidBody.AddTorque(500);
            isAlive=false;
        }
        else if(playerRigidBody.position.y>=46.5f && isAlive){
            playerRigidBody.velocity=new Vector2(0,-10);
            playerRigidBody.AddTorque(550);
            isAlive=false;
        }
    }

    void addDownForce(bool isGoingUp,Rigidbody2D playerRigidBody){
        Vector2 downForce;
        if(isGoingUp){
            downForce=new Vector2(0,-0.13f);
        }
        else{
            downForce=new Vector2(0,-0.009f);
        }
        playerRigidBody.AddForce(downForce);
    }
}
