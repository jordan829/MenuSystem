using UnityEngine;
using System.Collections;

public class SelectionBehavior : MonoBehaviour {
		
	private GameObject lastGO;
	private Color lastColor;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			int layerMask = 1 << 8;
			RaycastHit raycastInfo;
			if (Physics.Raycast(ray, out raycastInfo, 200, layerMask))
			{
				if (lastGO != null)
					lastGO.GetComponent<Renderer>().material.color = lastColor;

				lastGO = raycastInfo.transform.gameObject;
				lastColor = lastGO.GetComponent<Renderer>().material.color;
				lastGO.GetComponent<Renderer>().material.color = Color.green;
			}
		}
	}
}
