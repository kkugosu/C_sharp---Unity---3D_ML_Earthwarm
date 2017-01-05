using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grandm : MonoBehaviour {
	GameObject mast;
	GameObject[] clonelist;
	public float times = 0;
	List<int[]> a = new List<int[]>(); //gene store
	int[] firstp; //first gene
	int pgeneration;
	int i;
	float rannge;
	// Use this for initialization
	void Start () {
		mast = GameObject.Find ("master");
		i = 0;
		while(i < 960)
		{
			rannge = Random.Range (0.0f , 1.0f);//make random gene
			if (rannge < 0.5) {
				firstp [i] = 1;
			} else {
				firstp [i] = 0;
			}
			i++;
		}// first gene
		i = 0;
		while(i < 100)
		{
			clonelist [i] = (GameObject)Instantiate (mast); // initialize objects
			clonelist[i].transform.position = new Vector3(6, 0, 10 + 10*i); //''position
			clonelist [i].GetComponent<Master> ().thislong = clonelist[i]; //post object
			clonelist [i].GetComponent<Master> ().move = firstp; //initialize gene

			i++;
		}
			
	}
	
	// Update is called once per frame
	void Update () {
		i = 0;
		times = times + Time.deltaTime;
		if (times > 10) {
			times = 0;
			pgeneration++;

			while(i < 100)
			{
				a [i] = clonelist [i].GetComponent<Master> ().move; //store gene to a
				i++;
			}
			i = 99;
			while(i >= 0 )
			{
				Destroy(clonelist[i]); //destory object
				i = i - 1;
			}

			i = 0;
			clonelist = new GameObject[100];
			while (i < 100) {
				clonelist [i] = (GameObject)Instantiate (mast); //make new object setting
				clonelist[i].transform.position = new Vector3(6, 0, 10 + 10*i); //''position
				clonelist [i].GetComponent<Master> ().thislong = clonelist[i];//post object
				i++;
			}
			i = 0;
			while (i < 100) {

				clonelist [i].GetComponent<Master> ().move = a[i]; // re_initialize gene
				i++;
			}
			i = 0;
		}



	}
}
