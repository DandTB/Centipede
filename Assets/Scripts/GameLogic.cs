using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour {


   public  GameObject pfbCentipede;
    GameObject pfb_Mushrooms;
    public int[,] map = new int[30, 30];
  
    GameObject[,] All_Objects;


    private void Awake()
    {

        pfb_Mushrooms = Resources.Load<GameObject>("Prefabs/mushroom");
       // pfbCentipede = Resources.Load<GameObject>("Prefabs/Centipade");
    }

    void Start () {

    
        All_Objects = new GameObject[30, 30];
         
        DrawMushroom();
    }
	


    void MushroomGenerator() {
 
        for (int y = 1; y < 30; y++)
        {
           for (int x = 0; x < 30; x++)
            {
                if (Random.Range(0, 15) == 1)
                {

                    map[y, x] = 1;               
                }
                else {
                    map[y,x]=0;
                }
            }
        }
    }

    void DrawMushroom()
    {
        MushroomGenerator();
        for (int y = 0; y < 30; y++)
        {
            for (int x = 0; x < 30; x++)
            {
                if (map[y, x] == 1)
                {
                    GameObject c = Instantiate(pfb_Mushrooms);
                    c.transform.position = new Vector3(x * 0.08f, 1-y * 0.08f, 0);
                    c.name = "mushroom";
                }
            }

        }
    }

    public void CreateCentipede( int size)
    {
        GameObject newCent = Instantiate(pfbCentipede);
        newCent.GetComponent<CentipedeTail>().countTail = size-2;
        
    }


}
