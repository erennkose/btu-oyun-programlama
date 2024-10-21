using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser_sc : MonoBehaviour
{
    public int speed = 20;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();
    }

    void CalculateMovement(){
        Vector3 direction = new Vector3(0, 1, 0);
        transform.Translate(direction * Time.deltaTime * speed);
        if (transform.position.y >= 8){ //sonsuz mermi olusmasin diye
            Destroy(this.gameObject);
        }
    }
}
