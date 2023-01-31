using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectController : MonoBehaviour
{
    [SerializeField] float effectTime;
    void Start()
    {
        Destroy(gameObject, effectTime);
    }
}
