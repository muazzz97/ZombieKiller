using UnityEngine.Audio;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public float damage = 10f;
    public float range = 1000f;
    public float bulletForce = 1000f;
    bool isFiring;  //By default It's False
    bool stopFiring;
    public ParticleSystem Muzzlefalsh;
    public GameObject Aim;
    public AudioClip gunshot;
    public GameObject bullett;
    public float speed = 100000000f;
    public GameObject bulletpoint;

    public AudioSource source;

    public Camera fpsCam;



    public void PointerDown()
    {
        AudioListener.volume = 1;
        source.Play();
        Shoot();
        stopFiring = false;
        makeFireVariableTrue();
    }


    void makeFireVariableTrue()
    {
        isFiring = true;
    }
    void makeFireVariableFalse()
    {
        isFiring = false;
        if (stopFiring == false)
        {
            Invoke("makeFireVariableTrue", 0.5f);
        }
    }
    private void Update()
    {
       Debug.DrawRay(fpsCam.transform.position, fpsCam.transform.forward*10000, Color.red);
      //  Shoot();
        
    }

    private void Start()
    {
        // source = GetComponent<AudioSource>();
     
    }

    void Shoot()
    {
        Debug.Log("Fire111!!!");
        //source.Play();
        Muzzlefalsh.Play();
        RaycastHit hit;
       

        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {

            Debug.Log(hit.collider.gameObject);
            Debug.Log("hit returns: " + hit.transform.tag);
            EnemyTarget target = hit.transform.GetComponent<EnemyTarget>();

            GameObject instebullett = Instantiate(bullett) as GameObject;
            instebullett.transform.parent = bulletpoint.transform.parent;
            instebullett.transform.localPosition = bulletpoint.transform.localPosition;
            instebullett.transform.localRotation = bulletpoint.transform.localRotation;
            Rigidbody insterigid = instebullett.GetComponent<Rigidbody>();
            insterigid.AddForce(bulletpoint.transform.forward * speed * Time.deltaTime, ForceMode.Impulse);

            //  Aim.transform.position = hit.transform.position;

            if (target != null)
                {
                    target.TakeDamage(damage);
                    Debug.Log("damag val: " + damage);
                }
            
        }
    }
}
