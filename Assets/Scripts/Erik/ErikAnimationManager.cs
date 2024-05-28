using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ErikAnimationManager : MonoBehaviour
{
    [SerializeField] private Animator[] ErikAnimations;
    [SerializeField] private Animator currentlyActiveAnimator;

    private ErikManager behaviourManager;
    private string erikState;

    private Animator erikJumpscare;
    private Camera jumpscareCam;
    private Canvas jumpscareCanvas;
    // Start is called before the first frame update
    void Start()
    {
        jumpscareCam = GameObject.Find("CanvasCamera").GetComponent<Camera>();
        erikJumpscare = jumpscareCam.GetComponentInChildren<Animator>();
        jumpscareCanvas = GameObject.Find("JumpscareCanvas").GetComponent<Canvas>();

        jumpscareCam.gameObject.SetActive(false);
        jumpscareCanvas.gameObject.SetActive(false);


        behaviourManager = FindObjectOfType<ErikManager>();
        ErikAnimations = behaviourManager.ErikObj.GetComponentsInChildren<Animator>();
        foreach (Animator animation in ErikAnimations)
        {
            animation.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        erikState = behaviourManager.ErikCurrentState;
        foreach (Animator animation in ErikAnimations)
        {
            if (animation.gameObject.name == erikState && currentlyActiveAnimator != animation && !animation.gameObject.activeSelf)
            {
                animation.gameObject.SetActive(true);
                animation.Play(0);
                currentlyActiveAnimator = animation;
                currentlyActiveAnimator.speed = 1.0f;
            }
            else if (animation.gameObject.name != erikState && animation.gameObject.activeSelf && erikState != "Idle" && erikState != "Lurk")
            {
                animation.gameObject.SetActive(false);
            }
            if (erikState == "Lurk")
            {
                currentlyActiveAnimator.speed = 0.5f;
            }
            if (erikState == "Idle")
            {
                currentlyActiveAnimator.speed = 0.0f;
            }
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            PlayJumpscare();
        }
        
    }

    public void PlayJumpscare()
    {
        jumpscareCam.gameObject.SetActive(true);
        jumpscareCanvas.gameObject.SetActive(true);
        erikJumpscare.Play(0);
    }
}
