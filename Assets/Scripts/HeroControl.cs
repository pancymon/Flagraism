using UnityEngine;
using System.Collections;

public class HeroControl : MonoBehaviour {

    public Rigidbody2D m_Lowwer;
    public Rigidbody2D m_Upper;
    public HingeJoint2D m_LowwerJoint;
    public HingeJoint2D m_UpperJoint;
    public Rigidbody2D m_Head;
    public HingeJoint2D m_HeadJoint;
    public MainMenu gameManager;

    private Vector3 lowwerPosition;
    private Vector3 upperPosition;

    private float lowwer_Mass = 0.5f;
    private float upper_Mass = 0.5f;


    // Use this for initialization
    void Start () {
        //return;

        //m_Lowwer = GameObject.Find()

        lowwerPosition = m_Lowwer.transform.position;
        lowwerPosition.y = m_Lowwer.GetComponent<SpriteRenderer>().bounds.max.y;// * m_Lowwer.transform.root.transform.localScale.y;
        upperPosition = m_Upper.transform.position;
        upperPosition.y = m_Upper.GetComponent<SpriteRenderer>().bounds.max.y;// * m_Upper.transform.root.transform.localScale.y;

        float y = m_Lowwer.GetComponent<SpriteRenderer>().bounds.max.y- m_Lowwer.GetComponent<SpriteRenderer>().bounds.min.y;
        //Debug.Log(m_Lowwer.transform.root.transform.localScale.y);
        y /= m_Lowwer.transform.root.transform.localScale.y;
        m_LowwerJoint.anchor = new Vector2(0, -0.5f * y);

        y = m_Upper.GetComponent<SpriteRenderer>().bounds.max.y - m_Upper.GetComponent<SpriteRenderer>().bounds.min.y;
        y/= m_Upper.transform.root.transform.localScale.y;

        m_UpperJoint.anchor = new Vector2(0, -0.5f * y);
        m_UpperJoint.connectedAnchor = new Vector2(0, 0.5f * y);

        y = m_Head.GetComponent<SpriteRenderer>().bounds.max.y - m_Head.GetComponent<SpriteRenderer>().bounds.min.y;
        y /= m_Head.transform.root.transform.localScale.y;

        m_HeadJoint.anchor = new Vector2(0, -0.5f * y);
        m_HeadJoint.connectedAnchor = new Vector2(0, 0.5f * y);

        lowwer_Mass = m_Lowwer.mass;
        upper_Mass = m_Upper.mass;

        //m_Lowwer.AddForceAtPosition(new Vector2(-0.1f * lowwer_Mass, 0), lowwerPosition, ForceMode2D.Impulse);
    }

    public bool m_GameOver = false;

    public void setGameOver(int isOver)
    {
        Debug.Log("game over");
        if (isOver == 1)
        {
            m_GameOver = true;
            gameManager.gameOver = true;
        }
        else
            m_GameOver = false;
    }

	// Update is called once per frame
	void Update () {

        //GetKey();
        if (Input.GetKeyDown(KeyCode.Space))
            GameStart();
    }

    void FixedUpdate()
    {
        GetKey();
        AddDifficulty();
    }

    private float angleRange = 0f;
    private float lastAdd = 0f;
    private float addInterval = 1f;

    void AddDifficulty()
    {
        if (!m_gameStarted||m_GameOver)
            return;
        if (Time.time - lastAdd > addInterval)
        {
            lastAdd = Time.time;
            angleRange++;
            JointAngleLimits2D limit = new JointAngleLimits2D();
            limit.min = -1 * angleRange;
            limit.max = angleRange;
            m_UpperJoint.limits = limit;
        }
    }

