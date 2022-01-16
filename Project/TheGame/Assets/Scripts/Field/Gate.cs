using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : FieldObjectBase
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var pos = this.transform.position;
        pos.z -= 0.2f;
        this.transform.position = pos;
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.TryGetComponent<Plane>(out var bullet))
        {

        }
    }
}
