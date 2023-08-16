using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    #region Singleton
    public static LevelManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }
    #endregion
    public event Action<SceneType> OnSceneLoaded;
    [SerializeField] private GameObject loaderCanvas;
    [SerializeField] private Image progressBar;
    private float target;
    private void Update()
    {
        progressBar.fillAmount = Mathf.MoveTowards(progressBar.fillAmount, target, 3 * Time.deltaTime);
    }
    public async void LoadScene(SceneType sceneType)
    {
        target = 0;
        progressBar.fillAmount = 0;

        var scene = SceneManager.LoadSceneAsync(sceneType.ToString());
        scene.allowSceneActivation = false;

        loaderCanvas.SetActive(true);

        do
        {
            await Task.Delay(100);
            target = scene.progress;
        } while (scene.progress < .9f);

        await Task.Delay(1000);
        scene.allowSceneActivation = true;
        await Task.Delay(100);
        loaderCanvas.SetActive(false);
        OnSceneLoaded?.Invoke(sceneType);
    }
}
[Serializable]
public enum SceneType
{
    Main,
    Game
}