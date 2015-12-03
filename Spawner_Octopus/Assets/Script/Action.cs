using UnityEngine;
using System.Collections;

public class Action : MonoBehaviour {

  [HideInInspector] public Action nextAction = null;
  [HideInInspector] public Action prevAction = null;
  [HideInInspector] public bool selected = false;
  [HideInInspector] public bool isFirstAction = false;

  public virtual void launch(){
    enabled = true;
  }

  public virtual void stop(){
    enabled = false;
  }

  protected virtual void next(){
    if(nextAction != null) nextAction.launch();
  }

	// Use this for initialization
	protected virtual void Awake () {
    if(prevAction != null && !isFirstAction) enabled = false;
    if (nextAction != null && !nextAction.isFirstAction) nextAction.enabled = false;
	}
}
