using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    //este script permite cambiar de la escena Start a la escena Game mediante la funcion LoadScene. 
   
    public string scene;
    
    public void LoadSceneOnClick()
    {
        SceneManager.LoadScene(scene);
    }
}