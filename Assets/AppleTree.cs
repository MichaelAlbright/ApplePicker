using UnityEngine;
using System.Collections;

public class AppleTree : MonoBehaviour {

	//prefab for instantiating Apples
	public GameObject applePrefab;
	//speed at which AppleTree moves in meters/second
	public float speed = 1f;
	//distance where AppleTree turns around
	public float leftAndRightEdge = 10f;
	//chance that the AppleTree will change directions
	public float chanceToChangeDirections = 0.1f;
	//rate at which Apples will be instantiated
	public float secondsBetweenAppleDrops = 1f;

	// Use this for initialization
	void Start () {
		//dropping apples every second
		InvokeRepeating("DropApples", 2f, secondsBetweenAppleDrops);
	}

	void DropApples() {
		GameObject apple = Instantiate (applePrefab) as GameObject;
		apple.transform.position = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		//basic mivement
		Vector3 pos = transform.position;
		pos.x += speed * Time.deltaTime;
		transform.position = pos;
		//changing direction
		if (pos.x < -leftAndRightEdge) {
			speed = Mathf.Abs (speed); //move right
		} else if (pos.x > leftAndRightEdge) {
			speed = -Mathf.Abs (speed); //move left
		}
	}

	void FixedUpdate() {
		if (Random.value < chanceToChangeDirections) {
			speed *= -1; //change direction
		}
	}
}
