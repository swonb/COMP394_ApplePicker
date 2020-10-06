using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    public float killY = -20f;
    
    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < killY)
        {
            Destroy(this.gameObject);

            // New on Oct.06
            // Notify applepicker for the death
            ApplePicker applePickerScript = Camera.main.GetComponent<ApplePicker>();
            applePickerScript.AppleDestroyed();
        }
    }
}
