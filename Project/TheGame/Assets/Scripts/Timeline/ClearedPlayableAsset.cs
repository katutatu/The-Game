using UnityEngine;
using UnityEngine.Playables;

[System.Serializable]
public class ClearedPlayableAsset : TemplatePlayableAsset
{
    [SerializeField]
    private ExposedReference<GameObject> ClearedtemplateGameObject;

    public ClearedPlayableBehaviour Clearedtemplate = new ClearedPlayableBehaviour();

    // Factory method that generates a playable based on this asset
    public override Playable CreatePlayable(PlayableGraph graph, GameObject go)
    {
        var playable =  ScriptPlayable<ClearedPlayableBehaviour>.Create(graph, Clearedtemplate);

        // Get PlayableBehaviour
        var behaviour = playable.GetBehaviour();

        // Resolve Reference
        behaviour.templateGameObject = ClearedtemplateGameObject.Resolve(graph.GetResolver());

        return playable;
    }
}
