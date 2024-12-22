using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager_sc : MonoBehaviour
{
    GameManager_sc gameManager_sc;

    [SerializeField]
    TextMeshProUGUI scoreTMP;

    [SerializeField]
    TextMeshProUGUI gameOverTMP;

    [SerializeField]
    TextMeshProUGUI restartTMP;

    [SerializeField]
    Image livesImg;

    [SerializeField]
    Sprite[] livesSprites;
    // Start is called before the first frame update
    void Start()
    {
        gameManager_sc = GameObject.Find("Game_Manager").GetComponent<GameManager_sc>();
        if(gameManager_sc == null){
            Debug.LogError("UIManager_sc::Start gameManager_sc is NULL");
        }

        scoreTMP.text = "Score: " + 0;
        livesImg.sprite = livesSprites[3];
        gameOverTMP.gameObject.SetActive(false);
        restartTMP.gameObject.SetActive(false);
    }
    public void UpdateScoreTMP(int points){
        scoreTMP.text = "Score: " + points;
    }
    public void UpdateLivesImg(int lives){
        livesImg.sprite = livesSprites[lives];
        if(lives == 0){
            GameOverSequence();
        }
    }

    void GameOverSequence(){
        if(gameManager_sc != null){
            gameManager_sc.GameOver();
        }
        gameOverTMP.gameObject.SetActive(true);
        StartCoroutine(GameOverFlickerRoutine());
        restartTMP.gameObject.SetActive(true);
    }

    IEnumerator GameOverFlickerRoutine(){
        while(true){
            gameOverTMP.text = "Game Over";
            yield return new WaitForSeconds(0.5f);
            gameOverTMP.text = "";
            yield return new WaitForSeconds(0.5f);
        }
    }
}
