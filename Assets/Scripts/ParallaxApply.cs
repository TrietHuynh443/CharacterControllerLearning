using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField]private GameObject mainCamera;
    [SerializeField]private float paralaxEffect;

    // [SerializeField] private Transform background;
    private Vector2 _startPos;
    private float _lengthSprite;

    // Start is called before the first frame update
    void Start()
    {
        _startPos = transform.position;
        _lengthSprite = GetComponent<SpriteRenderer>().bounds.size.x;
        // _layerOrder = 1 - (float)GetComponent<SpriteRenderer>().sortingOrder/10;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float distance = mainCamera.transform.position.x * paralaxEffect;
        transform.position = new Vector2(_startPos.x + distance, _startPos.y);
        FixedStartPos();
    }
    
    
    private void FixedStartPos()
    {
        float cameraX = mainCamera.transform.position.x;

        if(cameraX*(1-paralaxEffect) > (_startPos.x + _lengthSprite)) _startPos.x += _lengthSprite;
        else if (cameraX*(1-paralaxEffect) < (_startPos.x - _lengthSprite)) _startPos.x -= _lengthSprite;
    }
}
