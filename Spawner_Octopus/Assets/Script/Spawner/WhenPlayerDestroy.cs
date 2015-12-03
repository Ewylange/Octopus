using UnityEngine;
using System.Collections;

public class WhenPlayerDestroy : MonoBehaviour {


	void OnDestroy () {
		
		Application.LoadLevel("GameOverScript");
	}
}