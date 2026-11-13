# Practical 5.2: Collisions

In lecture 2, you learned about collision detection. In this practical, you are going to use some of the types of collision detection from the lecture to implement aspects of a short scene from an adventure game.

To complete the adventure game scene, the player must complete the following actions:
1.	Enter a small hut to collect some ammunition for their gun
2.	Walk along a path through the mountains until they find a raised drawbridge
3.	Shoot a target next to the drawbridge, causing it to open
4.	Continue along the path (the next scene would then load in the full game)
5.	The following video shows a play-through of the completed scene: https://youtu.be/pAQY3BeMbOs

By the end of this practical you will be able to:
- Attach colliders to a game objects and configure them to trigger mode
- Create scripts that respond to trigger collisions
- Use the Physics.Raycast function to implement ray cast collision detection

## Task 1: Explore the Adventure Game Project
You have been provided with a Unity project that contains the adventure game scene. To get started, clone and download the project.

Open the scene in Unity and walk around to explore it. You will notice that the scene is almost complete. However, the following features still need to be implemented:

- The hut door should open when the player walks up to it
- The player should be able to ‘pick up’ the ammo in the hut to enable their gun
- The player should be able to shoot the target to open the drawbridge

You will implement these features in the remainder of the practical.

## Task 2: Open the Door
To get the ammo, the player needs to enter the hut. However, the door does not open. In this task, you will fix this by creating a script that opens the door when the player walks close to it. You should use the trigger collision detection approach you were taught about in the lecture to achieve this.
The script should be added to the ‘door’ game object. You can use the following code to open the door, once the player has been detected:

```
GameObject parent = transform.parent.gameObject;       
Animation animation = parent.GetComponent<Animation>();       
animation.Play("OpenDoor");
```

## Task 3: Collect the Ammo Box
Once the player enters the hut, a spinning ammo box power-up is visible on the table. When the player comes close to this ammo box, the ammo box should disappear and the player should be given 20 shells to fire from their gun in the next stage of the game.

In this task, you should create a script on the “FPSController” game object that implements the above behavior. This script should perform the following functionality, when a collision with the ammo box is detected:
- Increment a variable that stores the current ammo level by 20
- Make the ammo box disappear using the function GameObject.SetActive(false);

## Task 4: Open the Drawbridge
Once the player has loaded their gun, they follow a path up into the hills. Soon they reach an open drawbridge. This drawbridge can be opened by shooting the red and white target. You can shoot using Input.GetButtonDown to detect when the player has pressed the mouse key. 

In this task, you should extend the script that you created in the last task to implement this behaviour. Your script should allow the player to shoot a bullet at whatever the red dot in the centre of the screen is pointing. Your script should also prevent the player from shooting more than the 20 shells that were collected in the hut.

You can use the following code snippet to get a ray that is travelling directly through the centre of the viewport, where the red dot is shown in the game. 

```
Ray ray =  Camera.main.ViewportPointToRay(new Vector3(0.5f ,0.5f ,0.0f));
```
This ray can then be used in the Physics.Raycast function to check whether the player has hit the target rather than some of other game object or the terrain.

```
RaycastHit result; 
Physics.Raycast(ray, out result);
```

Once the target has been hit, the following code can be called on the Drawbridge game object to open it. Note: the variable ‘result’ in the code snippet is a RaycastHit object returned by the Physics.Raycast function.

```
GameObject g = result.collider.gameObject;
Animation a = g.transform.parent.GetComponent<Animation>();
a.Play("LowerBridge");
```

## Optional Extensions
If you complete both practicals, try these optional tasks:

- Create a script that ‘re-spawns’ the ammo box when the player shoots all 20 of their shells, without opening the bridge.
- Modify the script created in tasks 3 and 4, so that the player dies if they fall off the bridge into the deep valley. To simulate the death of the player, you should restart the current scene (see [here](https://docs.unity3d.com/6000.0/Documentation/ScriptReference/SceneManagement.SceneManager.LoadScene.html)).
- Create a more advanced door opening script, which opens the door when the player enters the hut, keeps it open while they are inside, and closes it when they leave. To do this you may need to play the additional ‘Open’ and ‘Close’ clips that are part of the ‘OpenDoor’ animation from the OnTriggerEnter, OnTriggerStay and OnTriggerLeave functions (see [here](https://docs.unity3d.com/6000.0/Documentation/ScriptReference/Animation.Play.html)).
