using UnityEngine;
using System.Collections;

public class FakeTime : MonoBehaviour {

    private float _time;

	// Use this for initialization
	void Start () {
        _time = Random.Range(0, 10f);
	}
	
	// Update is called once per frame
	void Update () {
        _time -= Time.deltaTime;
	}
}
