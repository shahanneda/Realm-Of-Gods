using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;
namespace Main{
	public class PlayerHealth : NetworkBehaviour {
		public int health = 100;
		public Text healthText;
		void OnEnable(){
			SetInitialReferences();
		}

		void OnDisable(){

		}

		void SetInitialReferences(){
			healthText = GameObject.Find ("HealthText").GetComponent<Text> ();
		}

		// Use this for initialization
		void Start () {
		
		}
		
		// Update is called once per frame
		void Update () {
			if (healthText) {
				healthText.text = health.ToString();
			}
		}

		void OnTriggerEnter2D(Collider2D coll){
			if (!isLocalPlayer)
				return;
			print (coll.name);
			if(coll.tag == "Bullet"){
				health -= 10;
				healthText.text = health.ToString();
				print (health);
			}

		}
	}
}
