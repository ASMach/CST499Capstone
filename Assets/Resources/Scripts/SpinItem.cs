using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinItem : MonoBehaviour
{

    void Update()
    {
        transform.Rotate(Vector3.down * 10 * Time.deltaTime);
    }
}
