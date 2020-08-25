using UnityEngine;

public class SelfDestructor : MonoBehaviour
{
    [SerializeField] float timeToDestroy = 5f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, timeToDestroy);
    }
}
