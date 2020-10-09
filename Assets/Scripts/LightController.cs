using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class LightController : MonoBehaviour
{
    [SerializeField] OVRInput.Controller controllerType;
    [SerializeField] Vector3 positionScale;
    [SerializeField] Vector3 positionBase;
    [SerializeField] bool autoMove;

    Light light;
    float timerPos = 0f;
    float intervalPos = 0f;
    float timerRot = 0f;
    float intervalRot = 0f;

    void Start()
    {
        light = GetComponent<Light>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            autoMove = !autoMove;
        }
        if (!autoMove)
        {
            var pos = OVRInput.GetLocalControllerPosition(controllerType);
            transform.position = Vector3.Scale(pos - positionBase, positionScale);
            transform.rotation = OVRInput.GetLocalControllerRotation(controllerType);
        }
        else
        {
            if (timerPos > intervalPos)
            {
                timerPos -= intervalPos;
                intervalPos = Random.Range(0.5f, 2f);
                var pos = new Vector3(Random.Range(-15f, 15f), Random.Range(-10f, 10f), Random.Range(-10f, 2f));
                transform.DOLocalMove(pos, intervalPos).SetEase(Ease.InOutSine);
            }
            timerPos += Time.deltaTime;

            if (timerRot > intervalRot)
            {
                timerRot -= intervalRot;
                intervalRot = Random.Range(0.5f, 2f);
                var rot = new Vector3(Random.Range(-90f, 90f), Random.Range(-90f, 90f), 0);
                transform.DOLocalRotate(rot, intervalRot).SetEase(Ease.InOutSine);
            }
            timerRot += Time.deltaTime;
        }
    }
}