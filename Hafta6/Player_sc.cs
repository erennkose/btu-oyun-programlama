using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player_sc : MonoBehaviour
{
    [SerializeField] float speed = 12;
    public GameObject laserPrefab;
    public GameObject tripleShotPrefab;
    float fireRate = 0.5f;
    float nextFire = 0f;
    SpawnManager_sc spawnManager_Sc;

    [SerializeField] public int lives = 3;

    public bool isTripleShotActive = false;

    // Start is called before the first frame update
    void Start()
    {
        spawnManager_Sc = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager_sc>();
        if(spawnManager_Sc == null){
            Debug.Log("Spawn_Manager oyun nesnesi bulunamadı.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();
        FireLaser();
        

    }
    void CalculateMovement(){
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, vertical, 0);
        transform.Translate(direction * Time.deltaTime * speed );

        float locx = transform.position.x;
        float locy = transform.position.y;

        
        if (locy >= 0){
            transform.position = new Vector3(transform.position.x,0,0);
        }
        else if (locy <= -3.9f ){
            transform.position = new Vector3(transform.position.x,-3.9f,0);
        }

        if (locx >= 11.23f){
            transform.position = new Vector3(-11.23f,transform.position.y,0);
        }
        else if (locx <= -11.23f){
            transform.position = new Vector3(11.23f,transform.position.y,0);
        }
    }

    void FireLaser(){
        if ((Input.GetKeyDown(KeyCode.Space)) && (Time.time > nextFire)){
            if(!isTripleShotActive)
            {
                Instantiate(laserPrefab, transform.position + new Vector3(0, 1.05f, 0), Quaternion.identity);
                nextFire = Time.time + fireRate;
            }
            else if(isTripleShotActive)
            {
                Instantiate(tripleShotPrefab, transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity);
                nextFire = Time.time + fireRate;
            }
        }
    }
    public void Damage(){
        lives--;
        if(lives < 1){
            if(spawnManager_Sc != null){
                spawnManager_Sc.OnPlayerDeath();
            }
            Destroy(this.gameObject);
        }
    }

    public void ActivateTripleShot(){
        isTripleShotActive = true;
        StartCoroutine(TripleShotBonusDisableRoutine());
    }
    IEnumerator TripleShotBonusDisableRoutine(){
        yield return new WaitForSeconds(5.0f);
        isTripleShotActive = false;
    }
}