    void GetKeyDown()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            lowwerPosition = m_Lowwer.transform.position;
            lowwerPosition.y += m_Lowwer.GetComponent<SpriteRenderer>().bounds.max.y;
            m_Lowwer.AddForceAtPosition(new Vector2(-1 * lowwer_Mass, 0), lowwerPosition, ForceMode2D.Impulse);
            //Debug.Log("space");
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            lowwerPosition = m_Lowwer.transform.position;
            lowwerPosition.y += m_Lowwer.GetComponent<SpriteRenderer>().bounds.max.y;
            m_Lowwer.AddForceAtPosition(new Vector2(1 * lowwer_Mass, 0), lowwerPosition, ForceMode2D.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            //m_Upper.AddForceAtPosition(new Vector2(-1 * upper_Multiplier, 0), upperPosition, ForceMode2D.Impulse);
            //Debug.Log(m_Upper.gameObject.transform.rotation.eulerAngles);
            float z = m_Upper.gameObject.transform.rotation.eulerAngles.z % 360;
            Debug.Log(z);
            z += 90;
            float angle = z / 180 * Mathf.PI;
            float x = -1 * Mathf.Sin(angle);
            float y = Mathf.Cos(angle);
            Vector2 force = new Vector2(x, y);
            force = force.normalized * upper_Mass;
            m_Upper.AddForceAtPosition(force, upperPosition, ForceMode2D.Impulse);
            //JointMotor2D motor = new JointMotor2D();
            //rotate--;
            //motor.motorSpeed = rotate * motor_Speed;
            //motor.maxMotorTorque = float.MaxValue;
            //m_Joint.motor = motor;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            float z = m_Upper.gameObject.transform.rotation.eulerAngles.z % 360;
            Debug.Log(z);
            z -= 90;
            float angle = z / 180 * Mathf.PI;
            float x = -1 * Mathf.Sin(angle);
            float y = Mathf.Cos(angle);
            Vector2 force = new Vector2(x, y);
            force = force.normalized * upper_Mass;
            m_Upper.AddForceAtPosition(force, upperPosition, ForceMode2D.Impulse);
            //m_Upper.AddForceAtPosition(new Vector2(1 * upper_Multiplier, 0), upperPosition, ForceMode2D.Impulse);
            //JointMotor2D motor = new JointMotor2D();
            //rotate++;
            //motor.motorSpeed = rotate * motor_Speed;
            //motor.maxMotorTorque = float.MaxValue;
            //m_Joint.motor = motor;
        }
    }

    float getKeyMultiplier = 0.1f;

    void GetKey()
    {
        if (m_GameOver)
            return;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            lowwerPosition = m_Lowwer.transform.position;
            lowwerPosition.y = m_Lowwer.GetComponent<SpriteRenderer>().bounds.max.y;// * m_Lowwer.transform.root.transform.localScale.y;
            m_Lowwer.AddForceAtPosition(new Vector2(-1 * lowwer_Mass * getKeyMultiplier, 0), lowwerPosition, ForceMode2D.Impulse);
            //Debug.Log("space");
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            lowwerPosition = m_Lowwer.transform.position;
            lowwerPosition.y = m_Lowwer.GetComponent<SpriteRenderer>().bounds.max.y;// * m_Lowwer.transform.root.transform.localScale.y;
            m_Lowwer.AddForceAtPosition(new Vector2(1 * lowwer_Mass * getKeyMultiplier, 0), lowwerPosition, ForceMode2D.Impulse);
        }
        if (Input.GetKey(KeyCode.A))
        {
            //Debug.Log("a");
            //m_Upper.AddForceAtPosition(new Vector2(-1 * upper_Multiplier, 0), upperPosition, ForceMode2D.Impulse);
            //Debug.Log(m_Upper.gameObject.transform.rotation.eulerAngles);
            float z = m_Upper.gameObject.transform.rotation.eulerAngles.z % 360;
            //Debug.Log(z);
            z += 90;
            z %= 360;
            float angle = z / 180 * Mathf.PI;
            float x = -1 * Mathf.Sin(angle);
            float y = Mathf.Cos(angle);
            Vector2 force = new Vector2(x, y);
            force = force.normalized * upper_Mass * getKeyMultiplier;
            m_Upper.AddForceAtPosition(force, upperPosition, ForceMode2D.Impulse);
            //JointMotor2D motor = new JointMotor2D();
            //rotate--;
            //motor.motorSpeed = rotate * motor_Speed;
            //motor.maxMotorTorque = float.MaxValue;
            //m_Joint.motor = motor;
        }
        if (Input.GetKey(KeyCode.D))
        {
            float z = m_Upper.gameObject.transform.rotation.eulerAngles.z % 360;
            //Debug.Log(z);
            z -= 90;
            z %= 360;
            float angle = z / 180 * Mathf.PI;
            float x = -1 * Mathf.Sin(angle);
            float y = Mathf.Cos(angle);
            Vector2 force = new Vector2(x, y);
            force = force.normalized * upper_Mass * getKeyMultiplier;
            m_Upper.AddForceAtPosition(force, upperPosition, ForceMode2D.Impulse);
            //m_Upper.AddForceAtPosition(new Vector2(1 * upper_Multiplier, 0), upperPosition, ForceMode2D.Impulse);
            //JointMotor2D motor = new JointMotor2D();
            //rotate++;
            //motor.motorSpeed = rotate * motor_Speed;
            //motor.maxMotorTorque = float.MaxValue;
            //m_Joint.motor = motor;
        }
    }

    private bool m_gameStarted = false;

    public void GameStart()
    {
        if (m_gameStarted)
            return;
        lastAdd = Time.time;
        m_gameStarted = true;
        m_Lowwer.isKinematic = false;
        m_Upper.isKinematic = false;
        m_Head.isKinematic = false;
        m_Lowwer.AddForceAtPosition(new Vector2(-0.1f * lowwer_Mass, 0), lowwerPosition, ForceMode2D.Impulse);
    }

}
