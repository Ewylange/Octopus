using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Timer : MonoBehaviour {

	public float _timer;
	public GameObject timerText;
	// Use this for initialization
	void Start () {
		_timer = 0;
	}
	
	// Update is called once per frame
	void Update () {

		_timer += Time.deltaTime;
		timerText.GetComponent<Text>().text = "Timer: " + _timer;

		if(_timer >= 60){
			Debug.Log ("GameOver");
			_timer = 0;
			Application.LoadLevel(1);
		}
	}
}
