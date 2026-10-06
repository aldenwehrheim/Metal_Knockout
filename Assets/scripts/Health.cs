using System.Net.Sockets;
using Unity.Tutorials.Editor;
using UnityEngine;
using UnityEngine.Timeline;

public class Health : MonoBehaviour
{
   public int health = 4;
   bool iframes_on = false;
   private int iframes;
   private Animator animator;
    public void Update()
    {
        if (iframes_on == true)
        {
          if (iframes <= 0)
            {
              iframes_on = false;
              Debug.Log("murderbot has no more iframes");
            }
            else
            {
              iframes -= 1;
              Debug.Log("murderbot has " + iframes + " iframes left");
            }
        }
    } 
    public void Damage(int amount)
    {
       if (iframes_on == false)
       {
       health -= amount;
       iframes_on = true;
       iframes = 100;
       Debug.Log("you dealt " + amount + "damage");
       if(health <= 0)
        {
            Debug.Log("you killed murderbot");
        }
       }
    }
}
