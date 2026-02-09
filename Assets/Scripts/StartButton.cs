using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("MainScene");
        });
    }
}
