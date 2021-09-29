using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubinMusical : MonoBehaviour
{
    public int _band;
    public float _startScale, _scaleMultiplier;

    void Start()
    {
        
    }

    void Update()
    {
        transform.localScale = new Vector3(transform.localScale.x, (AudioPeer._freqBand[_band] * _scaleMultiplier) + _startScale, transform.localScale.z);
    }
}
