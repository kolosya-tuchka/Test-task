using UnityEngine;

public class Gem : MonoBehaviour
{
    public int Cost { get; private set; }

    public IPool<Gem> GemPool;

    public void Initialize(int cost, Material material)
    {
        Cost = cost;
        GetComponent<Renderer>().material = material;
    }

    public void OnActvate()
    {
        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<Collider>().enabled = true;
    }

    public void OnPicked()
    {
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<Collider>().enabled = false;
    }

    public void OnUnloaded()
    {
        GemPool.DeactivatePoolObject(this);
    }
}
