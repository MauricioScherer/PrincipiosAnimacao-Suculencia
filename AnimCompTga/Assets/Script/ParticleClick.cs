using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleClick : MonoBehaviour
{
    public void deactive()
    {
        gameObject.SetActive(true);
        Invoke("ActiveFalse", 1.0f);
    }

    private void ActiveFalse()
    {
        gameObject.SetActive(false);
    }
}
