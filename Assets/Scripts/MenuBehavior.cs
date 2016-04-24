using UnityEngine;
using System.Collections;

public class MenuBehavior : MonoBehaviour {

	public Transform rotatePoint;
	private bool initialized = false;
	public string name;


	// Use this for initialization
	void Start () {
		rotatePoint = GameObject.FindGameObjectWithTag ("Menu").transform;
		transform.LookAt (GameObject.FindGameObjectWithTag ("MainCamera").transform);
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
				
				if (transform.parent) 
				{
					Transform parent = transform.parent;

					for (int i = 0; i < parent.childCount; i++) 
						if (parent.GetChild (i) != transform) 
							for (int j = 0; j < parent.GetChild (i).childCount; j++) 
								deactivateAllChildren(parent.GetChild(i).GetChild(j));
				}

				if (transform.childCount > 0) 
				{
					for (int i = 0; i < transform.childCount; i++) 
					{
						Transform child = transform.GetChild (i);
						child.gameObject.SetActive (true);
						if (!initialized) 
						{
							child.transform.RotateAround (rotatePoint.transform.position, rotatePoint.transform.up, 7.0f);
							child.transform.position = new Vector3 (child.transform.position.x, child.transform.position.y - (0.06f * i), 
								child.transform.position.z);
						}
					}

					initialized = true;
				}
			}
		}
	}

	void deactivateAllChildren(Transform node)
	{
		for (int i = 0; i < node.childCount; i++) 
		{
			deactivateAllChildren (node.GetChild (i));
		}

		node.gameObject.SetActive (false);
	}
}
