using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_sc : MonoBehaviour
{
    [SerializeField] float speed = 12;

    [SerializeField]int lives = 3;
    
    public GameObject laserPrefab;
    float fireRate = 0.5f;
    float nextFire = 0f;
    // Start is called before the first frame update
    void Start()
    {
        // transform.position = new Vector3(0,-2,0); //Nesnemiz ilk anda yalnizca bir kez y ekseninde 2 adim asagi gidecek
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();

        if (Input.GetKeyDown(KeyCode.Space)){
            FireFunction();
        }
    }

    void CalculateMovement(){
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, vertical, 0);
        transform.Translate(direction * Time.deltaTime * speed );

        /* // Kupumuzun belirli araliklarda hareketini saglamak icin olan bolum (raporda istenmedigi icin yorum satiri seklinde ekledim)
        if (transform.position.y >= 0){
            transform.position = new Vector3(transform.position.x,0,0);
        }
        else if (transform.position.y <= -3.9f ){
            transform.position = new Vector3(transform.position.x,-3.9f,0);
        }

        if (transform.position.x >= 9.2f){
            transform.position = new Vector3(-9.2f,transform.position.y,0);
        }
        else if (transform.position.x <= -9.2f){
            transform.position = new Vector3(9.2f,transform.position.y,0);
        }
        */
    
    }
    void FireFunction(){
        if (Time.time > nextFire){
            Instantiate(laserPrefab, transform.position + new Vector3(0, 0.6f, 0), Quaternion.identity);
            nextFire = Time.time + fireRate;
        }
    }

    public void Damage(){
        lives--;
        if(lives < 1){
            Destroy(this.gameObject);
        }
    }
}


