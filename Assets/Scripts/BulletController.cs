using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float _bulletLifetime = 5f;
    public float _bulletDamage = 1;

    [SerializeField] private GameObject stickyBullet;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, _bulletLifetime);
    }

    private void OnCollisionEnter(Collision collision){
        if(collision.gameObject.name == "Enemy"){ 
                //deal damage to enemy
            //collision.gameObject.GetComponent<EnemyStats>().TakeDamage(_bulletDamage);
            StickyBullet(collision);
        }if(collision.gameObject.name == "Target"){ 
                //deal damage to enemy
            collision.gameObject.GetComponent<AudioSource>().Play();
            StickyBullet(collision);
        }
        Destroy(gameObject);
    }

    private void StickyBullet(Collision collision){
                    //spawn bullet
                GameObject sb = Instantiate(stickyBullet) as GameObject; 
                    //set position to collision point
                ContactPoint contact = collision.contacts[0];
                sb.transform.position = contact.point;
                    //set as child to the target
                sb.transform.parent = collision.gameObject.transform;
    }

}
