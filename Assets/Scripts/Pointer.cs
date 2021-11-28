using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pointer : MonoBehaviour
{
    [SerializeField] Camera _camera;
    [SerializeField] Transform _hook;

    [SerializeField] BodyPart _selectedBodyPart;
    [SerializeField] SpringJoint2D _springJoint2D;
    [SerializeField] Text _selectedBodyPartText;
    
    void Update()
    {
        Vector3 cursorWorldPosition = _camera.ScreenToWorldPoint(Input.mousePosition);
        cursorWorldPosition.z = 0f;
        _hook.position = cursorWorldPosition;

        RaycastHit2D hit = Physics2D.Raycast(cursorWorldPosition, Vector2.zero);

        if(hit)
        {
            if(hit.collider.GetComponent<BodyPart>())
            {
                _selectedBodyPart = hit.collider.GetComponent<BodyPart>();
                 
                if(Input.GetMouseButtonDown(0))
                {
                    if(_springJoint2D)
                    {
                        Destroy(_springJoint2D);
                    }
                    _springJoint2D = _hook.gameObject.AddComponent<SpringJoint2D>();
                    _springJoint2D.connectedBody = _selectedBodyPart.GetComponent<Rigidbody2D>();
                    _springJoint2D.autoConfigureDistance = false;
                    _springJoint2D.distance = 0f;
                    _springJoint2D.frequency = 5f;
                    _springJoint2D.dampingRatio = 1f;

                    _selectedBodyPartText.text = _selectedBodyPart.name.ToString();
                }
            }
        }
        if(Input.GetMouseButtonUp(0))
        {
            if (_springJoint2D)
            {
                Destroy(_springJoint2D);
                _selectedBodyPartText.text = null;
            }
        }
    }
}
