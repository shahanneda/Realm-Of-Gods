using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
namespace Main{
	public class PlayerMovement : NetworkBehaviour {
		GameObject field;
		Vector2 goToPos ;
		public int cameraCurrentZoom = 40;
		public int cameraZoomMax = 100;
		public int cameraZoomMin = 0;

		void OnEnable(){
			SetInitialReferences();
			if (isLocalPlayer) {
				print ("islocalplayer");
				gameObject.tag= "Player";

			}
		}

		void OnDisable(){

		}

		void SetInitialReferences(){
			field = GameObject.Find ("Field");
			Camera.main.orthographicSize = cameraCurrentZoom;
		}

		// Use this for initialization
		void Start () {

		}
		
		// Update is called once per frame
		public float speed;
		void Update() {
			if (isLocalPlayer) {
				print ("islocalplayer");
				gameObject.tag = "Player";
			}

			if (!isLocalPlayer)
			{
				print (isLocalPlayer);
				gameObject.GetComponentInChildren<Camera> ().enabled = false;
				return;
			}

			//moving
			float step = speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards(transform.position, goToPos, step);
			//camara zoom
			if (Input.GetAxis("Mouse ScrollWheel") < 0) // back
			{
				if (cameraCurrentZoom < cameraZoomMax)
				{
					cameraCurrentZoom += 1;
					Camera.main.orthographicSize = Mathf.Max(Camera.main.orthographicSize + 1);
				} 
			}
			if (Input.GetAxis("Mouse ScrollWheel") > 0) // forward
			{
				if (cameraCurrentZoom > cameraZoomMin)
				{
					cameraCurrentZoom -= 1;
					Camera.main.orthographicSize = Mathf.Min(Camera.main.orthographicSize - 1);
				}   
			}
		}

		public void ClickedToMove(Vector3 pos){
			if (!isLocalPlayer) {
				return;
			}
			Vector2 pos2 = new Vector2 (pos.x,pos.y);
			goToPos = pos2;

		}

	}
}
