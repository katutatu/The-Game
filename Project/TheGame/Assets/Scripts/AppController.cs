using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppController : SingletonMonoBehaviour<AppController>
{
    public bool IsReady { get; private set; }


    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    public static void OnLoad()
    {
        // AppCommon読み込み
        UnityEngine.SceneManagement.SceneManager.LoadScene("AppCommon", UnityEngine.SceneManagement.LoadSceneMode.Additive);
    }

    private IEnumerator Start()
    {
        if (IsReady) { yield break; }

        // アプリ設定
        Application.targetFrameRate = 60;

        // ユーザーデータ読み込み
        StaticUserData.Load();

        EffectManager.Instance.Setup();
        SoundManager.Instance.Setup();
#if UNITY_EDITOR
        FPSCounter.CreateIfNull();
#endif

        SceneManager.Instance.OnPreStartScene += (string sceneName) => 
        {
            UIManager.Instance.BindSceneUI(sceneName);
        };
        SceneManager.Instance.OnPreEndScene += () =>
        {
            UIManager.Instance.UnbindSceneUI();
        };

        // SceneManager初期化中に他のManagerクラスを使用するため最後に初期化
        var startSceneName = SceneManager.Instance.GetActiveSceneName();
        SceneManager.Instance.ChangeScene(startSceneName);

        IsReady = true;
    }

    private void FixedUpdate()
    {
        if (!IsReady) { return; }

        SceneManager.Instance.FixedTick();
    }

    private void Update()
    {
        if (!IsReady) { return; }

#if UNITY_EDITOR
        // Escキーでアプリ終了
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
#endif

        EffectManager.Instance.Tick();
        SceneManager.Instance.Tick();
    }
}
