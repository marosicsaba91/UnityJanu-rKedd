using UnityEngine;
using UnityEngine.SceneManagement;

class GameManager : MonoBehaviour
{
    [SerializeField] string sneneName;

    public void RestartGame() 
    {
        SceneManager.LoadScene(sneneName);
    }

}
