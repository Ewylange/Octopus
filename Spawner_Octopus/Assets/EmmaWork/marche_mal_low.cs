using UnityEngine;
using System.Collections;

public class marche_mal_low : MonoBehaviour {

	public GameObject tentacule_1;
	public GameObject tentacule_2;
	public GameObject tentacule_3;
	public GameObject tentacule_4;
	public GameObject tentacule_5;
	public GameObject tentacule_6;
	public GameObject tentacule_7;
	public GameObject tentacule_8;

	private Vector3 offset1;
	private Vector3 offset2;
	private Vector3 offset3;
	private Vector3 offset4;
	private Vector3 offset5;
	private Vector3 offset6;
	private Vector3 offset7;
	private Vector3 offset8;

	private bool nothappening1;
	private bool nothappening2;
	private bool nothappening3;
	private bool nothappening4;
	private bool nothappening5;
	private bool nothappening6;
	private bool nothappening7;
	private bool nothappening8;


	// Use this for initialization
	void Start () {
		nothappening1 = true;
		nothappening2 = true;
		nothappening3 = true;
		nothappening4 = true;
		nothappening5 = true;
		nothappening6 = true;
		nothappening7 = true;
		nothappening8 = true;
		offset1 = this.transform.position - tentacule_1.transform.position;
		offset2 = this.transform.position - tentacule_2.transform.position;
		offset3 = this.transform.position - tentacule_3.transform.position;
		offset4 = this.transform.position - tentacule_4.transform.position;
		offset5 = this.transform.position - tentacule_5.transform.position;
		offset6 = this.transform.position - tentacule_6.transform.position;
		offset7 = this.transform.position - tentacule_7.transform.position;
		offset8 = this.transform.position - tentacule_8.transform.position;
	}
	
	// Update is called once per frame
	void Update () {


		if(offset1 != this.transform.position - tentacule_1.transform.position && nothappening1 == true )
		{
			Vector3 pos = Vector3.Lerp(tentacule_1.transform.position,this.transform.position - offset1, 10*Time.deltaTime);
			tentacule_1.transform.localPosition = pos;
		}

		if(offset2 != this.transform.position - tentacule_2.transform.position&& nothappening2 == true)
		{
			Vector3 pos = Vector3.Lerp(tentacule_2.transform.position,this.transform.position - offset2,10*Time.deltaTime);
			tentacule_2.transform.localPosition = pos;
		}
		if(offset3 != this.transform.position - tentacule_3.transform.position && nothappening3 == true)
		{
			Vector3 pos = Vector3.Lerp(tentacule_3.transform.position,this.transform.position - offset3,10*Time.deltaTime);
			tentacule_3.transform.localPosition = pos;
		}
		if(offset4 != this.transform.position - tentacule_4.transform.position && nothappening4 == true)
		{
			Vector3 pos = Vector3.Lerp(tentacule_4.transform.position,this.transform.position - offset4,10*Time.deltaTime);
			tentacule_4.transform.localPosition = pos;
		}
		if(offset5 != this.transform.position - tentacule_5.transform.position && nothappening5 == true)
		{
			Vector3 pos = Vector3.Lerp(tentacule_5.transform.position,this.transform.position - offset5,10*Time.deltaTime);
			tentacule_5.transform.localPosition = pos;
		}
		if(offset6 != this.transform.position - tentacule_6.transform.position && nothappening6 == true)
		{
			Vector3 pos = Vector3.Lerp(tentacule_6.transform.position,this.transform.position - offset6,10*Time.deltaTime);
			tentacule_6.transform.localPosition = pos;
		}
		if(offset7 != this.transform.position - tentacule_7.transform.position && nothappening7 == true)
		{
			Vector3 pos = Vector3.Lerp(tentacule_7.transform.position,this.transform.position - offset7,10*Time.deltaTime);
			tentacule_7.transform.localPosition = pos;
		}
		if(offset8 != this.transform.position - tentacule_8.transform.position && nothappening8 == true )
		{
			Vector3 pos = Vector3.Lerp(tentacule_8.transform.position,this.transform.position - offset8,10*Time.deltaTime);
			tentacule_8.transform.localPosition = pos;
		}

		if(Input.GetKey(KeyCode.UpArrow))
		{
			nothappening1 = false;
			this.transform.position = Vector3.MoveTowards(this.transform.position , tentacule_1.transform.position ,10* Time.deltaTime);
		}
		if(Input.GetKeyUp(KeyCode.UpArrow))
		{
			nothappening1 = true;
		}
		if(Input.GetKey(KeyCode.RightArrow))
		{
			nothappening2 = false;
			this.transform.position = Vector3.MoveTowards(this.transform.position , tentacule_2.transform.position ,10* Time.deltaTime);
		}
		if(Input.GetKeyUp(KeyCode.RightArrow))
		{
			nothappening2 = true;
		}
		if(Input.GetKey(KeyCode.D))
		{
			nothappening3 = false;
			this.transform.position = Vector3.MoveTowards(this.transform.position , tentacule_3.transform.position ,10* Time.deltaTime);
		}
		if(Input.GetKeyUp(KeyCode.D))
		{
			nothappening3 = true;
		}
		if(Input.GetKey(KeyCode.DownArrow))
		{
			nothappening4 = false;
			this.transform.position = Vector3.MoveTowards(this.transform.position , tentacule_4.transform.position ,10* Time.deltaTime);
		}
		if(Input.GetKeyUp(KeyCode.DownArrow))
		{
			nothappening4 = true;
		}
		if(Input.GetKey(KeyCode.S))
		{
			nothappening5 = false;
			this.transform.position = Vector3.MoveTowards(this.transform.position , tentacule_5.transform.position ,10* Time.deltaTime);
		}
		if(Input.GetKeyUp(KeyCode.S))
		{
			nothappening5 = true;
		}
		if(Input.GetKey(KeyCode.Q))
		{
			nothappening6 = false;
			this.transform.position = Vector3.MoveTowards(this.transform.position , tentacule_6.transform.position ,10* Time.deltaTime);
		}
		if(Input.GetKeyUp(KeyCode.Q))
		{
			nothappening6 = true;
		}	
		if(Input.GetKey(KeyCode.LeftArrow))
		{
			nothappening7 = false;
			this.transform.position = Vector3.MoveTowards(this.transform.position , tentacule_7.transform.position ,10* Time.deltaTime);
		}
		if(Input.GetKeyUp(KeyCode.LeftArrow))
		{
			nothappening7 = true;
		}	
		if(Input.GetKey(KeyCode.Z))
		{
			nothappening8 = false;
			this.transform.position = Vector3.MoveTowards(this.transform.position , tentacule_8.transform.position ,10* Time.deltaTime);
		}
		if(Input.GetKeyUp(KeyCode.Z))
		{
			nothappening8 = true;
		}
	}
}
