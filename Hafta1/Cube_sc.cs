using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube_sc : MonoBehaviour
{
    public float speed = 5; /* public speed degiskeni, inspector kisminda bu degisken gosterilmekte */

    private float privateSpeed = 4; /* private speed degiskeni, inspector kisminda bu degisken gozukmezken aslinda oyunda bu kullanilmakta */

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0,-2,0); //Nesnemiz ilk anda yalnizca bir kez y ekseninde 2 adim asagi gidecek
    }

    // Update is called once per frame
    void Update()
    {
        /* transform.Translate(new Vector3(0,-1,0) * Time.deltaTime * speed); //Surekli hareket icin kod parcasi */
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(1,0,0) * Time.deltaTime * privateSpeed * horizontal);
        transform.Translate(new Vector3(0,1,0) * Time.deltaTime * privateSpeed * vertical);
    }
}


