using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MG_EntityA : MonoBehaviour
{
    [SerializeField] private BibleEntity _entityA;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var ObjEntity = collision.gameObject.GetComponent<MG_EntityB>();
        if (_entityA == ObjEntity._entityB)
        {
            Debug.Log("Matched");
        }
        //drag and drop
        //if GameObj collides with another animal while letting go of left click
        //check enums if both IDs are match, if so then add point
    }
}
