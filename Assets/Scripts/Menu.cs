using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private ItemsDialog itemsDialog;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private Button pauseButton, resumeButton, itemsButton;

    void Start()
    {
        pausePanel.SetActive(false);
        pauseButton.onClick.AddListener(Pause);
        resumeButton.onClick.AddListener(Resume);
        itemsButton.onClick.AddListener(ToggleItemsDialog);
    }

    private void Pause()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }

    private void Resume()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }

    private void ToggleItemsDialog()
    {
        itemsDialog.Toggle();
    }
}
