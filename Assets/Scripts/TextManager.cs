using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextManager : MonoBehaviour {

    private GameObject Instructions;

	// Use this for initialization
	void Start () {
        if (Instructions == null) Instructions = GameObject.Find("Instructions");
	}
	
	// Update is called once per frame
	void Update () {
        if (Instructions == null) return;
        Instructions.transform.position = Camera.main.transform.position + Camera.main.transform.forward;
        Instructions.transform.rotation = Quaternion.LookRotation(Camera.main.transform.forward);
        Instructions.transform.localScale = Vector3.one * 0.0075f;
	}
}
