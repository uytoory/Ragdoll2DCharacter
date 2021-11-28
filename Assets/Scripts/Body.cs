using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.IK;

public class Body : MonoBehaviour
{
    [SerializeField] BodyPart[] _bodyParts;
    [SerializeField] Animator _animator;
    [SerializeField] IKManager2D _iKManager2D;
    public void BecomeDynamic()
    {
        _animator.enabled = false;
        _iKManager2D.enabled = false;

        for (int i = 0; i < _bodyParts.Length; i++)
        {
            _bodyParts[i].BecomeDynamic();
        }
    }



}
