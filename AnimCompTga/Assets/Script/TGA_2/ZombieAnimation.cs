using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAnimation : MonoBehaviour
{
    private Zombie zombie;

    void Start()
    {
        zombie = GetComponentInParent<Zombie>();
    }

    public void Walk()
    {
        zombie.MoveCharacter();
    }
}
