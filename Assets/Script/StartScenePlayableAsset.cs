using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

[System.Serializable]
public class StartScenePlayableAsset : PlayableAsset {

    // Factory method that generates a playable based on this asset
    public override Playable CreatePlayable(PlayableGraph graph, GameObject go) {
        var behaviour = new StartScenePlayableBehaviour();
        return ScriptPlayable<StartScenePlayableBehaviour>.Create(graph, behaviour);
        //        return Playable.Create(graph);
    }
}
