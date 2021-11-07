using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement move;
    public SwerveMovement swerve;
    public SwerveInputSystem swerveInput;
    public Animator animate;
    private void OnCollisionEnter(Collision collisionInfo)
    {
        if(collisionInfo.collider.tag == "Obstacle")
        {
            Debug.Log("Obstacle");
            move.Die();
            swerve.DisableSwerveMove();
            swerveInput.DisableSwerveInput();
            animate.enabled = false;


        }

        if(collisionInfo.collider.tag== "endPoint" )
        {
            move.StopRunning();
            swerve.DisableSwerveMove();
            swerveInput.DisableSwerveInput();
            animate.enabled = false;
            if (SceneManager.GetActiveScene().buildIndex == 2)
            {
                SceneManager.LoadScene(0);
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }

       
    }
    private void Update()
    {
        if (transform.position.y < -5)
        {
            move.Die();
            swerve.DisableSwerveMove();
            swerveInput.DisableSwerveInput();
            animate.enabled = false;
        }

       
    }
}
