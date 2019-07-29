using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentipedeTail : MonoBehaviour
{

    public GameObject pfbhead; // префаб головы
    public GameObject pfbTail; // префак куска хвоста
    public float sizeSprite; // размер спрайта
    public int countTail;  // размер хвоста


  
    GameObject head; // голова гусеницы
    List<GameObject> ListCentipedePatrs; // список объектов хвоста
    public List<Vector2> positions = new List<Vector2>(); // позиции головы + об. хвоста
    public List<Vector2> startPos; // позиции для создания новой гусеницы

    private void Awake()
    {
       
        ListCentipedePatrs = new List<GameObject>();
      
        
    }

    // Use this for initialization
    void Start()
    {
        // если списко пуст, добавим голову и добавим хвост
        if (startPos.Count == 0)
        {
            head = Instantiate(pfbhead, transform.position, Quaternion.identity, transform);
            positions.Add(head.transform.position);
            for (int i = 0; i < countTail; i++)
            {
                AddTail(); 

            }
        }// иначе мы создаем голову и хвост в заданную позицию
        else {
            head = Instantiate(pfbhead, startPos[0], Quaternion.identity, transform);
            positions.Add(head.transform.position);
            for (int i = 0; i < countTail; i++)
            {
                AddTail(startPos);

            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {

       

        countTail = ListCentipedePatrs.Count; // проверяем размер хвоста

        Vector2 napr = (Vector2)head.transform.position - positions[0]; // получаем направления для хвоста

        float distance = napr.magnitude; //  расчитываем дистанцию от текущего положения головы и к последнему сохраненному

        if (distance > sizeSprite) // если дистанция больше размера спрайта, то 
        {

            Vector2 direction = ((Vector2)head.transform.position - positions[0]).normalized; // берем направление

            positions.Insert(0, positions[0] + direction * sizeSprite); // добавим новую позицию головы в список
            positions.RemoveAt(positions.Count - 1); // удалим последнее положение
            distance -= sizeSprite;
        }
        // плавно передвигаем каждый элемент хвоста на новую позицию
        for (int i = 0; i < ListCentipedePatrs.Count; i++)
        {
            if (ListCentipedePatrs[i] != null)
            {
                ListCentipedePatrs[i].transform.position = Vector2.Lerp(positions[i + 1], positions[i], distance / sizeSprite); 
            }
        }

       
       
    }

    // создание хвоста и сохранение в список объектов и координат
    void AddTail()
    {
    
        GameObject tail = Instantiate(pfbTail, positions[positions.Count - 1], Quaternion.identity, transform);
        tail.transform.right = head.transform.right;
        ListCentipedePatrs.Add(tail);
        positions.Add(tail.transform.position);
        tail.GetComponent<TailPart>().Number = ListCentipedePatrs.Count - 1; // передаем порядковый номер для дальнейшего удаления


    }
    // создание хвоста и сохранение в список объектов и координат с указание определенных позиций
    void AddTail(List<Vector2> pos)
    {

        GameObject tail = Instantiate(pfbTail, positions[positions.Count - 1], Quaternion.identity, transform);
        tail.transform.right = head.transform.right;
        ListCentipedePatrs.Add(tail);
        positions.Add(tail.transform.position);
        tail.GetComponent<TailPart>().Number = ListCentipedePatrs.Count - 1;


    }

    // удаляем элемент хвоста по номеру в списке, подчищаем списки
    public void RemoveTail(int index) {

        for (int i = index; i < countTail; i++)
        {

            Destroy(ListCentipedePatrs[i]);

        }

        ListCentipedePatrs.RemoveRange(index, countTail-index);
        positions.RemoveRange(index+1,countTail-index);

    }

  
}
