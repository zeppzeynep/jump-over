using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPos;
    void Start()
    {
        startPos = transform.position;   
    }
        
    // Update is called once per frame
    void Update()
    {
        if (startPos.x < transform.position.x - 50)
        {
            transform.position = startPos;

        }
    }
}
