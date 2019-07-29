using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour {


    public GameObject pfbCentipede;
    public GameObject panelGameOver;
    public int[,] map = new int[25, 30];
    public int sizeCentipede;
    public float speedCentipede;

    public static GameLogic Instance;

    [System.NonSerialized]
    public int Score;
    [System.NonSerialized]
    public int countMushromms;


    Hero hero;
    GameObject pfb_Mushrooms;
    GameObject pfbSpider;
    GameObject pfbAnt;
   // float tempSpeed;
    float myTimer;
 

    private void Awake()
    {
        Time.timeScale = 1;
        hero = GameObject.FindObjectOfType<Hero>();
        pfb_Mushrooms = Resources.Load<GameObject>("Prefabs/mushroom");
        pfbSpider = Resources.Load<GameObject>("Prefabs/Spider");
        pfbAnt = Resources.Load<GameObject>("Prefabs/Ant");

       // tempSpeed = GameObject.FindObjectOfType<CentipedeTail>().speed;
        
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

        if (countMushromms < 5 && GameObject.FindObjectOfType<AntController>()==null) {
           print(123);
            CreateAnt();
        }
        print(countMushromms);
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
                   // GameObject c = Instantiate(pfb_Mushrooms);
                    
                  //  c.transform.position = new Vector3(x, 1 - y , 0);
                   // c.name = "mushroom";
                    CreateMushroom(new Vector2(x, 1 - y)); 
                }
            }

        }
    }

    public void CreateCentipede( int size,  List<Vector2> positions)
    {
        GameObject newCent = Instantiate(pfbCentipede);
        newCent.GetComponent<CentipedeTail>().countTail = size-2;
        //newCent.GetComponent<CentipedeTail>().speed = speedCentipede;
        List<Vector2> temp = new List<Vector2>();

        for (int i = 0; i<positions.Count; i++)
        {
            temp.Add(positions[i]);
        }
        temp.RemoveRange(0,size);

        newCent.GetComponent<CentipedeTail>().startPos = temp ;
       
    }

    public void CreateCentipede(int size)
    {
        speedCentipede++;
        GameObject newCent = Instantiate(pfbCentipede);
        newCent.GetComponent<CentipedeTail>().countTail = size - 2;
       // newCent.GetComponent<CentipedeTail>().speed = speedCentipede; 
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

    public void CreateAnt()
    {
        Vector2 ant_pos = new Vector2(Random.Range(1, 29), 2);
        GameObject ant = Instantiate(pfbAnt);
        ant.transform.position = ant_pos;
        Destroy(ant, 10.0f);
    }

    public void CreateMushroom(Vector2 position) {
        GameObject mush = Instantiate(pfb_Mushrooms);
        mush.transform.position = position;
        mush.name = "mushroom";
    }
}
