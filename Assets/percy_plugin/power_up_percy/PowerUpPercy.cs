using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpPercy : MonoBehaviour
{
    public int port = 5;
    private PercyPlugin _percy;
    // Start is called before the first frame update
    void Start()
    {
        _percy = new PercyPlugin(port);
    }

    // Update is called once per frame
    void Update()
    {
        if (!_percy.NotNull)
            return;

        transform.Rotate(new Vector3(0, Time.deltaTime * 14.3f, 0));


        var position = transform.position;
        position.y = _percy.mmGetDistance() / 100;
        transform.position = position;

    }
}
