using UnityEngine;

public class Gem : MonoBehaviour, IPortable<Gem>
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

    public void OnPicked(Transform pickPoint)
    {
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<Collider>().enabled = false;
        
        transform.position = pickPoint.position;
        transform.parent = pickPoint;
    }

    public void OnUnloaded()
    {
        GemPool.DeactivatePoolObject(this);
    }
}
