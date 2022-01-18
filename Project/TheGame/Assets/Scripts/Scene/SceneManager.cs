using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : SingletonMonoBehaviour<SceneManager>
{
    public System.Action<string> OnPreStartScene;
    public System.Action OnPreEndScene;


    private bool _isSceneChanging;
    private Scene _scene;


    public void FixedTick()
    {
        if (_scene != null)
        {
            _scene.FixedTick();
        }
    }

    public void Tick()
    {
        if (_scene != null)
        {
            _scene.Tick();
        }
    }

    public void ChangeScene(string sceneName)
    {
        // 遷移中のシーン変更リクエストはブロックする
        Debug.Assert(!_isSceneChanging);
        if (_isSceneChanging) { return; }

        StartCoroutine(ChangeSceneInternal(sceneName));
    }

    public string GetActiveSceneName()
    {
        return UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
    }

    IEnumerator ChangeSceneInternal(string sceneName)
    {
        _isSceneChanging = true;

        if (_scene != null)
        {
            OnPreEndScene?.Invoke();
            _scene.EndScene();
            yield return _scene.EndSceneAsync();
            Destroy(_scene);
        }

        yield return UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName);

        if (sceneName == SceneNames.Title)
        {
            _scene = gameObject.AddComponent<TitleScene>();
        }
        else if (sceneName == SceneNames.StageSelect)
        {
            _scene = gameObject.AddComponent<StageSelectScene>();
        }
        else if (SceneNames.IsBattleSceneName(sceneName))
        {
            _scene = gameObject.AddComponent<BattleScene>();
        }
        else if (sceneName == SceneNames.Result)
        {
            _scene = gameObject.AddComponent<ResultScene>();
        }
        else
        {
            Debug.LogError("Not implemented Scene.");
        }

        if (_scene != null)
        {
            OnPreStartScene?.Invoke(sceneName);
            _scene.StartScene();
            yield return _scene.StartSceneAsync();
        }

        _isSceneChanging = false;
    }
}
