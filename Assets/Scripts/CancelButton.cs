using UnityEngine;
using UnityEngine.UI;

public class CancelButton : MonoBehaviour
{
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(() =>
        {
            AudioManager.Instance.Play("cancel");
        });
    }
}
