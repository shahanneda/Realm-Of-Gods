using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
namespace Main{
	public class Field : NetworkBehaviour {
		PlayerMovement playermove;
		void OnEnable(){
			SetInitialReferences();
		}

		void OnDisable(){

		}

		void SetInitialReferences(){
			print (GameObject.FindGameObjectWithTag ("Player"));
			playermove = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerMovement> ();
		}

		// Use this for initialization
		void Start () {
		
		}
		
		// Update is called once per frame
		void Update () {
			if(Input.GetMouseButtonDown(1)){
				if (!playermove) {
					SetInitialReferences ();

				}


				playermove.ClickedToMove (Camera.main.ScreenToWorldPoint(Input.mousePosition));
			}
		}

		void OnMouseDown()

		{
			
		}


		void OnMouseOver(){
			
		}


	}
}
