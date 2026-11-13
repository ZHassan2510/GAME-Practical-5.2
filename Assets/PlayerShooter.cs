using System.Reflection.PortableExecutable;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerShooter : MonoBehaviour
{

    public int ammoCount = 0;

    public GameObject ammoBox;

    public bool bridgeOpen = false;

    public float death = -15f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ammo"))
        {
            ammoCount += 20;
            //checking if player collides with ammo if so increase by 20

            other.gameObject.SetActive(false);
            //makes the ammo box dissapear
        }
    }

    private void Update()
    {
        if(transform.position.y < death)
        {
            //checking if player height is above death threshhold

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (Input.GetButtonDown("Fire1") && ammoCount > 0)
        {
            ammoCount--;
            //if you shoot ammo goes down by 1

            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

            // ray that travells directly through the center of the screen(red dot)

            RaycastHit result;
            //creates an empty folder with the result

            if (Physics.Raycast(ray, out result))
            {
                //checks whether the player has hit the target,after the laser hits a solid colider
                //this returns true then puts the data for the object(out) into result folder

                if (result.collider.CompareTag("Target"))
                {
                    //checks if the object in result is the Target using its tag

                    GameObject g = result.collider.gameObject;
                    Animation a = g.transform.parent.GetComponent<Animation>();
                    a.Play("LowerBridge");

                    //gets the target the laser hit, looks above in the heirarchy to find the animation
                    //then plays it to drop bridge.

                    bridgeOpen = true;

                }
            }
        }
        if (ammoCount == 0 && !bridgeOpen)
        {
            ammoBox.SetActive(true);

            //if ammo goes back to 0 and bridge is closed, set the ammo box back active.
        }
    }

}
