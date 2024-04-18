using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public string scene;

    public void LoadSceneOnClick()
    {
        SceneManager.LoadScene(scene);
    }
}