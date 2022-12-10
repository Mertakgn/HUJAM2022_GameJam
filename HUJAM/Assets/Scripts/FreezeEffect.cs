using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeEffect : MonoBehaviour
{
    [SerializeField] private GameObject maskObject;

    //private float _tempScaleY;
    private float _interpolation = 0;
    private readonly float _secondsUntillCompleted = 2;
    private float _progress;
    [SerializeField] SpriteRenderer maskObjectSpriteRenderer;
    private float curtime, maxtime;
    bool test = false;
    float t = 0;
    float opacityRate;
    private void Start()
    {
        maxtime = 5f;
        curtime = maxtime;
    }
    private void Update()
    {
        if (curtime <= 0)
        {

            StartCoroutine(ScaleMask());
            
            //maskObjectSpriteRenderer.color = new Color(255, 255, 255, opacityRate);
            curtime = maxtime;
           
        }
        else
        {
            
            //maskObjectSpriteRenderer.color = new Color(255, 255, 255, opacityRate);
            StartCoroutine(HideSprite());
            curtime -= Time.deltaTime;
        }
    }


    private IEnumerator ChangeMask()
    {
        StartCoroutine(ScaleMask());
        yield return new WaitUntil(() => test);
       
    }

    private IEnumerator ScaleMask()
    {
        while (_progress < _secondsUntillCompleted)
        {
            maskObjectSpriteRenderer.color = new Color(maskObjectSpriteRenderer.color.r,
                 maskObjectSpriteRenderer.color.g, maskObjectSpriteRenderer.color.b, 255f);
            _progress += Time.deltaTime;
            _interpolation = _progress / _secondsUntillCompleted;

            /*maskObject.transform.localScale =
                new Vector3(maskObject.transform.localScale.x, Mathf.Lerp(0f, 27f, _interpolation),
                    maskObject.transform.localScale.z);*/

            maskObject.transform.localScale = Vector3.Lerp(maskObject.transform.localScale,
                new Vector3(maskObject.transform.localScale.x, 200f, maskObject.transform.localScale.z), _interpolation);

            yield return null;
            
        }
        _progress = 0;
        test = true;
    }

    private IEnumerator HideSprite()
    {
        var temp = maskObjectSpriteRenderer.color;

        while (maskObjectSpriteRenderer.color.a > 0f)
        {
            temp.a -= 0.001f;
            maskObjectSpriteRenderer.color = temp;
            yield return new WaitForSecondsRealtime(20f);
        }
       
    }


    

    /*private void ScaleMask()
    {
        while (_progress < _secondsUntillCompleted)
        {
            _progress += Time.deltaTime;
            _interpolation = _progress / _secondsUntillCompleted;

            /*maskObject.transform.localScale =
                new Vector3(maskObject.transform.localScale.x, Mathf.Lerp(0f, 27f, _interpolation),
                    maskObject.transform.localScale.z);#1#
            
            maskObject.transform.localScale = Vector3.Lerp(maskObject.transform.localScale,
                new Vector3(maskObject.transform.localScale.x, 27f, maskObject.transform.localScale.z), _interpolation);
            
        }
    }*/
}