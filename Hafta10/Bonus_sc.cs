using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class Bonus_sc : MonoBehaviour
{
    public int bonusId;
    [SerializeField]
    AudioClip audioClip;
    int speed = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -5.38){
            Destroy(this.GameObject());
        }
        else{
            Vector3 direction = new Vector3(0,-2,0);
            transform.Translate(direction * Time.deltaTime * speed);
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        
        if(other.tag == "Player"){
            Player_sc playersc = other.transform.GetComponent<Player_sc>();
            AudioSource.PlayClipAtPoint(audioClip,transform.position);
            if(playersc != null){
                switch (bonusId){
                    case 0:
                    playersc.ActivateTripleShot();
                    break;
                    case 1:
                    playersc.ActivateSpeedBonus();
                    break;
                    case 2:
                    playersc.ActivateShieldBonus();
                    break;
                    default:
                    Debug.Log("Default value in switch case");
                    break;
                }
            }
            Destroy(this.gameObject);
        }
    }
}
