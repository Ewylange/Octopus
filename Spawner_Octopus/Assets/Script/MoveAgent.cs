using UnityEngine;
using System.Collections;

public class MoveAgent : MonoBehaviour {

	NavMeshAgent agent;
	State _state;
	 public GameObject _player;
	public float _xMin;
	public float _xMax;
	public float _zMin;
	public float _zMax;

	public float _distanceToPlayer;

	Scoring _scriptScore;
	GameObject _scoringSystem;


	enum State : int {
		

		GOPLAYER,
		STOP,
		DESTROY
	}
	// Use this for initialization
	void Start () {

		agent = GetComponent<NavMeshAgent>();
		transform.position += new Vector3(Random.Range(_xMin,_xMax),0, Random.Range(_xMin, _xMax));
		_state = State.GOPLAYER;
		_scoringSystem = GameObject.FindGameObjectWithTag("Score");
		_scriptScore = _scoringSystem.GetComponent<Scoring>();
		 _player =  GameObject.FindWithTag ("Player");

	}
	
	// Update is called once per frame
	void Update () {

		_distanceToPlayer = Vector3.Distance(_player.transform.position, transform.position);

		switch(_state){

		case State.GOPLAYER: 

			//agent.SetDestination(_player.transform.position);

			if(_distanceToPlayer <= 5){

				_state = State.STOP;
			}
			break;

		case State.STOP :

			Debug.Log("LimiteJoueurAtteint");
			agent.Stop();
			break;

		case State.DESTROY :

			Debug.Log ("State Destroy");
			DestroyObject(this.gameObject);

			break;

		}



	
	}

	void OnCollisionEnter (Collision col) {

		if(col.gameObject.tag == "Player"){
			_state = State.DESTROY;
			_scriptScore._score +=1;
		}

	}
}
