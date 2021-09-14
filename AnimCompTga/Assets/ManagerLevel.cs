using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerLevel : MonoBehaviour
{
    private bool moving;
    private Transform currentTarget;

    [SerializeField] GameObject[] particleClick;
    [SerializeField] Transform cameraMain;
    [SerializeField] float speed;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))                
            {
                for(int i = 0; i < particleClick.Length; i++)
                {
                    if(!particleClick[i].activeSelf)
                    {
                        particleClick[i].GetComponent<Transform>().position = hit.point;
                        particleClick[i].GetComponent<ParticleClick>().deactive();
                        break;
                    }
                }
            }
        }

        if(moving)
        {
            cameraMain.position = Vector3.MoveTowards(cameraMain.position, currentTarget.position, speed * Time.deltaTime); ;
        
            if(cameraMain.position == currentTarget.position)
            {
                moving = false;
            }
        }
    }

    public void MoveCamera(Transform p_target)
    {
        moving = true;
        currentTarget = p_target;
        print("teste");
    }
}
