using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TailPart : Enemys{

    GameLogic gl;
    CentipedeTail CentipedeTail;
   

    public int Number { get; set; }
    

    // Use this for initialization
    private void Start()
    {
        HP = 1;
        CentipedeTail = GetComponentInParent<CentipedeTail>();
        gl = GameObject.FindObjectOfType<GameLogic>();
      
    }
    
	
	// Update is called once per frame
	void Update () {
        if (HP < 1)
        {
            Die();
            Destroy(this.gameObject);
            print(Number);
           

            if (Number + 1 != CentipedeTail.countTail)
            {

                gl.CreateCentipede(CentipedeTail.countTail - Number, CentipedeTail.positions);
            }

            CentipedeTail.RemoveTail(Number);


        }
	}

   
}
