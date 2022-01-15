using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : SingletonMonoBehaviour<SceneManager>
{
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

    public Coroutine ChangeScene(string sceneName)
    {
        return StartCoroutine(ChangeSceneInternal(sceneName));
    }

    public string GetActiveSceneName()
    {
        return UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
    }

    IEnumerator ChangeSceneInternal(string sceneName)
    {
        if (_scene != null)
        {
            _scene.EndScene();
            yield return _scene.EndSceneAsync();
            Destroy(_scene);
        }

        yield return UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName);

        switch (sceneName)
        {
            case SceneNames.Title:
                _scene = gameObject.AddComponent<TitleScene>();
                break;
            case SceneNames.StageSelect:
                _scene = gameObject.AddComponent<StageSelectScene>();
                break;
            case SceneNames.Stage1:
            case SceneNames.Stage2:
                _scene = gameObject.AddComponent<BattleScene>();
                break;
            case SceneNames.Result:
                _scene = gameObject.AddComponent<ResultScene>();
                break;
            default:
                Debug.LogError("Not implemented Scene.");
                break;
        }

        if (_scene != null)
        {
            _scene.StartScene();
            yield return _scene.StartSceneAsync();
        }
    }
}
