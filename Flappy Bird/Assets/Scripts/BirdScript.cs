using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BirdScript : MonoBehaviour
{
    public static BirdScript instance;

    [SerializeField]
    private Rigidbody2D myRigidBody;

    [SerializeField]
    private Animator anim;

    private float forwardSpeed=3f;
    private float bounceSpeed=4f;

    private bool didFlap;

    public bool isAlive;

    private Button flapButton;

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    public AudioClip flapClip, pointClip, diedClip;

    public int score;



    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        isAlive = true;
        score = 0;

        flapButton = GameObject.FindGameObjectWithTag(TagManager.FLAP_BUTTON_TAG).GetComponent<Button>();
        flapButton.onClick.AddListener( () => FlapTheBird() );
        // this adds the listener the same as clicking onClick, dragging and dropping a game object and selecting a function

        setCameraX();
    }


    void Start()
    {
        
    }

    



    void FixedUpdate()
    {
        if (isAlive)
        {
            Vector3 temp = transform.position;
            temp.x += forwardSpeed * Time.deltaTime;
            transform.position = temp; //reassigning our position back to our current position.. or the position of that bird

            if (didFlap)
            {
                didFlap = false;
                myRigidBody.velocity = new Vector2(0, bounceSpeed);
                anim.SetTrigger(TagManager.FLAP_PARAMETER) ;

                audioSource.PlayOneShot(flapClip);
            }


            if (myRigidBody.velocity.y >= 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);

            }
            else {

                float angle = 0;
                angle = Mathf.Lerp(0, -90, (-myRigidBody.velocity.y)/7);
                

                transform.rotation = Quaternion.Euler(0, 0, angle);
            
            }

        }




    }

    void setCameraX()
    {

        cameraScript.offsetX = (Camera.main.transform.position.x - transform.position.x) - 1f; // -1 to give a little more space
    }


    public float getPositionX()
    {

        return transform.position.x; //returns the x position of the bird.
    }

    public void FlapTheBird()
    {
        didFlap = true;
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == TagManager.PIPE_TAG|| collision.gameObject.tag==TagManager.GROUND_TAG) {

            if (isAlive)
            {
                isAlive = false;
                anim.SetTrigger(TagManager.BIRD_DIED_PARAMETER);
                audioSource.PlayOneShot(diedClip);
                gameplayController.instance.PlayerDiedShowScore(score);
            }
        
        
        
        
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == TagManager.PIPE_HOLDER_TAG) {

            audioSource.PlayOneShot(pointClip);
            score++; //bug fixed by moving this above the line that's below.. previously, it didn't count the fist jump
            gameplayController.instance.SetScore(score);
            
        
        }
    }

}
