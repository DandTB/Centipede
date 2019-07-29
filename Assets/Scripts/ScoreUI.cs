using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour {


    // получем и выводим очки на экран
  
    void Update () {
        GetComponent<Text>().text = GameLogic.Instance.Score.ToString();
	}
}
