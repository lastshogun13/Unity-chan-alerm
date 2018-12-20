using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

// A behaviour that is attached to a playable
public class StartScenePlayableBehaviour : PlayableBehaviour {
    // Called when the state of the playable is set to Play
    public override void OnBehaviourPlay(Playable playable, FrameData info) {
        SceneManager.LoadSceneAsync("Unity-chan-Alarm");
    }
}
