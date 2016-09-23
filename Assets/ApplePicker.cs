using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ApplePicker : MonoBehaviour {

	public GameObject basketPrefab;
	public int numBaskets = 3;
	public float basketsBottomY = -14f;
	public float basketsSpacingY = 2f;
	public List<GameObject> basketList;

	// Use this for initialization
	void Start () {
		basketList = new List<GameObject> ();
		for (int i = 0; i < numBaskets; i++) {
			GameObject tBasketGO = Instantiate (basketPrefab) as GameObject;
			Vector3 pos = Vector3.zero;
			pos.y = basketsBottomY + (basketsSpacingY * i);
			tBasketGO.transform.position = pos;
			basketList.Add (tBasketGO);
		}
	}

	public void AppleDestroyed()
	{
		//destroy all of the falling apples
		GameObject[] tAppleArray=GameObject.FindGameObjectsWithTag ("Apple");
		foreach (GameObject tGO in tAppleArray) {
			Destroy (tGO);
		}

		//destroy one of the baskets
		//get the index of the last basket in basketlist
		int basketIndex = basketList.Count-1;
		//get a reference to that basket gameobject
		GameObject tBasketGO = basketList[basketIndex];
		//remove the basket from the list and destoy the gameobject
		basketList.RemoveAt(basketIndex);
		Destroy(tBasketGO);

		//restart the game which doesn't affect highscore.score
		if (basketList.Count == 0) {
			Application.LoadLevel ("_Scene_0");
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}