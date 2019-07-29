using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : DestroyedObj {


    public float speed = 2;
    

    GameObject pfbShot;
    Vector2 startPos;
	// Use this for initialization
	void Awake () {
        pfbShot = Resources.Load<GameObject>("Prefabs/shot");
        HP = 3;
        startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.A)) {
            MoveLeft();
        }
        if (Input.GetKey(KeyCode.D))
        {
            MoveRight();
        }
        if (Input.GetKey(KeyCode.W))
        {
            MoveUp();
        }
        if (Input.GetKey(KeyCode.S))
        {
            MoveDown();

        }
        if (Input.GetKeyDown(KeyCode.Space)) {
            Shot();
        }
        if (transform.position.y < -30)
        {
            transform.position = new Vector3(transform.position.x,-30,0);

        }
        if (transform.position.y > -25)
        {
            transform.position = new Vector3(transform.position.x, -25, 0);
        }
    }

    void MoveLeft()
    {

        transform.position -= new Vector3(speed,0,0)*Time.deltaTime;

    }

    void MoveRight()
    {

        transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;

    }
    void MoveUp()
    {

        transform.position += new Vector3(0, speed, 0) * Time.deltaTime;

    }
    void MoveDown()
    {

        transform.position += new Vector3(0, -speed, 0) * Time.deltaTime;

    }

    void Shot() {
        GameObject temp = Instantiate(pfbShot);
        temp.transform.position = transform.position+ new Vector3(0,0.09f,0);
    }

   
    public override void Die()
    {
        base.Die();
        GetComponent<SpriteRenderer>().color = new Color32(255,255,255,0);
        transform.position = startPos;
        StartCoroutine("SetAlphaColor");
        HP--;

    }
     
    IEnumerator  SetAlphaColor() {
        GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
        yield return new WaitForSeconds(2.0f);
       
    }
}
