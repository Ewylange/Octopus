using UnityEngine;
using System.Collections;

public class LookAtPlayer : MonoBehaviour {

	public GameObject _target;

	// Use this for initialization
	void Start () {

		_target = GameObject.FindGameObjectWithTag("Player");
		transform.rotation = Quaternion.Euler(Vector3.zero);
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.rotation = Quaternion.Euler(new Vector3(90,40,0));
		//transform.LookAt(_target.transform);

	}
}
