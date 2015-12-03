using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Scoring : MonoBehaviour {

	public int _score;
	public GameObject scoreText;
	public GameObject _scoreText;

	void Awake (){
		DontDestroyOnLoad(transform.gameObject);


	}
	// Use this for initialization
	void Start () {

		if(Application.loadedLevelName == "Octopus Spawner")
		_score = 0;


	}
	
	// Update is called once per frame
	void Update () {

		if(Application.loadedLevelName == "Octopus Spawner")
		scoreText.GetComponent<Text>().text = "Score: " + _score;

		if(Application.loadedLevelName == "Reload_Result"){
			Debug.Log("cqca");
			_scoreText = GameObject.Find("Score");
			_scoreText.GetComponent<Text>().text = "Score: " + _score;
		}

	}


}
