using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anim2 : MonoBehaviour
{
    [SerializeField] Material[] mats;
    [SerializeField] MeshRenderer cubo;
    [SerializeField] CameraShake cameraShake;
    [SerializeField] AudioSource soundImpact;
    [SerializeField] AudioClip[] clipSfx;
    [SerializeField] AudioSource soundSfx;

    public void SetMaterial(int p_status)
    {
        cubo.material = mats[p_status];
    }

    public void Impact()
    {
        cameraShake.shakeDuration = 0.1f;
        soundImpact.Play();
    }

    public void playSfx(int p_value)
    {
        soundSfx.clip = clipSfx[p_value];
        soundSfx.Play();
    }
}
