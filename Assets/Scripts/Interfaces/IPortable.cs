using UnityEngine;

public interface IPortable<TItem> where TItem : MonoBehaviour
{
      void OnPicked(Transform pickPoint); 
      void OnUnloaded();
      
      public int Cost { get; }
}