using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour {

	
	
	// Update is called once per frame
	void Update () {
        GetComponent<Text>().text = GameLogic.Instance.Score.ToString();
	}
}
