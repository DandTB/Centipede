using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TailPart : DestroyedObj{

    GameLogic gl;
    CentipedeTail CentipedeTail;
    GameObject pfbmushroom;

    public int Number { get; set; }
    

    // Use this for initialization
    private void Start()
    {
        HP = 1;
        CentipedeTail = GetComponentInParent<CentipedeTail>();
        gl = GameObject.FindObjectOfType<GameLogic>();
       pfbmushroom = Resources.Load<GameObject>("Prefabs/mushroom");
    }
    
	
	// Update is called once per frame
	void Update () {
        if (HP < 1)
        {

            Destroy(this.gameObject);
            GameObject mush = Instantiate(pfbmushroom);
            mush.transform.position = transform.position;

            if (Number + 1 != CentipedeTail.countTail)
            {

                gl.CreateCentipede(CentipedeTail.countTail - Number);
            }

            CentipedeTail.RemoveTail(Number);


        }
	}

   
}
