using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class ConnectionScript : MonoBehaviour
{
    private bool collected;

    [SerializeField] GameObject tempCollectable, tempPlayer;
    [SerializeField] GameObject popupPanel, cameraCenter;
    [SerializeField] Material hoverMaterial;
    [SerializeField] GameObject tempUiConnectionPoint;
    [CanBeNull] public static GameObject PanelPlayerCopy { get; private set; }

    void Start()
    {
    }
    
    void Update()
    {
        if (collected)
        {
            tempCollectable.transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
                Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0f);
        }

        if (popupPanel.activeInHierarchy)
        {
            Debug.Log("AKTIF");
            RaycastHit2D raycastHit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            raycastHit = Physics2D.Raycast(ray.origin, ray.direction, 100f);
            if (raycastHit.collider != null)
            {
                CurrentClickedGameObject(raycastHit.collider.gameObject);
            }
        }
    }

    public void CurrentClickedGameObject(GameObject gameObject)
    {
        if (gameObject.CompareTag("Connection"))
        {
            Debug.Log("connection");
            tempUiConnectionPoint = gameObject.gameObject;
            gameObject.GetComponent<SpriteRenderer>().material = hoverMaterial;
        }
        else
        {
            if (tempUiConnectionPoint != null)
                tempUiConnectionPoint.GetComponent<SpriteRenderer>().material = null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Collectable"))
        {
            Time.timeScale = 0;


            tempCollectable = collision.gameObject;

            tempCollectable.GetComponent<SpriteRenderer>().sortingOrder = 1;
            collected = true;
            GetComponent<PlayerRotation>().enabled = false;
            
            if (PanelPlayerCopy == null)
            {
                tempPlayer = Instantiate(this.gameObject,
                    new Vector3(cameraCenter.transform.position.x, cameraCenter.transform.position.y, 1f),
                    Quaternion.identity) as GameObject;
                PanelPlayerCopy = tempPlayer;
                
                for (int i = 0; i < tempPlayer.transform.childCount; i++)
                {
                    tempPlayer.transform.GetChild(i).GetComponent<SpriteRenderer>().enabled = true;
                }

                tempPlayer.GetComponent<SpriteRenderer>().sortingOrder = 1;
                popupPanel.SetActive(true);
            }

            
        }
    }
}