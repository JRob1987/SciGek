using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private Vector3 _scaleSizeZ;
    // Start is called before the first frame update
    void Start()
    {
        //_scaleSizeZ = new Vector3(1, 1, 4);
        // transform.localScale = new Vector3(1, 1, 4);
        transform.localScale = _scaleSizeZ;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
