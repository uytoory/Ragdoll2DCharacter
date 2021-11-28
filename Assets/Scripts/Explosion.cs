using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] GameObject _effect;
    [SerializeField] GameObject _forceObject;
    [SerializeField] Body _body;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            Explode();
        }
    }

    void Explode()
    {
        _effect.SetActive(true);
        _forceObject.SetActive(true);
        Invoke(nameof(HideForceObject), 0.3f);
        _body.BecomeDynamic();
    }

    void HideForceObject()
    {
        _forceObject.SetActive(false);
    }

}
