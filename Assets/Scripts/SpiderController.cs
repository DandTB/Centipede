using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderController : Enemys {

    // напрвление
    Vector2 direction;

	// Use this for initialization
	void Start () {
        direction = Vector2.down; // вниз со старта
        HP = 1;
	}
	
	// Update is called once per frame
	void Update () {
        // двигаем паука
        transform.position += (Vector3)direction * GameLogic.Instance.speedCentipede * Time.deltaTime;
        // огранициваем его передвижение
        if (transform.position.y >= -20) {
            direction = Vector2.down;
        }
        // + 300 очков  в случае гибели паука
        if (HP < 1)
        {
            Die();
            GameLogic.Instance.Score += 300;
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        // если попали в героя то герой умирает
        if (coll.gameObject.GetComponent<Hero>()!= null) {
            coll.gameObject.GetComponent<Hero>().Die();
        }
        // если попали в гриб убираем гриб (может быть ;)
        if (coll.gameObject.GetComponent<Mushroom>() != null) {
            int rand = Random.Range(0,2);
            if (rand == 1) {
                GameLogic.Instance.countMushromms--;
                Destroy(coll.gameObject);
            }
        }
        // меняем направление движдения в зависимости от предыдущего
         if (direction == Vector2.down)
        {
            direction = Vector2.up + Vector2.right;
        }
        else if (direction == Vector2.up + Vector2.right)
        {
            direction = Vector2.down + Vector2.left;
        }
        else if (direction == Vector2.down + Vector2.left)
        {
            direction = Vector2.up + Vector2.left;
        }
        else if (direction == Vector2.up + Vector2.left)
        {
            direction = Vector2.right + Vector2.up;
        }
    }
}
