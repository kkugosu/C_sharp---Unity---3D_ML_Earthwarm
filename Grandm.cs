using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Grandm : MonoBehaviour {
	public GameObject mast;
	public GameObject[] clonelist;
	public float times = 0;
	public List<int[]> a; //gene store
	public float[] valuelist;
	public int[] firstp; //first gene
	public int pgeneration;
	public int i;
	public int j;
	public int k;
	public float fvaluesum;
	public float fvaluep;
	public int[] rs1val;
	public int[] rs2val;
	public int[] rs3val;
	float rannge;
	// Use this for initialization
	void Start () {
		a = new List<int[]>();
		valuelist = new float[100];
		i = 0;
		while (i < 100) {
			valuelist [i] = 0;
			i++;
		}
		clonelist = new GameObject[100];
		mast = GameObject.Find ("master");
		i = 0;
		j = 0;
		while(j < 100)
		{
			firstp = new int[960];
			while (i < 960) {
				rannge = Random.Range (0.0f, 1.0f);//make random gene
				if (rannge < 0.5) {
					firstp [i] = 1;
				} else {
					firstp [i] = 0;
				}
				i++;
			}// first gene
			i = 0;

			a.Add (firstp);
			//Debug.Log(a[j][i]); ok.
			j++;
		}
		while(i < 100)
		{
			clonelist [i] = (GameObject)Instantiate (mast); // initialize objects
			clonelist[i].transform.position = new Vector3(0, 0, 10 + 10*i); //''position
			clonelist [i].GetComponent<Master> ().thislong = clonelist[i]; //post object
			clonelist [i].GetComponent<Master> ().move = a[i]; //initialize gene
			//Debug.Log(clonelist [i].GetComponent<Master> ().move[0]);
			i++;
		}

	}

	// Update is called once per frame
	void Update () {
		i = 0;
		times = times + Time.deltaTime;
		if (times > 20) {
			times = 0;
			pgeneration++;
			k = 0;
			fvaluesum = 0;
			fvaluep = 0;
			while(i < 100)
			{
				
				if (clonelist [i].GetComponent<Master> ().goode == 1) {
					valuelist [i] = clonelist [i].GetComponent<Master> ().finalvalue;

					fvaluesum = fvaluesum + valuelist [i];
				}
				a [i] = clonelist [i].GetComponent<Master> ().move; //store gene to a
				i++;
			}
			i = 0;
			while (i < 100) {
				if (valuelist [i] != 0) {
					valuelist [i] = fvaluep + (valuelist [i] / fvaluesum);
					fvaluep = valuelist [i];
				}
					i++;
			} //nu juck percent value

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
				clonelist[i].transform.position = new Vector3(0, 0, 10 + 10*i); //''position
				clonelist [i].GetComponent<Master> ().thislong = clonelist[i];//post object
				i++;
			}
			i = 0;
			rs1val = new int[960];
			rs2val = new int[960];
			rs3val = new int[960];
			while (i < 100) {
				findgoodele (a, valuelist, rs1val, rs2val);
				mixandmut (rs1val, rs2val, rs3val);
				clonelist [i].GetComponent<Master> ().move = rs3val; // re_initialize gene
				i++;
			}
			i = 0;
		}
	}
	void findgoodele(List<int[]> a, float[] vl, int[] rs1val, int[] rs2val )
	{
		float rannge;
		int i = 0;
		rannge = Random.Range (0.0f, 1.0f);
		while (vl [i] < rannge) {
			i++;

		}
		rs1val = a [i];
		i = 0;
		rannge = Random.Range (0.0f, 1.0f);
		while (vl [i] < rannge) {
			i++;

		}
		rs2val = a [i];
	}
	void mixandmut(int[] rs1val, int[] rs2val, int[] rs3val)
	{
		float rannge;
		int i = 0;
		int c = 0;
		while (i < 960) {

			rannge = Random.Range (0.0f, 1.0f);
			if (rannge < 0.5f) {
				while (c < 48) {
					rs3val [i + c] = rs1val [i +c];
					c++;
				}
				c = 0;
			} else {
				while (c < 48) {

					rs3val [i+ c] = rs2val [i + c];
					c++;
				}
				c = 0;
			}
			i = i + 48;
		}//mix
		i = 0;
		while (i < 960) {

			rannge = Random.Range (0.0f, 1.0f);
			if (rannge < 0.01f) {
				rs3val [i] = 1 - rs3val[i]; 
		
			}
			i++;
		} // mut
	}
}
