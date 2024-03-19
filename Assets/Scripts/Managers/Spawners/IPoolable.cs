using System;
using UnityEngine;

public interface IPoolable
{
    public ObjectPool Parent { get; set; }
    public GameObject GameObject { get; }
    //public Action OnInActive { get; set; } 
    //public Action OnCreated { get; set; }

}