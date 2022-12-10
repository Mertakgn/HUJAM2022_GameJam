using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ConnectionScript : MonoBehaviour
{

    public bool collected;
    [SerializeField] GameObject tempCollectable;
    [SerializeField] CinemachineVirtualCamera vCam;
    [SerializeField] GameObject tempUiConnectionPoint;

    RaycastHit2D raycastHit;
    Ray ray;
    public Sprite hoverSprite, defultSprite;

    public Camera cameraGO;

    void Update()
    {
        if (collected)
        {

            Debug.Log("Aktif");
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            raycastHit = Physics2D.Raycast(ray.origin, ray.direction);
            if (raycastHit.collider != null)
            {
                Debug.Log("Inside If");

                CurrentClickedGameObject(raycastHit.collider.gameObject);

            }
            else
            {
                if (tempUiConnectionPoint != null)
                {
                    SetSpriteDefult();
                }
            }

        }



    }
    public void CurrentClickedGameObject(GameObject gameObject)
    {
        if (gameObject.CompareTag("Connection"))
        {
            Debug.Log("Inside Tag");


            tempUiConnectionPoint = gameObject.gameObject;
            tempUiConnectionPoint.GetComponent<SpriteRenderer>().sprite = hoverSprite;


            if (Input.GetMouseButtonDown(0))
            {

                //tempCollectable.transform.localEulerAngles = new Vector3(0, 0, transform.rotation.z + tempUiConnectionPoint.transform.rotation.z);
                tempCollectable.transform.parent = tempUiConnectionPoint.transform;
                tempCollectable.transform.localEulerAngles = new Vector3(0, 0, tempUiConnectionPoint.transform.rotation.z);
                tempCollectable.transform.localPosition = new Vector3(0, 0, 0);

                foreach (Transform child in tempCollectable.transform)
                {
                    child.transform.parent = transform;
                }

                tempCollectable.transform.parent = transform;
                Destroy(tempUiConnectionPoint);
                ResumeGame();
            }
        }
        else
        {
            SetSpriteDefult();
        }


    }

    void SetSpriteDefult()
    {
        tempUiConnectionPoint.GetComponent<SpriteRenderer>().sprite = defultSprite;
    }

    void ResumeGame()
    {
        GetComponent<PlayerRotation>().enabled = true;
        GetComponent<PlayerMovement>().enabled = true;
        collected = false;
        Time.timeScale = 1;

        var composer = vCam.GetCinemachineComponent<CinemachineFramingTransposer>();
        composer.m_DeadZoneWidth = 0.35f;
        composer.m_DeadZoneHeight = 0.35f;

        for (int i = 0; i < transform.childCount; i++)
        {

            if (transform.GetChild(i).CompareTag("Connection"))
            {

                transform.GetChild(i).GetComponent<SpriteRenderer>().enabled = false;
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Collectable"))
        {



            tempCollectable = collision.gameObject;

            tempCollectable.GetComponent<SpriteRenderer>().sortingOrder = 1;
            collected = true;
            GetComponent<PlayerRotation>().enabled = false;
            GetComponent<PlayerMovement>().enabled = false;
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).GetComponent<SpriteRenderer>().enabled = true;

            }
            GetComponent<SpriteRenderer>().sortingOrder = 1;
            var composer = vCam.GetCinemachineComponent<CinemachineFramingTransposer>();
            composer.m_DeadZoneWidth = 0;
            composer.m_DeadZoneHeight = 0;

            Time.timeScale = 0.1f;



        }
    }




}
