using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtController : MonoBehaviour {
    public float weight = 1.0f;
    public float bodyWeight = 0.5f;
    public float headWeight = 0.7f;
    public float eyesWeight = 0.95f;
    public float clampWeight = 0.0f;

    Animator animator;
    Vector3 targetPos;
    Vector3 originalTargetPos;

    void Start() {
        this.animator = GetComponent<Animator>();
        this.originalTargetPos = Camera.main.transform.position;
    }

    void Update() {
        //if (Input.GetMouseButton(0)) {
        //    Vector3 touchPos = Camera.main.ScreenPointToRay(Input.mousePosition).origin;
        //    touchPos.z = -0.5f;
        //    targetPos = touchPos;
        //}

        //this.targetPos = Camera.main.transform.position;

    }

    private void OnAnimatorIK(int layerIndex) {
        this.targetPos = Camera.main.transform.position;
        if (this.targetPos.z > 0) { // 後ろは、Z軸反転
            this.targetPos.z = - this.targetPos.z;
        }
        //Debug.Log("1:"+layerIndex + ":" + this.targetPos);

        this.animator.SetLookAtWeight(weight, bodyWeight, headWeight, eyesWeight, clampWeight);
        this.animator.SetLookAtPosition(this.targetPos);
    }
}