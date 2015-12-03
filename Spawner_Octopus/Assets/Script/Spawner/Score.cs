using UnityEngine;
using System.Collections;

[RequireComponent(typeof(GUIText))]
public class Score : MonoBehaviour
{
  [HideInInspector] public float time;
  private int _score = 0;
  public int score{
    get{
      return _score;
    }
    set{
      _score = value;
      GetComponent<GUIText>().text = _score.ToString();
    }
  }

  void Awake(){
    gameObject.tag = " Score ";
    score = 0;
    DontDestroyOnLoad(gameObject);
  }

  void Update(){
    time += Time.deltaTime;
  }

  void OnLevelWasLoaded(int level){
    if(level == 0){
      time = 0;
      score = 0;
    }
  }
}

