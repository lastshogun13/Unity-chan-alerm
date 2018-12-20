//
//RandomWind.cs for unity-chan!
//
//Original Script is here:
//ricopin / RandomWind.cs
//Rocket Jump : http://rocketjump.skr.jp/unity3d/109/
//https://twitter.com/ricopin416
//
// Customized by minami

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityChan {
    public class WindCustom : MonoBehaviour {

        private SpringBone[] springBones;
        public bool isWindActive = true;
        public float maxPowerRatio = 0.01f;

        public float powerRatioX = 0.0f;
        public float powerRatioZ = 0.0f;

        // Use this for initialization
        void Start() {
            springBones = GetComponent<SpringManager>().springBones;
        }

        // Update is called once per frame
        void Update() {
            if (Random.Range(0, 1.0f) < 0.002) {
                powerRatioX = Random.Range(-maxPowerRatio, maxPowerRatio);
                powerRatioZ = Random.Range(0, maxPowerRatio);
            }

    Vector3 force = Vector3.zero;
            if (isWindActive) {
                force = new Vector3(Mathf.PerlinNoise(Time.time, 0.0f) * powerRatioX, 0, Mathf.PerlinNoise(Time.time, 0.0f) * powerRatioZ);
            }

            for (int i = 0; i < springBones.Length; i++) {
                springBones[i].springForce = force;
            }
        }
    }
}
