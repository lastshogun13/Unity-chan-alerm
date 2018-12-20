using UnityEngine;
using Cinemachine;

public class CinemachineAutoOrbitalAxis : MonoBehaviour {
    CinemachineVirtualCamera vCam;
    CinemachineOrbitalTransposer orbTrans;
    [Range(-2, 2)]
    public float autoOrbital = 0;

    // Use this for initialization
    void Start() {
        vCam = GetComponent<CinemachineVirtualCamera>();
        //orbTrans = GetComponent<CinemachineOrbitalTransposer>();
    }

    // Update is called once per frame
    void Update() {
        orbTrans = vCam.GetCinemachineComponent<CinemachineOrbitalTransposer>();
        orbTrans.m_XAxis.m_InputAxisValue = autoOrbital;
    }
}