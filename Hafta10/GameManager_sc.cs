using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager_sc : MonoBehaviour
{
    bool isGameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R) && isGameOver == true){
            SceneManager.LoadScene(1);
        }
    }

    public void GameOver(){
        isGameOver = true;
    }
}
