using UnityEngine;
using UnityEngine.SceneManagement;

public class ToLvl1 : MonoBehaviour
{
    public void ToLvlOne()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Additive);
    }
}
