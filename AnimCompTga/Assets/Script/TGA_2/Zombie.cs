using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    private bool anim = true;
    private bool isDeath = false;

    public int _band;
    public float _range;
    public float walkDistance;
    public float timeResetAnim;
    public Animator zombieAnim;
    public int points;

    private void Start()
    {
        _band = Random.Range(0, 2);
        _range = Random.Range(0, 11);
    }

    // Update is called once per frame
    void Update()
    {
        //print(AudioPeer_Drums._freqBand[_band] * 10);
        if(!isDeath)
        {
            if ((AudioPeer_Drums._freqBand[_band] * 10) >= _range)
            {
                if (anim)
                    SetWalk();
            }
        }
    }

    private void SetWalk()
    {
        zombieAnim.SetBool("Walk", !zombieAnim.GetBool("Walk"));
        anim = false;
        Invoke("ResetAnim", timeResetAnim);        
    }

    private void ResetAnim()
    {
        anim = true;
    }

    public void MoveCharacter()
    {
        transform.localPosition = new Vector3(transform.localPosition.x, 0, transform.localPosition.z + walkDistance);
    }

    public void Death()
    {
        if(!isDeath)
        {
            isDeath = true;
            zombieAnim.SetTrigger("Death");
            GetComponent<CapsuleCollider>().enabled = false;
            ManagerLevel2.points += points;
            Destroy(gameObject, 10.0f);
        }
    }
}
