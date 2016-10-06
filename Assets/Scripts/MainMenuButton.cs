using UnityEngine;
using System.Collections;

public class MainMenuButton : PhysicalButton {

    public float raisedHeight = 5f;

    private float initialHeight;

    void Start() {
        base.Start();
        initialHeight = transform.position.y;
    }

    protected override void HandleHover ()
    {
        if(transform.position.y < raisedHeight) {
            transform.Translate(Vector3.up*Time.deltaTime*15f);
        } else {
            transform.position = new Vector3(transform.position.x,raisedHeight, transform.position.z);
        }
        base.HandleHover ();
    }

    protected override void HandleNormal ()
    {
        if(transform.position.y > initialHeight) {
            transform.Translate(-Vector3.up*Time.deltaTime*15f);
        } else {
            transform.position = new Vector3(transform.position.x,initialHeight, transform.position.z);
        }
        base.HandleNormal ();
    }

    protected override void HandlePressed ()
    {
        base.HandlePressed ();
        StopCoroutine(ButtonPressed());
        StartCoroutine(ButtonPressed());
    }

    private IEnumerator ButtonPressed() {
        float timer = 0f;
        Vector3 startingScale = transform.localScale;
        transform.localScale *= 1.5f;

        while (timer < 1f) {
            timer += Time.deltaTime;
            transform.localScale = Vector3.Lerp(transform.localScale, startingScale, timer);
            yield return new WaitForEndOfFrame();
        }
    }
}