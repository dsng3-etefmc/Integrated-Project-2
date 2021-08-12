using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruir_camera : MonoBehaviour
{
    public void autoDestruir()
    {
        gameObject.SetActive(false); //destoi a camera
    }
}
