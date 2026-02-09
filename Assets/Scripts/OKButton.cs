using UnityEngine;
using UnityEngine.UI;

public class OKButton : MonoBehaviour
{
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(() =>
        {
            AudioManager.Instance.Play("ok");
        });
    }
}
