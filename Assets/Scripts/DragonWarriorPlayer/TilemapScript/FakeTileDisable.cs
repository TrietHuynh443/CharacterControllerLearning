using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeTileDisable : MonoBehaviour
{
    // Start is called before the first frame update
    private Collider2D _collider;
    [SerializeField] private Renderer _renderer;
    [SerializeField] private GameObject player;
    private void Start() {
        _collider = GetComponent<CompositeCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D other) {

        Debug.Log("fake");
        if(other.gameObject == player)
        {
            _renderer.enabled = false;
            _collider.enabled = false;
        }
    }
    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.gameObject == player){
            _renderer.enabled = true;
            _collider.enabled = true;
        }
    }
}
