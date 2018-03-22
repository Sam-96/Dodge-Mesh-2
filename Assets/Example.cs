//This script allows you to switch collision detection mode at the press of the space key, and move your GameObject. It also outputs collisions that occur to the console.
//Attach this script to a GameObject and make sure it has a Rigidbody component
//If it doesn’t, click the GameObject, go to its Inspector and click the Add Component button. Then, go to Physics>Rigidbody.
//Create another GameObject and ensure it has a Collider to test collisions between them.

using UnityEngine;

public class Example : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    public float m_Speed;

    void Start()
    {
        //Fetch the Rigidbody of the GameObject (make sure this is attached in the Inspector window)
        m_Rigidbody = GetComponent<Rigidbody>();
        //Make sure the Rigidbody can't rotate or move in the z axis for this example
        m_Rigidbody.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionZ;
    }

    void Update()
    {
        //Change the GameObject's movement in the X axis
        float translationX = Input.GetAxis("Horizontal") * m_Speed;
        //Change the GameObject's movement in the Y axis
        float translationY = Input.GetAxis("Vertical") * m_Speed;

        //Move the GameObject
        transform.Translate(new Vector3(translationX, translationY, 0));

        //Press the space key to switch the collision detection mode
        if (Input.GetKeyDown(KeyCode.Space))
            SwitchCollisionDetectionMode();
    }

    //Detect when there is a collision starting
    void OnCollisionEnter(Collision collision)
    {
        //Ouput the Collision to the console
        Debug.Log("Collision : " + collision.gameObject.name);
    }

    //Detect when there is are ongoing Collisions
    void OnCollisionStay(Collision collision)
    {
        //Output the Collision to the console
        Debug.Log("Stay : " + collision.gameObject.name);
    }

    //Switch between the different Collision Detection Modes
    void SwitchCollisionDetectionMode()
    {
        switch (m_Rigidbody.collisionDetectionMode)
        {
            //If the current mode is continuous, switch it to continuous dynamic mode
            case CollisionDetectionMode.Continuous:
                m_Rigidbody.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
                break;
            //If the current mode is continuous dynamic, switch it to discrete mode
            case CollisionDetectionMode.ContinuousDynamic:
                m_Rigidbody.collisionDetectionMode = CollisionDetectionMode.Discrete;
                break;

            //If the current mode is discrete, switch it to continuous mode
            case CollisionDetectionMode.Discrete:
                m_Rigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;
                break;
        }
    }
}