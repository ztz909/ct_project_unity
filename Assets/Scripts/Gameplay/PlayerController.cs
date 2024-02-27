using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private float _horizontalInput;
    private float _verticalInput;
    private float _speed = 5.0f;
    Rigidbody2D _body;
    Animator _myAnim;
    [SerializeField] int freedom;
    [SerializeField] private TransitionController _transitionController;

    private static readonly int MoveX = Animator.StringToHash("moveX");
    private static readonly int MoveY = Animator.StringToHash("moveY");

    // Start is called before the first frame update
    void Start()
    {
        _body = GetComponent<Rigidbody2D>();
        _myAnim = GetComponent<Animator>();
        _transitionController = new TransitionController();
        freedom = 0;
    }

    // Update is called once per frame
    void Update()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");
        _body.velocity = new Vector2(_horizontalInput * _speed, _verticalInput * _speed);
        _myAnim.SetFloat(MoveX, _body.velocity.x);
        _myAnim.SetFloat(MoveY, _body.velocity.y);
        if(freedom == 4)
        {
            TransitionController.fad
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("transitionBoss"))
        {
            var transform1 = transform;
            transform1.position = new Vector3(58.52f, -14.57f, transform1.position.z);
        }
    }
    public void IncreaseFreedom()
    {
        freedom++;
    }

    public int GetFreedom()
    {
        return freedom;
    }
}
