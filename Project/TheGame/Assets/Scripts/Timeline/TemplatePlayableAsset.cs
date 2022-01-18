using UnityEngine;
using UnityEngine.Playables;

[System.Serializable]
public class TemplatePlayableAsset : PlayableAsset
{
    [SerializeField]
    private ExposedReference<GameObject> templateGameObject;

    public TemplatePlayableBehaviour template = new TemplatePlayableBehaviour();

    // Factory method that generates a playable based on this asset
    public override Playable CreatePlayable(PlayableGraph graph, GameObject go)
    {
        var playable = ScriptPlayable<TemplatePlayableBehaviour>.Create(graph, template);

        // Get PlayableBehaviour
        var behaviour = playable.GetBehaviour();

        // Resolve Reference
        behaviour.templateGameObject = templateGameObject.Resolve(graph.GetResolver());

        return playable;
    }
}
