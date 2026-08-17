using UnityEngine;

public class Target : MonoBehaviour
{
    protected int scoreValue = 10;
    protected float lifetime = 8f;
    public GameObject targetDestroySound;
    [SerializeField] private AK.Wwise.Event targetSpawn;

    public virtual void Start()
    {
        targetSpawn.Post(gameObject);
        Destroy(gameObject, lifetime);
    }

    public virtual void DestroyTarget()
    {
        AddScore(scoreValue);
        Instantiate(targetDestroySound, transform.localPosition, Quaternion.identity);
        Destroy(gameObject);
    }

    protected virtual void AddScore(int score)
    {
        if (GameManager.Instance != null)
            GameManager.Instance.AddScore(score);
    }
}
