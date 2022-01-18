using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Playables;

/// <summary>バトル操作クラス</summary>
public class BattleController : MonoBehaviour
{
    private BattleCamera _camera;

    private PlaneManager _planeManager = new PlaneManager();
    private PilotManager _pilotManager = new PilotManager();
    private BulletManager _bulletManager = new BulletManager();
    private ScoreManager _scoreManager = new ScoreManager();
    private FieldManager _fieldManager = new FieldManager();

    private Plane _playerPlane;

    private PlayableDirector _playableDirector;

    private bool _isClearStage = false;
    private bool _isPlayTimeline = false;

    public void Setup()
    {
        _camera = FindObjectOfType<BattleCamera>();
        UIManager.Instance.Setup();
        _planeManager.Setup(FindObjectOfType<PlaneFactory>());
        _fieldManager.Setup(FindObjectOfType<FieldObjectFactory>());

        UIController.UpdateScoreUI(0);

        // 自機
        var pPlane = _planeManager.CreatePlane(MasterData.Instance.FindPlaneData("PLANE_DATA_0001"), _bulletManager, true);
        _pilotManager.CreatePlayerPilot(pPlane);

        // 敵
        var planeSpawnInfoList = FindObjectsOfType<PlaneSpawnInfo>();
        if (planeSpawnInfoList != null)
        {
            foreach (var planeSpawnInfo in planeSpawnInfoList)
            {
                var cPlane = _planeManager.CreatePlane(MasterData.Instance.FindPlaneData(planeSpawnInfo.Id), _bulletManager, false);
                cPlane.OnDied += (DeadCause deadCause) =>
                {
                    var explEffect = EffectManager.Instance.GetEffect(EffectNames.PlaneExplosion);
                    explEffect.Play(cPlane.Position);

                    if (deadCause.Equals(DeadCause.Shoot))
                    {
                        _scoreManager.UpdateScore(cPlane.Score);
                    }
                };
                cPlane.transform.position = planeSpawnInfo.transform.position;
                cPlane.transform.eulerAngles = new Vector3(0.0f, 180.0f, 0.0f);
                _pilotManager.CreateComPilot(cPlane, pPlane);
            }
        }

        //フィールドの物体（敵とか自我を持たないものは全部これを使う予定）
        _fieldManager.CreateAndSetupStageFieldObjects();

        _scoreManager.OnScoreChanged += (int score) => { UIController.UpdateScoreUI(score); };

        _playerPlane = pPlane;

        _camera.SetTargetPlane(_playerPlane);
    }

    public void Tick()
    {
        _pilotManager.Tick();
        _planeManager.Tick();
        _bulletManager.Tick();

        //クリア演出
        if (_playerPlane != null && _playerPlane.IsHitGoal)
        {
            if (!_isPlayTimeline)
            {
                _playableDirector = FindObjectOfType<PlayableDirector>();
                //タイムラインの再生
                _playableDirector.Play();
                _isPlayTimeline = true;
            }
            else if (_playableDirector.state.Equals(PlayState.Paused))
            {
                _isClearStage = true;
            }
        }
    }

    public void End()
    {
        EffectManager.Instance.SetAllActive(EffectNames.PlaneTrail, false);
    }

    public bool IsDeadPlayer()
    {
        return _playerPlane != null && _playerPlane.IsDead;
    }

    public bool IsClearGame()
    {
        return _isClearStage;
    }
}
