using System.Net.Sockets;
using Unity.Tutorials.Editor;
using UnityEngine;
using UnityEngine.Timeline;

public class Health_player : MonoBehaviour
{
   public int health = 4;
   bool iframes_on = false;
   private int iframes;
   // both iframes are for turning iframes on and then counting the frames
    public void Update()
    {
        if (iframes_on == true)
        {
          // it checks every update if iframes is on 
          // then the timer starts, all this code does is decrease iframes and stop when it runs out
          if (iframes <= 0)
            {
              iframes_on = false;
              Debug.Log("player has no more iframes");
            }
            else
            {
              iframes -= 1;
              Debug.Log("player has " + iframes + " iframes left");
            }
        }
    } 
    public void Damage(int damage)
    {
      // this down here is the damage method, and it allows other scripts to take away health.
      // it also allows iframes that were previously made to do somthing
      // it checks if iframes are on, and if it is the damage method does not run
      // if its off it does damage = to the damage, which is the code just pulling from the attack area's collider damage variable
      // 

       if (iframes_on == false)
       {
       
       health -= damage;
       iframes_on = true;
       iframes = 300;
       Debug.Log("you took " + damage + " damage");
       if(health <= 0)
        {
            Debug.Log("you died");
        }
       }
    }
}
