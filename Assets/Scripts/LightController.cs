using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class LightController : MonoBehaviour
{
    [SerializeField] OVRInput.Controller controllerType;
    [SerializeField] bool autoMove;

    Light light;
    float timerPos = 0f;
    float intervalPos = 0f;
    float timerRot = 0f;
    float intervalRot = 0f;

    [SerializeField] Vector3 anchor1;
    [SerializeField] Vector3 anchor2;

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
            Vector3 controllerPos = OVRInput.GetLocalControllerPosition(controllerType);
            var tx = (controllerPos.x - anchor1.x) / (anchor2.x - anchor1.x);
            var ty = (controllerPos.y - anchor1.y) / (anchor2.y - anchor1.y);
            var tz = (controllerPos.z - anchor1.z) / (anchor2.z - anchor1.z);
            var posX = Mathf.LerpUnclamped(-15f, 15, tx);
            var posY = Mathf.LerpUnclamped(-8.4375f, 8.4375f, ty);
            var posZ = Mathf.LerpUnclamped(-1f, 0f, tz);
            transform.position = new Vector3(posX, posY, posZ);
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