using System.Runtime.CompilerServices;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    private bool isOpen = false;

    private Animation doorAnim;

    void Start()
    {
        doorAnim = transform.parent.GetComponent<Animation>();

        //getting the animation for the door from the heirarchy above
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && !isOpen)
        {
            CancelInvoke("CloseDoor");
            //needed to add this as a saftey catch becuase of what i did in the bottom
            //cause it was annoying me

            if (!isOpen)
            {
                isOpen = true;
                doorAnim.Play("Open");

                //checking if player touches the collider, if so set bool to true then open door
            }
        }

     
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && isOpen)
        {

            Invoke("CloseDoor", 1.0f);

            //waits 2 secs before closing the door
            //i wanted to do this becuase it kept closing to fast and annyoed me so i googled it.
            //waits to seconds then closes the door.

            //does the opposite when you pass again to close the door
        }
    }

    private void CloseDoor()
        {
            isOpen = false;
            doorAnim.Play("Close");

            //this is the new one that closes the door and changes the bool.
        }


    }

