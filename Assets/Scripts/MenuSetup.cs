using UnityEngine;
using System.Collections;

public class MenuSetup : MonoBehaviour {

	// Use this for initialization
	void Start () {
		for (int i = 0; i < transform.childCount; i++) {
			transform.GetChild (i).transform.localPosition = new Vector3 (0.5f, -0.06f * i, 0.0f);
			transform.GetChild (i).gameObject.SetActive (true);
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
