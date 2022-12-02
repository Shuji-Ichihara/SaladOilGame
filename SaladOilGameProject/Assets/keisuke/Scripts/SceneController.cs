using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController Instance { get => _instance; }
    static SceneController _instance;

    private FadeController _fadeController = null;

    #region シーン名
    private static string _titleScene = "TitleScene";
    private static string _operationScene = "OperationScene";
    private static string _gameScene = "GameScene";
    private static string _resultScene = "ResultScene";
    private static string _endScene = "EndScene";
    #endregion

    private void Awake()
    {
        if (_instance == null) { _instance = this; }
        else { Destroy(this); }
        DontDestroyOnLoad(_instance);
        _fadeController = GetComponent<FadeController>();
    }

    // Update is called once per frame
    void Update()
    {
        //  開始フラグを立てる
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartCoroutine(_fadeController.FadeOut());
        }
    }

    /// <summary>
    /// Scene の変更
    /// </summary>
    /// <param name="sceneName">現在のシーン名</param>
    /// <returns></returns>
    public IEnumerator LoadScene(string sceneName)
    {
        switch (sceneName)
        {
            case "TitleScene":
                SceneManager.LoadSceneAsync(_operationScene);
                break;
            case "OperationScene":
                SceneManager.LoadSceneAsync(_gameScene);
                break;
            case "GameScene":
                SceneManager.LoadSceneAsync(_resultScene);
                break;
            case "ResultScene":
                SceneManager.LoadSceneAsync(_endScene);
                break;
            case "EndScene":
                SceneManager.LoadSceneAsync(_titleScene);
                break;

        }
        yield return null;
    }
}
