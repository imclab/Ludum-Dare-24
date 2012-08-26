using UnityEngine;
using System.Collections;

public class BumperScript : MonoBehaviour {
	
	public bool roundBumper = true;
	public float bumperForce  = 100f;
	
	void OnCollisionEnter( Collision collision ) {
		if(roundBumper) {
			Vector3 force = collision.contacts[0].point - transform.position;
			force = force.normalized * bumperForce;
			force.y = 0;
		
			collision.rigidbody.AddForce( force, ForceMode.Impulse );
			
		}
		else {
			Vector3 force = new Vector3( 0, 0, bumperForce );
			collision.rigidbody.AddForce( force, ForceMode.Impulse );
		}
		DoAnimation();
	}
	
	void DoAnimation() {
		// Find a "bumper" child, if it exists.
		
		Transform bumper = transform.Find("bumper");
		Debug.Log (gameObject.name);
		Debug.Log (bumper);
		
		if (bumper) {
			Debug.Log ("Found bumper child");
			bumper.animation.Play("Active");
		}
	}
}
