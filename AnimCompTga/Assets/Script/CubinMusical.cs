using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubinMusical : MonoBehaviour
{
    public enum Variacao{
        VOCAL,
        DRUMS,
        BASS,
        OTHER
    }
    public Variacao type;

    public enum Movimento
    {
        ESCALA,
        POSICAO,
        ROTACAO
    }
    public Movimento typeMove;

    public int _band;
    public float _startScale, _scaleMultiplier;

    void Update()
    {
        if(type == Variacao.VOCAL)
        {
            if(typeMove == Movimento.ESCALA)
                transform.localScale = new Vector3(transform.localScale.x, (AudioPeer_Vocal._freqBand[_band] * _scaleMultiplier) + _startScale, transform.localScale.z);
        }
        else if(type == Variacao.DRUMS)
        {
            if (typeMove == Movimento.ESCALA)
                transform.localScale = new Vector3(transform.localScale.x, (AudioPeer_Drums._freqBand[_band] * _scaleMultiplier) + _startScale, transform.localScale.z);
            else if(typeMove == Movimento.POSICAO)
                transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, -(AudioPeer_Drums._freqBand[_band] * _scaleMultiplier) + _startScale);
        }
        else if (type == Variacao.BASS)
        {
            if (typeMove == Movimento.ESCALA)
                transform.localScale = new Vector3(transform.localScale.x, (AudioPeer_Bass._freqBand[_band] * _scaleMultiplier) + _startScale, transform.localScale.z);
        }
        else if (type == Variacao.OTHER)
        {
            if (typeMove == Movimento.ESCALA)
                transform.localScale = new Vector3(transform.localScale.x, (AudioPeer_Other._freqBand[_band] * _scaleMultiplier) + _startScale, transform.localScale.z);
        }
    }
}
