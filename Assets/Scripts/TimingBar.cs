using System;
using UnityEngine;

public class TimingBar : MonoBehaviour
{
    public static event Action GoodTap;
    public static event Action MissTap;
    public static event Action PerfectTap;

    [SerializeField] float updateCycle = 10f;
    float timer;
    Vector3 position;
    int factor;

    void OnEnable()
    {
        Tile.TileTap += HandleTileTap;
    }
    void OnDisable()
    {
        Tile.TileTap -= HandleTileTap;
    }

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        position = new(0f, -1f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(timer > updateCycle)
        {
            // Update position of timing bar
            factor = UnityEngine.Random.Range(1, 5);
            transform.position = position * factor;
            timer = 0;
        }
        timer += Time.deltaTime;
    }

    void HandleTileTap(Vector3 tilePosition)
    {
        float distinct = tilePosition.y - transform.position.y;
        if(distinct > 1)
        {
            // Good tap
            GoodTap?.Invoke();
        }
        else if(distinct < -1)
        {
            // Miss tap
            MissTap?.Invoke();
        }
        else
        {
            // Perfect tap
            PerfectTap?.Invoke();
        }
    }
}
