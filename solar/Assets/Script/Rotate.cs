using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {
		public Transform Sun;
    public Transform Mercury;
    public Transform Venus;
    public Transform Earth;
    public Transform Mars;
    public Transform Jupiter;
    public Transform Saturn;
    public Transform Uranus;
    public Transform Neptunia;
		private int fullAngel = 360;
	// Use this for initialization
	void Start () {
				Sun.position = Vector3.zero;
        Mercury.position = new Vector3(3.7F, 0, 0);
        Venus.position = new Vector3(4.3F, 0, 0);
        Earth.position = new Vector3(4.8F, 0, 0);
        Mars.position = new Vector3(5.6F, 0, 0);
        Jupiter.position = new Vector3(7F, 0, 0);
        Saturn.position = new Vector3(8.5F, 0, 0);
        Uranus.position = new Vector3(11F, 0, 0);
        Neptunia.position = new Vector3(13F, 0, 0);
	}

	// Update is called once per frame
	void Update () {
		Sun.Rotate (Vector3.up * fullAngel * Time.deltaTime / 26.9F);   //自转速度均由实际数据调整得来
    Mercury.Rotate (Vector3.up * fullAngel * Time.deltaTime / 58.65F);
    Venus.Rotate (Vector3.up * fullAngel * Time.deltaTime / 243.01F);
    Earth.Rotate (Vector3.up * fullAngel * Time.deltaTime / 0.9973F);
    Mars.Rotate (Vector3.up * fullAngel * Time.deltaTime / 1.026F);
    Jupiter.Rotate (Vector3.up * fullAngel * Time.deltaTime / 0.410F);
    Saturn.Rotate (Vector3.up * fullAngel * Time.deltaTime / 0.426F);
    Uranus.Rotate (Vector3.up * fullAngel * Time.deltaTime / 0.646F);
    Neptunia.Rotate (Vector3.up * fullAngel * Time.deltaTime / 0.658F);

		//公转，通过random调整法向量来实现不同法平面
		//数据同样来自实际数据，加快了100倍以便观察
		Mercury.RotateAround (Sun.transform.position, Vector3.up + Random.Range(0, 0.4F) * Vector3.left, fullAngel * Time.deltaTime / 0.877F);
    Venus.RotateAround (Sun.transform.position, Vector3.up + Random.Range(0, 0.4F) * Vector3.left, fullAngel * Time.deltaTime / 2.247F);
    Earth.RotateAround (Sun.transform.position, Vector3.up + Random.Range(0, 0.4F) * Vector3.left, fullAngel * Time.deltaTime / 3.6526F);
    Mars.RotateAround (Sun.transform.position, Vector3.up + Random.Range(0, 0.4F) * Vector3.left, fullAngel * Time.deltaTime / 6.8698F);
    Jupiter.RotateAround (Sun.transform.position, Vector3.up + Random.Range(0, 0.4F) * Vector3.left, fullAngel * Time.deltaTime / 43.3271F);
    Saturn.RotateAround (Sun.transform.position, Vector3.up + Random.Range(0, 0.4F) * Vector3.left, fullAngel * Time.deltaTime / 10.7595F);
    Uranus.RotateAround (Sun.transform.position, Vector3.up + Random.Range(0, 0.4F) * Vector3.left, fullAngel * Time.deltaTime / 30.685F);
    Neptunia.RotateAround (Sun.transform.position, Vector3.up + Random.Range(0, 0.4F) * Vector3.left, fullAngel * Time.deltaTime / 60.19F);

	}
}
