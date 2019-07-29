using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour {


    public GameObject pfbCentipede; // префаб гусеницы
    public GameObject panelGameOver; // панель геймовер
    public int[,] map = new int[25, 30]; // матрица для генерации грибов
    public int sizeCentipede; // размер гусеницы
    public float speedCentipede; // скорость гусеницы

    public static GameLogic Instance; // синглтон

    // не отображаем в инспекторе счет и кол-во грибов в игровой зоне героя
    [System.NonSerialized]
    public int Score;
    [System.NonSerialized]
    public int countMushromms;

    bool play;
    Hero hero; // дял получения доступа к скрипту героя
    GameObject pfb_Mushrooms; // префаб гриба
    GameObject pfbSpider;// префаб паука
    GameObject pfbAnt;//префаб муравья
   
    float myTimer; // таймер


    private void Awake()
    {
        Time.timeScale = 1;
        hero = GameObject.FindObjectOfType<Hero>();
        pfb_Mushrooms = Resources.Load<GameObject>("Prefabs/mushroom");
        pfbSpider = Resources.Load<GameObject>("Prefabs/Spider");
        pfbAnt = Resources.Load<GameObject>("Prefabs/Ant");

        
    }

    void Start () {
        Instance = this;
        DrawMushroom(); // отображаем грибы
        StartCoroutine("GoPlay"); //запускаем гусеницу

    }
    private void Update()
    {
        // создаем паука каждые 8 сек
        myTimer += Time.deltaTime;
        if (myTimer>8) {
            CreateSpider();
            myTimer = 0;
        }
        if (hero.HP < 1) { // если нет жизни, то геймовер
            
            GameOver();
            
        }
        // если нет гусеницы, создаем новую, с указанным размером
        if (GameObject.FindObjectOfType<CentipedeTail>() == null && play) { 
            CreateCentipede(sizeCentipede);
        }
        // если грибов в игровой зоне меньше 5 и нет муравья. то создаем нового муравья
        if (countMushromms < 5 && GameObject.FindObjectOfType<AntController>()==null) {//
         
            CreateAnt();
        }
        
    }

    // рандомно заполянем матрицу еденицами и нулями
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

    // в единицах создаем грибы
    void DrawMushroom()
    {
        MushroomGenerator();
        for (int y = 0; y < 25; y++)
        {
            for (int x = 0; x < 30; x++)
            {
                if (map[y, x] == 1)
                {
                   
                    CreateMushroom(new Vector2(x, 1 - y)); 
                }
            }

        }
    }
    // создаем гусеницу задавая размер и позицию
    public void CreateCentipede( int size,  List<Vector2> positions)
    {
        GameObject newCent = Instantiate(pfbCentipede);
        newCent.GetComponent<CentipedeTail>().countTail = size-2; // размер на 2 меньше (минус часть хвоста и голову) 
        List<Vector2> temp = new List<Vector2>();
        
        for (int i = 0; i<positions.Count; i++) 
        {
            temp.Add(positions[i]);
        }
        temp.RemoveRange(0,size);// удалим лишние позиции
        newCent.GetComponent<CentipedeTail>().startPos = temp; //  передаем позиции новой гусенице

    }
    // создаем гусеницу задавая только размер
    public void CreateCentipede(int size)
    {
        speedCentipede++;
        GameObject newCent = Instantiate(pfbCentipede);
        newCent.GetComponent<CentipedeTail>().countTail = size - 2;
    }
    // обработка нажатия кнопки начать игру
    public void Reload_lvl()
    {
        SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
    }
    // при проиграше ставим паузу и вызываем панель
    public void GameOver() {
        
        Time.timeScale = 0;
        panelGameOver.SetActive(true);
      
    }
    // создаем паука на 10 сек
    void CreateSpider() {
        Vector2 spider_pos = new Vector2(Random.Range(1,29),-20);
        GameObject spider = Instantiate(pfbSpider);
        spider.transform.position = spider_pos;
        Destroy(spider,10.0f);
    }

    // создаем мурявья на 10 сек
    public void CreateAnt()
    {
        Vector2 ant_pos = new Vector2(Random.Range(1, 29), 2);
        GameObject ant = Instantiate(pfbAnt);
        ant.transform.position = ant_pos;
        Destroy(ant, 10.0f);
    }
    // создаем гриб в указанной позиции
    public void CreateMushroom(Vector2 position) {
        GameObject mush = Instantiate(pfb_Mushrooms);
        mush.transform.position = position;
        mush.name = "mushroom";
    }
    // откладываем создаение первой гусеницы на 3 секунды
    public IEnumerator GoPlay() {
        yield return new WaitForSeconds(3.0f);
        CreateCentipede(10);
        play = true;
    }
}
