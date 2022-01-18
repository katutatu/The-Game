using UnityEngine;
using UnityEngine.Playables;

[System.Serializable]
// A behaviour that is attached to a playable
public class TemplatePlayableBehaviour : PlayableBehaviour
{
    private PlayableDirector director;
    public GameObject templateGameObject { get; set; }

    [SerializeField]
    public bool boolValue = false;

    public override void OnPlayableCreate(Playable playable)
    {
        director = (playable.GetGraph().GetResolver() as PlayableDirector);
    }

    // Called when the owning graph starts playing
    public override void OnGraphStart(Playable playable)
    {
        //�^�C�����C���J�n��
    }

    // Called when the owning graph stops playing
    public override void OnGraphStop(Playable playable)
    {
        //�^�C�����C����~��
    }

    // Called when the state of the playable is set to Play
    public override void OnBehaviourPlay(Playable playable, FrameData info)
    {
        //PlayableTrack�Đ���
    }

    // Called when the state of the playable is set to Paused
    public override void OnBehaviourPause(Playable playable, FrameData info)
    {
        //PlayableTrack��~��
    }

    // Called each frame while the state is set to Play
    public override void PrepareFrame(Playable playable, FrameData info)
    {
        //PlayableTrack�Đ������t���[��
    }
}
