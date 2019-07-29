using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour {


    public GameObject pfbCentipede;
    public GameObject panelGameOver;
    public int[,] map = new int[25, 30];
    public int sizeCentipede;

    public static GameLogic Instance;

    [System.NonSerialized]
    public int Score;

    Hero hero;
    GameObject pfb_Mushrooms;
    GameObject pfbSpider;
    float tempSpeed;
    float myTimer;

    private void Awake()
    {
        Time.timeScale = 1;
        hero = GameObject.FindObjectOfType<Hero>();
        pfb_Mushrooms = Resources.Load<GameObject>("Prefabs/mushroom");
        pfbSpider = Resources.Load<GameObject>("Prefabs/Spider");


        tempSpeed = GameObject.FindObjectOfType<CentipedeTail>().speed;
       // pfbCentipede = Resources.Load<GameObject>("Prefabs/Centipade");
    }

    void Start () {
        Instance = this;
        DrawMushroom();
    }
    private void Update()
    {
        myTimer += Time.deltaTime;
        if (myTimer>7) {
            CreateSpider();
            myTimer = 0;
        }
        if (hero.HP < 1) {
            GameOver();
            
        }
        if (GameObject.FindObjectOfType<CentipedeTail>() == null) {
            CreateCentipede(sizeCentipede);
        }
    }


    void MushroomGenerator() {
 
        for (int y = 1; y < 25; y++)
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
        for (int y = 0; y < 25; y++)
        {
            for (int x = 0; x < 30; x++)
            {
                if (map[y, x] == 1)
                {
                    GameObject c = Instantiate(pfb_Mushrooms);
                    
                    c.transform.position = new Vector3(x, 1 - y , 0);
                    c.name = "mushroom";
                }
            }

        }
    }

    public void CreateCentipede( int size,  List<Vector2> positions)
    {
        GameObject newCent = Instantiate(pfbCentipede);
        newCent.GetComponent<CentipedeTail>().countTail = size-2;
        newCent.GetComponent<CentipedeTail>().speed = tempSpeed;
        List<Vector2> temp = new List<Vector2>();

        for (int i = 0; i<positions.Count; i++)
        {
            temp.Add(positions[i]);
        }
        temp.RemoveRange(0,size);

        newCent.GetComponent<CentipedeTail>().startPos = temp ;
        print(temp[0]);
    }

    public void CreateCentipede(int size)
    {
        tempSpeed++;
        GameObject newCent = Instantiate(pfbCentipede);
        newCent.GetComponent<CentipedeTail>().countTail = size - 2;
        newCent.GetComponent<CentipedeTail>().speed = tempSpeed; 
    }
    public void Reload_lvl()
    {
        SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
    }

    public void GameOver() {
        Time.timeScale = 0;
        panelGameOver.SetActive(true);
    }

    void CreateSpider() {
        Vector2 spider_pos = new Vector2(Random.Range(1,29),-20);
        GameObject spider = Instantiate(pfbSpider);
        spider.transform.position = spider_pos;
        Destroy(spider,10.0f);
    }

    

}
