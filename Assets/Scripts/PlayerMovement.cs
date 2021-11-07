using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float speed=1f;

    bool isRunning=true;
    void Update()
    {   
        if(isRunning)
            transform.Translate(0,0,speed*Time.deltaTime);
    }

    public void StopRunning(){
        isRunning=false;
    }
    public void Die()
    {
        isRunning = false;
        Invoke("Restart", 2);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void StartRunning()
    {
        isRunning=true;
    }
}
