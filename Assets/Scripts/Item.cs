using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(SphereCollider))]
public class Item : MonoBehaviour
{
    public enum ItemType
    {
        Wood, Stone, ThrowAxe
    }

    [SerializeField] private ItemType type;

    private void Awake()
    {
        GetComponent<SphereCollider>().isTrigger = true;
    }

    public void Initialize()
    {
        SphereCollider colliderCache = GetComponent<SphereCollider>();
        colliderCache.enabled = false;
        Transform transformCache = transform;
        Vector3 dropPosition = transform.localPosition + new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));
        transformCache.DOLocalMove(dropPosition, 0.5f);
        var defaultScale = transformCache.localScale;
        transformCache.localScale = Vector3.zero;
        transformCache.DOScale(defaultScale, 0.5f).SetEase(Ease.OutBounce).OnComplete(() =>
        {
            colliderCache.enabled = true;
        });
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }

        OwnedItemsData.Instance.Add(type);
        OwnedItemsData.Instance.Save();
        Destroy(gameObject);
    }
}
