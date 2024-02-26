using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BetterController : MonoBehaviour //For third class/day
{
    Rigidbody2D _rb;
    Transform _transform;

    public GameObject enemyBossPrefab;

    public TextMeshProUGUI text;

    [SerializeField]
    [Range(0f, 50f)]
    float _maxSpeed = 15f;

    [SerializeField]
    [Range(0f, 500f)]
    float _acceleration = 200f;

    [SerializeField]
    [Range(0f, 1f)]
    float _deaccelerationFactor = 0.1f;

    [SerializeField]
    [Range(0f, 1f)]
    float _boostTime = 0.1f;
    float _boostLeft = 0f;

    [SerializeField]
    [Range(1f, 5f)]
    float _boostMultiplier = 2f;

    [SerializeField]
    [Range(0f, 10f)]
    float _boostCooldown = 2f;
    float _cooldownLeft = 0;

    private int points = 0;




    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello world");
        _transform = gameObject.transform;
        _rb = _transform.GetComponent<Rigidbody2D>();
        text.text = points.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        _cooldownLeft -= Time.deltaTime;
        _boostLeft -= Time.deltaTime;
        if (Input.GetKey(KeyCode.Space) && _cooldownLeft <= 0) 
        {
            _cooldownLeft = _boostCooldown;
            _boostLeft = _boostTime;
        }


        Vector2 dir = new Vector2(0, 0);

        if (Input.GetKey(KeyCode.W)) { dir += Vector2.up; }
        if (Input.GetKey(KeyCode.A)) { dir += Vector2.left; }
        if (Input.GetKey(KeyCode.S)) { dir += Vector2.down; }
        if (Input.GetKey(KeyCode.D)) { dir += Vector2.right; }

        var maxSpeed = _maxSpeed *
            (_boostLeft > 0 ? _boostMultiplier : 1);

        if (dir == Vector2.zero)
        {
            if(_rb.velocity.sqrMagnitude > Mathf.Epsilon)
            {
                var multiplier = Mathf.Pow(_deaccelerationFactor, Time.deltaTime);
                _rb.velocity *= multiplier;
            }
        }
        else
        {
            Vector2 vel = _rb.velocity;
            vel += dir.normalized * _acceleration * Time.deltaTime;

            if (vel.sqrMagnitude > Mathf.Pow(maxSpeed, 2))
            {
                vel = vel.normalized * maxSpeed;
            }

            _rb.velocity = vel;
        }
    }

    public void AddPoints(int value)
    {
        points += value;
        text.text = points.ToString();

        if(points % 250 == 0 && value != 0)
        {
            var enemyHealth = GameObject.Instantiate(enemyBossPrefab, new Vector3(0, 0, 0), Quaternion.identity).GetComponent<DestroyByDamage>();
            enemyHealth.hp = points / 2 + 50;
        }
    }
}
