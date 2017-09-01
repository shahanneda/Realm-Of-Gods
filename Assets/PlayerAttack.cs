using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
namespace Main{
	public class PlayerAttack : NetworkBehaviour {
		public GameObject BasicAtack;
		public float BasicAttackSpeed;
		void OnEnable(){
			SetInitialReferences();
		}

		void OnDisable(){

		}

		void SetInitialReferences(){

		}

		// Use this for initialization
		void Start () {
		
		}
		
		// Update is called once per frame
		void Update () {
			if(Input.GetMouseButtonDown(0) && isLocalPlayer){
				CmdFire (Camera.main.ScreenToWorldPoint(Input.mousePosition));



			}
		}

		[Command]
		void CmdFire(Vector3 point)
		{
			
			GameObject bullet = Instantiate(BasicAtack,transform.position + new Vector3(0,10),Quaternion.identity) as GameObject;
			Vector2 direction = point- transform.position;
			bullet.GetComponent<Rigidbody2D> ().velocity =direction *BasicAttackSpeed;

			NetworkServer.Spawn(bullet);

		}



	}
}
