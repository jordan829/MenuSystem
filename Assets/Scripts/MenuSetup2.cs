using UnityEngine;
using System.Collections;

public class MenuSetup2 : MonoBehaviour {

	public Transform menuItem;
	public int numChildren;

	// Use this for initialization
	void Start () {
		numChildren = 5;
		for (int i = 0; i < numChildren; i++) {
			Transform menu = Instantiate (menuItem);
			menu.localPosition = new Vector3 (0.5f, transform.position.y - 0.06f * i, 0.0f);
			menu.gameObject.SetActive (true);
			menu.parent = transform;
		}

	}
	
	// Update is called once per frame
	void Update () {
	}
}
