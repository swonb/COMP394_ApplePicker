using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour
{
    // UI related

    

    public GameObject basketPrefab;
    public int numBaskets = 3;
    public float basketMinY = -14f;
    public float basketSpacingY = 2f;

    // New on Oct.06
    public List<GameObject> basketList;

    // New on Oct.09
    public int secondsToWaitBeforeRestart = 3;

    // Start is called before the first frame update
    void Start()
    {
        // New on Oct.06
        basketList = new List<GameObject>();

        for (int i = 0; i < numBaskets; i++)
        {
            GameObject basketGo = Instantiate(basketPrefab) as GameObject;
            Vector3 pos = Vector3.zero;
            pos.y = basketMinY + i * basketSpacingY;
            basketGo.transform.position = pos;

            // New on Oct.06
            basketList.Add(basketGo);
        }
    }

    // New on Oct.06
    public void AppleDestroyed()
    {
        // Destroy remaining apples in the scene
        GameObject[] apples = GameObject.FindGameObjectsWithTag("Apple");
        foreach(GameObject go in apples)
        {
            Destroy(go);
        }

        // Destroy 1 basket
        // If no more baskets, you LOST
        int basketToGoIndex = basketList.Count - 1;
        GameObject basketToGo = basketList[basketToGoIndex];
        basketList.RemoveAt(basketToGoIndex);     // Remove from list
        Destroy(basketToGo);

        // New Oct.09
        // Lose condition
        if (basketList.Count == 0)
        {
            StartCoroutine("Lost");
        }
    }

    IEnumerator Lost()
    {
        yield return new WaitForSeconds(secondsToWaitBeforeRestart);

        //if (basketList.Count == 0)
        //{
            SceneManager.LoadScene("Scene0");
        //}
    }

    // Update is called once per frame
    void Update()
    {
        //IEnumerator en = (IEnumerator)(new List<int> { 1, 2, 3, 4 });
        //while (en.MoveNext)
        //{
        //    // do sth with en.current
        //}

        //// Solution of waiting 3 seconds before Coroutines
        //float time2wait = 3f;
        //float elapsedTime = 0f;
        //while (elapsedTime < time2wait)
        //{
        //    elapsedTime += Time.deltaTime;
        //}
        //// Do the thing
    }
}
