//Okul
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Enemy_sc : MonoBehaviour
{
    [SerializeField] float speed = 3.0f;
    Player_sc player_sc;

    Animator anim;

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        player_sc = GameObject.Find("Player").GetComponent<Player_sc>();
        audioSource = GetComponent<AudioSource>();

        if (player_sc == null){
            Debug.LogError("Enemy_sc::Start player_sc is null");
        }

        anim = GetComponent<Animator>();

        if (anim == null){
            Debug.LogError("Enemy_sc::Start anim is null");
        }

        if (audioSource == null){
            Debug.LogError("Enemy_sc::Start audioSource is null");
        }
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement(){
        if(transform.position.y < -5.38){
            float randomX = Random.Range(-9.4f,9.4f);
            transform.position = new Vector3(randomX, 7.38f, transform.position.z);
        }
        else{
            Vector3 direction = new Vector3(0,-1,0);
            transform.Translate(direction * Time.deltaTime * speed);
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
            // Canini azalt
            Player_sc playersc = other.GetComponent<Player_sc>();
            playersc.Damage();
            anim.SetTrigger("OnEnemyDeath");
            speed = 0;
            audioSource.Play();
            Destroy(this.gameObject, 2.5f);
        }
        else if(other.tag == "Laser"){
            Destroy(other.gameObject);
            if (player_sc != null){
                player_sc.UpdateScore(10);
            }
            anim.SetTrigger("OnEnemyDeath");
            speed = 0;
            audioSource.Play();
            Destroy(this.gameObject, 2.5f);
        }
    }
}
