using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterLevelGrowing : MonoBehaviour {

    public float max_height;


	// Use this for initialization
	void Start () {
        StartCoroutine(MoveOverSeconds(gameObject, new Vector3(0.0f, max_height, 0f), 20f));
    }
	
	// Update is called once per frame
	void Update () {
		
	}



    public IEnumerator MoveOverSpeed(GameObject objectToMove, Vector3 end, float speed)
    {
        // speed should be 1 unit per second
        while (objectToMove.transform.position != end)
        {
            objectToMove.transform.position = Vector3.MoveTowards(objectToMove.transform.position, end, speed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
    }
    public IEnumerator MoveOverSeconds(GameObject objectToMove, Vector3 end, float seconds)
    {
        float elapsedTime = 0;
        Vector3 startingPos = objectToMove.transform.position;
        while (elapsedTime < seconds)
        {
            objectToMove.transform.position = Vector3.Lerp(startingPos, end, (elapsedTime / seconds));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        objectToMove.transform.position = end;
    }
}