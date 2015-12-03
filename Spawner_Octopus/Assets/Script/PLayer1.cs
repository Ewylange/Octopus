using UnityEngine;
using System.Collections;

public class PLayer1 : MonoBehaviour {


	public float speedPlayer;



	//[HideInInspector]

	// Use this for initialization
	void Start () {
		speedPlayer = 4;
	}
	
	// Update is called once per frame
	void Update () {

		// deplacement du joueur
		if(Input.GetKey(KeyCode.UpArrow)){
			
			transform.Translate(Vector3.forward * Time.deltaTime * speedPlayer );
		}
		
		if(Input.GetKey(KeyCode.DownArrow)){
			
			transform.Translate(Vector3.back * Time.deltaTime * speedPlayer );
			
		}
		
		if(Input.GetKey(KeyCode.RightArrow)){
			
			transform.Translate(Vector3.right * Time.deltaTime * speedPlayer );
			
		}
		
		if(Input.GetKey(KeyCode.LeftArrow)){
			
			transform.Translate(Vector3.left * Time.deltaTime * speedPlayer );
			
		}
		//_playerHeard = false;
	}





}
