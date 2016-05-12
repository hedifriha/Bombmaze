using UnityEngine;
using System.Collections;
[ExecuteInEditMode]
public class Snap : MonoBehaviour
{

    public Vector3 _snap = new Vector3(1.0f, 1.0f, 1.0f);
    public Vector3 _offset;

    public void SnapPosition()
    {
        if (_snap.x == 0 || _snap.y == 0 || _snap.z == 0)
        {
            return;
        }
        Vector3 pos = transform.position;
        pos.x = Mathf.Round((pos.x - _offset.x) / _snap.x) * _snap.x + _offset.x;
        pos.y = Mathf.Round((pos.y - _offset.y) / _snap.y) * _snap.y + _offset.y;
        pos.z = Mathf.Round((pos.z - _offset.z) / _snap.z) * _snap.z + _offset.z;
        transform.position = pos;
    }
}