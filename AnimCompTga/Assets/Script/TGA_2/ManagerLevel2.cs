using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ManagerLevel2 : MonoBehaviour
{
    AudioSource soundTiro;
    Vector3 target;
    public GameObject tiro;
    public Transform startPosition;
    public GameObject impact;

    public static int points;
    public TMP_Text txtPoints;

    public GameObject enemy;
    public float timeInstantiateEnemy;

    public Texture2D cursorTexture;
    private Vector2 cursorHotspot;

    private void Start()
    {
        cursorHotspot = new Vector2(cursorTexture.width / 2, cursorTexture.height / 2);
        Cursor.SetCursor(cursorTexture, cursorHotspot, CursorMode.Auto);
        soundTiro = GetComponent<AudioSource>();

        points = 0;
        StartNewEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        txtPoints.text = "Points: " + points;

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            target = hit.point;

            if (Input.GetMouseButtonDown(0))
            {
                GameObject _tiro = Instantiate(tiro, startPosition.position, startPosition.rotation);
                _tiro.GetComponent<Tiro>().SetTarget(target);
                soundTiro.Play();
            }
        }

        //if(Input.GetKeyDown("t"))
        //{
        //    StartNewEnemy();
        //}
    }

    void StartNewEnemy()
    {
        //int valueSort = Random.Range(0, 2);

        float sort_X = Random.Range(-6.0f, 6.0f);
        float sort_Z = Random.Range(-9.0f, 0.0f);

        Instantiate(enemy, new Vector3(sort_X, 0, sort_Z), new Quaternion(0,0,0,0));

        Invoke("StartNewEnemy", timeInstantiateEnemy);
    }
}
