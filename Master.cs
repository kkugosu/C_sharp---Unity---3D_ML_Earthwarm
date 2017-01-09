using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Master : MonoBehaviour {
	public int[] move = new int[960];
	public GameObject c1;
	public GameObject c2;
	public GameObject c3;
	public GameObject c4;
	public GameObject c5;
	public GameObject thislong;
	public Rigidbody r1;
	public Rigidbody r2;
	public Rigidbody r3;
	public Rigidbody r4;
	public Rigidbody r5;
	public GameObject tempobj5;
	public float temp5x;
	public float temp5y;
	public GameObject tempobj4;
	public float temp4x;
	public float temp4y;
	public GameObject tempobj3_1;
	public float temp3_1x;
	public float temp3_1y;
	public GameObject tempobj3_2;
	public float temp3_2x;
	public float temp3_2y;
	public GameObject tempobj2;
	public float temp2x;
	public float temp2y;
	public GameObject tempobj1;
	public float temp1x;
	public float temp1y;
	public float times;
	public int generation;
	public int pos;
	public int torque;

	// Use this for initialization
	void Start () {
		int i = 0;

		while(i < 960)
		{
			//Debug.Log("asdf ==== "+move [i]);
			i++;
		}

		c1 = thislong.transform.Find ("Cylinder").gameObject;
		c2 = thislong.transform.Find ("Cylinder2").gameObject;
		c3 = thislong.transform.Find ("Cylinder3").gameObject;
		c4 = thislong.transform.Find ("Cylinder4").gameObject;
		c5 = thislong.transform.Find ("Cylinder5").gameObject; //get object and find child
		tempobj5 = c5.transform.Find("fCube").gameObject;
		tempobj4 = c4.transform.Find("fCube").gameObject;
		tempobj3_1 = c3.transform.Find("fCube").gameObject;
		tempobj3_2 = c3.transform.Find("bCube").gameObject;
		tempobj2 = c2.transform.Find("bCube").gameObject;
		tempobj1 = c1.transform.Find("bCube").gameObject;
		r1 = c1.GetComponent<Rigidbody>();
		r2 = c2.GetComponent<Rigidbody>();
		r3 = c3.GetComponent<Rigidbody>();
		r4 = c4.GetComponent<Rigidbody>();
		r5 = c5.GetComponent<Rigidbody>();
		pos = 0;
		generation = 0;
		torque = 300;
	}
	
	// Update is called once per frame
	void Update () {
		

		if (pos > 912) {
			times = 0;
			pos = 0;
			generation++;

		}
		if (generation == 1) {

			temp5x = tempobj5.GetComponent<Transform> ().position.x - c5.GetComponent<Transform> ().position.x;
			temp4x = tempobj4.GetComponent<Transform> ().position.x- c4.GetComponent<Transform> ().position.x;
			temp3_1x = tempobj3_1.GetComponent<Transform> ().position.x- c3.GetComponent<Transform> ().position.x;
			temp3_2x = tempobj3_2.GetComponent<Transform> ().position.x - c3.GetComponent<Transform> ().position.x;
			temp2x = tempobj2.GetComponent<Transform> ().position.x- c2.GetComponent<Transform> ().position.x;
			temp1x = tempobj1.GetComponent<Transform> ().position.x - c1.GetComponent<Transform> ().position.x;

			temp5y = tempobj5.GetComponent<Transform> ().position.z- c5.GetComponent<Transform> ().position.z;
			temp4y = tempobj4.GetComponent<Transform> ().position.z- c4.GetComponent<Transform> ().position.z;
			temp3_1y = tempobj3_1.GetComponent<Transform> ().position.z- c3.GetComponent<Transform> ().position.z;
			temp3_2y = tempobj3_2.GetComponent<Transform> ().position.z- c3.GetComponent<Transform> ().position.z;
			temp2y = tempobj2.GetComponent<Transform> ().position.z- c2.GetComponent<Transform> ().position.z;
			temp1y = tempobj1.GetComponent<Transform> ().position.z- c1.GetComponent<Transform> ().position.z; //get vector

			if ((temp5x * temp4y - temp4x * temp5y) > 0) {
				r5.AddTorque (300 * Vector3.down);
				r4.AddTorque (300 * Vector3.up);
			} else {
				r4.AddTorque (300 * Vector3.down);
				r5.AddTorque (300 * Vector3.up);
			}
			if ((temp4x * temp3_1y - temp3_1x * temp4y) > 0) {
				r4.AddTorque (300 * Vector3.down);
				r3.AddTorque (300 * Vector3.up);
			} else {
				r3.AddTorque (300 * Vector3.down);
				r4.AddTorque (300 * Vector3.up);
			}
			if ((temp1x * temp2y - temp2x * temp1y) > 0) {
				r1.AddTorque (300 * Vector3.down);
				r2.AddTorque (300 * Vector3.up);
			} else {
				r2.AddTorque (300 * Vector3.down);
				r1.AddTorque (300 * Vector3.up);
			}
			if ((temp2x * temp3_2y - temp3_2x * temp2y) > 0) {
				r2.AddTorque (300 * Vector3.down);
				r3.AddTorque (300 * Vector3.up);
			} else {
				r3.AddTorque (300 * Vector3.down);
				r2.AddTorque (300 * Vector3.up);
			} //fix pos

		}
		if (generation == 0) {

		r1.AddTorque(torque*(move[pos + 0]*Vector3.right + 2*move[pos + 1]*Vector3.right + move[pos + 2]*Vector3.left + 2*move[pos + 3]*Vector3.left
			+ move[pos + 4]*Vector3.up + 2* move[pos + 5]*Vector3.up + move[pos + 6]*Vector3.down + 2*move[pos + 7]*Vector3.down
			+ move[pos + 8]*Vector3.forward + 2*move[pos + 9]*Vector3.forward + move[pos + 10]*Vector3.back + move[pos + 11]*Vector3.back));
		r2.AddTorque(torque*(move[pos + 0]*Vector3.left + 2*move[pos + 1]*Vector3.left + move[pos + 2]*Vector3.right + 2*move[pos + 3]*Vector3.right
			+ move[pos + 4]*Vector3.down + 2* move[pos + 5]*Vector3.down + move[pos + 6]*Vector3.up + 2*move[pos + 7]*Vector3.up
			+ move[pos + 8]*Vector3.back + 2*move[pos + 9]*Vector3.back + move[pos + 10]*Vector3.forward + move[pos + 11]*Vector3.forward));
		

		r2.AddTorque(torque*(move[pos + 12]*Vector3.right + 2*move[pos + 13]*Vector3.right + move[pos + 14]*Vector3.left + 2*move[pos + 15]*Vector3.left
			+ move[pos + 16]*Vector3.up + 2* move[pos + 17]*Vector3.up + move[pos + 18]*Vector3.down + 2*move[pos + 19]*Vector3.down
			+ move[pos + 20]*Vector3.forward + 2*move[pos + 21]*Vector3.forward + move[pos + 22]*Vector3.back + move[pos + 23]*Vector3.back));
		r3.AddTorque(torque*(move[pos + 12]*Vector3.left + 2*move[pos + 13]*Vector3.left + move[pos + 14]*Vector3.right + 2*move[pos + 15]*Vector3.right
			+ move[pos + 16]*Vector3.down + 2* move[pos + 17]*Vector3.down + move[pos + 18]*Vector3.up + 2*move[pos + 19]*Vector3.up
			+ move[pos + 20]*Vector3.back + 2*move[pos + 21]*Vector3.back + move[pos + 22]*Vector3.forward + move[pos + 23]*Vector3.forward));

		r3.AddTorque(torque*(move[pos + 24]*Vector3.right + 2*move[pos + 25]*Vector3.right + move[pos + 26]*Vector3.left + 2*move[pos + 27]*Vector3.left
			+ move[pos + 28]*Vector3.up + 2* move[pos + 29]*Vector3.up + move[pos + 30]*Vector3.down + 2*move[pos + 31]*Vector3.down
			+ move[pos + 32]*Vector3.forward + 2*move[pos + 33]*Vector3.forward + move[pos + 34]*Vector3.back + move[pos + 35]*Vector3.back));
		r4.AddTorque(torque*(move[pos + 24]*Vector3.left + 2*move[pos + 25]*Vector3.left + move[pos + 26]*Vector3.right + 2*move[pos + 27]*Vector3.right
			+ move[pos + 28]*Vector3.down + 2* move[pos + 29]*Vector3.down + move[pos + 30]*Vector3.up + 2*move[pos + 31]*Vector3.up
			+ move[pos + 32]*Vector3.back + 2*move[pos + 33]*Vector3.back + move[pos + 34]*Vector3.forward + move[pos + 35]*Vector3.forward));

		r4.AddTorque(torque*(move[pos + 36]*Vector3.right + 2*move[pos + 37]*Vector3.right + move[pos + 38]*Vector3.left + 2*move[pos + 39]*Vector3.left
			+ move[pos + 40]*Vector3.up + 2* move[pos + 41]*Vector3.up + move[pos + 42]*Vector3.down + 2*move[pos + 43]*Vector3.down
			+ move[pos + 44]*Vector3.forward + 2*move[pos + 45]*Vector3.forward + move[pos + 46]*Vector3.back + move[pos + 47]*Vector3.back));
		r5.AddTorque(torque*(move[pos + 36]*Vector3.left + 2*move[pos + 37]*Vector3.left + move[pos + 38]*Vector3.right + 2*move[pos + 39]*Vector3.right
			+ move[pos + 40]*Vector3.down + 2* move[pos + 41]*Vector3.down + move[pos + 42]*Vector3.up + 2*move[pos + 43]*Vector3.up
			+ move[pos + 44]*Vector3.back + 2*move[pos + 45]*Vector3.back + move[pos + 46]*Vector3.forward + move[pos + 47]*Vector3.forward));
		// child move
		}
		times = times + Time.deltaTime;
		if (times > 0.5) {
			times = 0;
			pos = pos + 48;
		}
	}
}
