using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour {
    public GameObject Target;
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        if (Target) {
            this.transform.position = Target.transform.TransformPoint(new Vector3( 0f, 2f, -10f));
            this.transform.LookAt(Target.transform.position);
        }
    }
}
