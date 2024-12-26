using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropSpikes : TrapMaster
{
    [SerializeField] private GameObject spikePreFab;
    [SerializeField] private float spikeTrapTIme;
    [SerializeField] private float dropSpeed;
    public bool spikeTrapActivate = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    void Update()
    {
        if(spikeTrapActivate)
        {
            InvokeRepeating("SpikeSpawner", 0.5f, spikeTrapTIme);
        }
    }



    public override void Activate()
    {
        spikeTrapActivate = true;
    }




    void SpikeSpawner()
    {
        if (spikePreFab != null)
        {
            Rigidbody spikeRb = spikePreFab.GetComponent<Rigidbody>();
            spikeRb.AddForce(Vector3.down * dropSpeed * Time.deltaTime, ForceMode.Impulse);

        }
        //Instantiate(spikePreFab, dropPos, Quaternion.identity);
    }
}
