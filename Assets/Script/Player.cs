using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D charRigid;//본인 rigid
    public GameObject turretPrefab01;//포탑
    public GameObject turretPrefab02;//포탑
    public GameObject turretPrefab03;//포탑
    public GameObject turretPrefab04;//포탑
    public GameObject barricatePrefab01;//방어물
    public GameObject barricatePrefab02;//방어물
    public GameObject barricatePrefab03;//방어물
    public GameObject barricatePrefab04;//방어물
    public Animator animator;
    public float charSpeed = 5f;
    public float charAP = 4f;
    public float charHP = 20f;
    public float charFixP = 2f;
    private float coolTime01 = 0f;
    private float coolTime02 = 0f;
    private Vector3 pos;

    void Update()
    {
        Move();
        buildTurret();
        buildBarricade();
        Attack();
    }

    void Move()
    {
        float input = Input.GetAxisRaw("Horizontal");
        Vector3 vel = new Vector3(0, charRigid.velocity.y, 0);

        if (input != 0)//입력 있을 때
        {
            //Run -> true
            GetComponent<Animator>().SetBool("Run", true);

            //rotate
            Vector3 rotate = new Vector3();
            const int scaleX = 2;
            rotate = transform.localScale;
            rotate.x = input * scaleX;
            transform.localScale = rotate;

            //adjust vel
            vel += new Vector3(input * charSpeed, charRigid.velocity.y);
        }
        else
        {
            GetComponent<Animator>().SetBool("Run",false);
        }
        //add vel
        charRigid.velocity = vel;

    }
    void buildTurret()
    {
        coolTime01 += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if(coolTime01 > 1f) {
                coolTime01 = 0f;
                pos = transform.position;
                pos = new Vector3(transform.position.x, -2.6f, transform.position.z);
                GameObject turret = Instantiate(turretPrefab01, pos, transform.rotation);
            }
        }
        if (Input.GetKeyDown(KeyCode.W)) {
            if (coolTime01 > 1f) {
                coolTime01 = 0f;
                pos = new Vector3(transform.position.x, -2.6f, transform.position.z);
                GameObject turret = Instantiate(turretPrefab02, pos, transform.rotation);
            }
        }
        if (Input.GetKeyDown(KeyCode.E)) {
            if (coolTime01 > 1f) {
                coolTime01 = 0f;
                pos = new Vector3(transform.position.x, -2.6f, transform.position.z);
                GameObject turret = Instantiate(turretPrefab03, pos, transform.rotation);
            }
        }
        if (Input.GetKeyDown(KeyCode.R)) {
            if (coolTime01 > 1f) {
                coolTime01 = 0f;
                pos = new Vector3(transform.position.x, -2.6f, transform.position.z);
                GameObject turret = Instantiate(turretPrefab04, pos, transform.rotation);
            }
        }
    }
    void buildBarricade () {
        coolTime02 += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.A)) {
            if (coolTime02 > 1f) {
                coolTime02 = 0f;
                pos = new Vector3(transform.position.x, -3.54f, transform.position.z);
                GameObject barricade = Instantiate(barricatePrefab01, pos, transform.rotation);
            }
        }
        if (Input.GetKeyDown(KeyCode.S)) {
            if (coolTime02 > 1f) {
                coolTime02 = 0f;
                pos = new Vector3(transform.position.x, -3.54f, transform.position.z);
                GameObject barricade = Instantiate(barricatePrefab02, pos, transform.rotation);
            }
        }
        if (Input.GetKeyDown(KeyCode.D)) {
            if (coolTime02 > 1f) {
                coolTime02 = 0f;
                pos = new Vector3(transform.position.x, -3.72f, transform.position.z);
                GameObject barricade = Instantiate(barricatePrefab03, pos, transform.rotation);
            }
        }
        if (Input.GetKeyDown(KeyCode.F)) {
            if (coolTime02 > 1f) {
                coolTime02 = 0f;
                pos = new Vector3(transform.position.x, -3.72f, transform.position.z);
                GameObject barricade = Instantiate(barricatePrefab04, pos, transform.rotation);
            }
        }
    }
    void Attack () {
        if (Input.GetKeyDown(KeyCode.Z)) {
            GetComponent<Animator>().SetBool("Attack",true);
        }
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f) {
            Debug.Log("Current State Name 애니메이션 종료.");
            GetComponent<Animator>().SetBool("Attack", false);
        }
        //시간이 지나면
        
    }
    void Throw () {

    }
}
