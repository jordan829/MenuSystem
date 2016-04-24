using UnityEngine;
using System.Collections;

public class MenuBahavior2 : MonoBehaviour {
	public int numChildren;
	public Transform rotatePoint;
	public Transform menuItem;
	private bool initialized = false;
	public string name;

	// Use this for initialization
	void Start () {
		numChildren = 5;
		rotatePoint = GameObject.FindGameObjectWithTag ("Menu").transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			int layerMask = 1 << 8;
			RaycastHit raycastInfo;
			if (Physics.Raycast(ray, out raycastInfo, 200, layerMask) && raycastInfo.transform == transform)
			{
				Debug.Log ("meow");
				/*if (transform.parent) 
				{
					Transform parent = transform.parent;

					for (int i = 0; i < parent.childCount; i++) 
						if (parent.GetChild (i) != transform) 
							for (int j = 0; j < parent.GetChild (i).childCount; j++) 
								parent.GetChild (i).GetChild (j).gameObject.SetActive (false);
				}*/

				for (int i = 0; i < numChildren; i++) 
				{
					Transform child = Instantiate(menuItem);
					child.gameObject.SetActive (true);
					if (!initialized) 
					{
						child.parent = transform;

						child.position = new Vector3 (transform.position.x, transform.position.y - (0.06f * i), 
							transform.position.z);
						child.RotateAround (rotatePoint.transform.position, rotatePoint.transform.up, 7.0f);
					}
				}

				initialized = true;
			}
		}
	}
}