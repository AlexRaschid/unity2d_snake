using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Snake : MonoBehaviour
{
    private Vector2 _direction = Vector2.right;

    private List<Transform> _segments;
    public Transform segmentPrefab;

    public int length = 0;
    public int lengthBest;

    private void Start(){
        _segments = new List<Transform>();
        _segments.Add(this.transform);
    }

    private void Update(){
        if(Input.GetKeyDown(KeyCode.W)){
            _direction = Vector2.up;
        } else if(Input.GetKeyDown(KeyCode.S)){
            _direction = Vector2.down;
        } else if(Input.GetKeyDown(KeyCode.A)){
            _direction = Vector2.left;
        } else if(Input.GetKeyDown(KeyCode.D)){
            _direction = Vector2.right;
        }
    }


    private void FixedUpdate(){

        for(int i = _segments.Count - 1; i > 0; i--){
            _segments[i].position = _segments[i - 1].position; 
         }

        this.transform.position = new Vector3(
            Mathf.Round(this.transform.position.x) + _direction.x,
            Mathf.Round(this.transform.position.y) + _direction.y,
            0.0f
        );
    }

    private void Grow(){
        length++;
        Transform segment = Instantiate(this.segmentPrefab);
        segment.position = _segments[_segments.Count -1].position;
        
        _segments.Add(segment);
    }

    public void ResetState()
    {
        if(length > lengthBest){
            lengthBest = length;
        }
        length = 0;
        _direction = Vector2.right;
        transform.position = Vector3.zero;

        // Start at 1 to skip destroying the head
        for (int i = 1; i < _segments.Count; i++) {
            Destroy(_segments[i].gameObject);
        }

        // Clear the list but add back this as the head
        _segments.Clear();
        _segments.Add(transform);


    }

     private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Food")) {
            Grow();
        } else if (other.gameObject.CompareTag("Obstacle")) {
            ResetState();
        }
    }





}