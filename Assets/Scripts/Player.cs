using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.EventSystems;
using UnityEngine.AI;

public class Player : MonoBehaviour {

	//public Rigidbody Rigidbody;
	public NavMeshAgent agent;

	protected float speed = 6f;
	protected Vector3 movementDirection;
		
	public void Move(float x, float z) {
		movementDirection.Set(x * speed, 0f, z * speed);
		if (agent != null) {
			//Rigidbody.MoveRotation (Quaternion.LookRotation (movementDirection));
			// rotate with oculus
			//Rigidbody.MovePosition (gameObject.transform.position + movementDirection);
			agent.transform.position = new Vector3(
				gameObject.transform.position.x + movementDirection.x,
				gameObject.transform.position.y,
				gameObject.transform.position.z + movementDirection.z);

		}
	}
		
	public void Jump() {
		if (agent != null) {
			//Rigidbody.AddForce (gameObject.transform.up * 5f, ForceMode.Impulse);
		}
	}
}
