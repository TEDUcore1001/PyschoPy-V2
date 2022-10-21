using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHand : MonoBehaviour
{
    public AnimationCurve _curve;
    public TimeManager timeManager;

    public GameObject hand;

    public GameObject pink_square;

    public GameObject thumb;
    public GameObject thumb2;

    public GameObject index;
    public GameObject index2;
    public GameObject index3;

    public bool rotatingThumb;
    public bool rotatingIndex;

    public Rigidbody pink_rb;

    public float out3;
    public float out2;
    public float out1;

    public float moveSpeed;
    public float rotationSpeed;

    public float _current;
    public float _target;
    public float _speed;

    public const float speedConst = 1f;
    public const float minDistance = 0.001f;

    public bool moving;

    public bool parent1Changed;

    public bool mission1;
    public bool mission2;
    public bool mission3;
    public bool mission4;
    public bool mission5;
    public bool mission6;
    public bool objectReleased;

    public bool isDone1;

    public Vector3 target1;
    public Vector3 target2;

    //pozisyonlara gitmeyi objenin pozisyonuna giderek yapýcaz ama kareninki belli eksiklikte, üçgenin vb belli eksiklikte bir outline ý olucak ve onu vector3 den çýkarcaz.

    // Start is called before the first frame update
    void Start()
    {
        timeManager = GameObject.FindGameObjectWithTag("Time Manager").GetComponent<TimeManager>();

        hand = GameObject.FindGameObjectWithTag("Hand");
        thumb = GameObject.Find("Thumb");
        thumb2 = GameObject.Find("Thumb2");
        index = GameObject.Find("IndexFinger");
        index2 = GameObject.Find("Index2");
        index3 = GameObject.Find("Index3");

        pink_square = GameObject.FindGameObjectWithTag("pink_square");

        out1 = 60f;
        out2 = 340f;
        out3 = 60f;

        objectReleased = false;

        target1 = new Vector3(-1.57f, 4f, 1.4f);
        target2 = new Vector3(1.69f, 4f, -0.7f);

        isDone1 = false;

        moveSpeed = Mathf.Lerp(0, 10, 0.5f);
        rotationSpeed = Mathf.Lerp(0, 10, 0.5f);

        _speed = 0.5f;

        parent1Changed = false;

        _target = 1;
        rotatingThumb = true;
        rotatingIndex = true;

        pink_rb = pink_square.gameObject.GetComponent<Rigidbody>();

        //moving = true;

        

        mission1 = false;
        mission2 = false;
        mission3 = false;
        mission4 = false;
        mission5 = false;
        mission6 = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _current = Mathf.MoveTowards(_current, _target, _speed * Time.deltaTime);


        moveSpeed = _curve.Evaluate(_current) / 3.6f / 2f;
        rotationSpeed = _curve.Evaluate(_current) / 1.5f;

        //moveSpeed = 1f * Time.deltaTime;
        //rotationSpeed = 3f * Time.deltaTime;

        if (mission1 == false) StartCoroutine(MoveHandToTarget1());

        if (mission2 == false) StartCoroutine(RotateHand());

        if (mission2 == true && mission3 == false) StartCoroutine(RotateThumb());

        if (mission2 == true && mission4 == false) StartCoroutine(RotateIndex());

        if (mission4 == true && mission3 == true && mission5 == false) 
        {
            StartCoroutine(MoveHandToBase1());
            StartCoroutine(RotateHandToPlace1());
        }

        //Debug.Log(_current);
        //Debug.Log(_target);



        //Debug.Log(rotationSpeed);
        //Debug.Log(moveSpeed);
        //Debug.Log(_current);

        //StartCoroutine(RotateThumb());
    }

    //SQUARE OTURMA 1682 173 individual 672 3027 -676

    // HAND 360 150 285

    IEnumerator RotateHand()
    {
        //_target = Mathf.MoveTowards(0, 1, 0.5f);
        Vector3 to = new Vector3(0, 150, 285);
        var rotatingHand = true;
        if (rotatingHand)
        {
            if (Vector3.Distance(transform.localEulerAngles, to) > minDistance)
            {
                
                transform.localEulerAngles = Vector3.Slerp(transform.eulerAngles, to, rotationSpeed);
            } else
            {
                transform.localEulerAngles = to;
                rotatingHand = false;
                Debug.Log("Mission 2 Done.");
                yield return mission2 = true;
            }

        }


            //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, -0, 79), rotationSpeed);
            //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(25, 0, 0), rotationSpeed);
            //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, -52, 0), rotationSpeed);


    }

    IEnumerator RotateHandToPlace1()
    {
        //_target = Mathf.MoveTowards(0, 1, 0.5f);
        var rotatingHand = true;
        Vector3 to = new Vector3(0, 330, 285);
        if (rotatingHand)
        {
            if (Vector3.Distance(transform.localEulerAngles, to) > minDistance)
            {

                transform.localEulerAngles = Vector3.Slerp(transform.localEulerAngles, to, rotationSpeed/2);
            }
            else
            {
                transform.localEulerAngles = to;
                rotatingHand = false;
                yield return null;
            }

        }
    }


        // NORMAL thumb rotations = 30,-20,60 - thumb2 rotations = -10,-35,0 | IndexFinger rotations = 0,20,0 - index2 rotations = 200,220,-180 - index3 rotations = -145.5,140,-190

        // HOLD SQUARE thumb rotations = 25.5,-56,79 - thumb2 rotations = -52,-44,-2.5 | IndexFinger rotations = 24,2,7.5 - index2 rotations = 197,220,-181 - index3 rotations = -145.5,154,-190
        // HOLD TRIANGLE thumb rotations = 25.5,-56,79 - thumb2 rotations = -52,-44,-2.5 | IndexFinger rotations = 24,2,7.5 - index2 rotations = 197,220,-181 - index3 rotations = -145.5,154,-190
        // HOLD CIRCLE thumb rotations = 25.5,-56,79 - thumb2 rotations = -52,-44,-2.5 | IndexFinger rotations = 24,2,7.5 - index2 rotations = 197,220,-181 - index3 rotations = -145.5,154,-190
        // HOLD RECTANGLE thumb rotations = 25.5,-56,79 - thumb2 rotations = -52,-44,-2.5 | IndexFinger rotations = 24,2,7.5 - index2 rotations = 197,220,-181 - index3 rotations = -145.5,154,-190

        IEnumerator RotateThumb()
    {
            if (rotatingThumb)
            {
                //_target = Mathf.MoveTowards(0, 1, 0.5f);
                Vector3 holdSquareThumb = new Vector3(25.5f, 304, 79);
                if (Vector3.Distance(thumb.transform.localEulerAngles, holdSquareThumb) > minDistance)
                {
                    thumb.transform.localEulerAngles = Vector3.Slerp(thumb.transform.localEulerAngles, holdSquareThumb, rotationSpeed);
                }
                else
                {
                    thumb.transform.localEulerAngles = holdSquareThumb;
                    
                }

                Vector3 holdSquareThumb2 = new Vector3(308f, 316f, 0f);
                if (Vector3.Distance(thumb2.transform.localEulerAngles, holdSquareThumb2) > minDistance)
                {
                    thumb2.transform.localEulerAngles = Vector3.Slerp(thumb2.transform.localEulerAngles, holdSquareThumb2, rotationSpeed);
                }
                else
                {
                    thumb2.transform.localEulerAngles = holdSquareThumb2;
                    rotatingThumb = false;
                    Debug.Log("Mission 3 Done.");
                    yield return mission3 = true;
            }
            }

    }

    IEnumerator RotateIndex()
    {

        if (rotatingIndex)
        {
            //_target = Mathf.MoveTowards(0, 1, 0.5f);
            Vector3 holdSquareIndex = new Vector3(24f, 2f, 352.5f);
            if (Vector3.Distance(index.transform.localEulerAngles, holdSquareIndex) > minDistance)
            {
                index.transform.localEulerAngles = Vector3.Slerp(index.transform.localEulerAngles, holdSquareIndex, rotationSpeed);
            }
            else
            {
                index.transform.localEulerAngles = holdSquareIndex;
                rotatingIndex = false;
                Debug.Log("Mission 4 Done.");
                pink_square.transform.parent = hand.transform;
                pink_rb.useGravity = false;
                pink_rb.isKinematic = true;
                Debug.Log("Parent Changed");
                yield return mission4 = true;
            }

            //Vector3 holdSquareIndex2 = new Vector3(197f, 220f, 179f);
            //if (Vector3.Distance(index2.transform.localEulerAngles, holdSquareIndex2) > 0.001f)
            //{
            //    index2.transform.localEulerAngles = Vector3.Slerp(index2.transform.localEulerAngles, holdSquareIndex2, rotationSpeed * 3f);
            //}
            //else
            //{
            //    index2.transform.localEulerAngles = holdSquareIndex2;
                
            //}

            //Vector3 holdSquareIndex3 = new Vector3(145.5f, 154f, 170f);
            //if (Vector3.Distance(index3.transform.localEulerAngles, holdSquareIndex3) > 0.001f)
            //{
            //    index3.transform.localEulerAngles = Vector3.Slerp(index3.transform.localEulerAngles, holdSquareIndex3, rotationSpeed * 3f);
            //}
            //else
            //{
            //    index3.transform.localEulerAngles = holdSquareIndex3;
            //    
            //}
        }


    }

    IEnumerator MoveHandToTarget1()
    {
        var moving = true;
        if (moving)
        {
            if (Vector3.Distance(transform.position, target1) > minDistance)
            {
                //_target = Mathf.MoveTowards(0, 1, 0.5f);
                transform.position = Vector3.MoveTowards(transform.position, target1, moveSpeed);
            }
            else
            {
                transform.position = target1;
                Debug.Log("Mission 1 Done.");
                moving = false;
                yield return mission1 = true;
            }
        }
        
    }

    IEnumerator MoveHandToBase1()
    {
        var moving = true;
        if (moving)
            
        {
            if (Vector3.Distance(transform.position, target2) > minDistance)
            {
                
                // 1.69 4 -0.8
                //_target = Mathf.MoveTowards(0, 1, 0.5f);
                Debug.Log("in");

                if (!isDone1)
                {
                    
                    isDone1 = true;
                }

                transform.position = Vector3.MoveTowards(transform.position, target2, moveSpeed);
            }
            else
            {
                transform.position = target2;
                Debug.Log("Mission 5 Done.");
                moving = false;
                StartCoroutine(ReleaseObject(pink_square, pink_rb));
                yield return mission5 = true;
            }
        }

    }

    IEnumerator ReleaseObject(GameObject carryingObject, Rigidbody carryingRb)
    {
        carryingObject.transform.parent = null;
        carryingRb.useGravity = true;
        carryingRb.isKinematic = false;

        timeManager.StartTimer();

        yield return objectReleased = true;
    }


}
