using System.Net.Sockets;
using UnityEngine;
using UnityEngine.Timeline;

public class Health : MonoBehaviour
{
   public int health = 4;
   private Animator animator;
    public void Damage(int amount)
    {
       health -= amount;
       Debug.Log("you dealt " + amount + "damage");
       if(health <= 0)
        {
            Debug.Log("you killed murderbot");
        }
    }
}
