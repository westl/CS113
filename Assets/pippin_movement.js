#pragma strict

var speed = 0.1f;
private var body : Rigidbody2D; // the characters actual body
private var isGrounded; 
var head : Transform; //colliders
var feet : Transform; //colliders
var ground_layers : LayerMask;
var grounded_Radius = .2f;
 function Awake ()
 {
            // Setting up references.
            head = transform.Find("GroundCheck");
            feet = transform.Find("CeilingCheck");
          	body = Instantiate(GetComponent("Rigidbody2D"));
 }

function FixedUpdate () //Gets called before update
{
    isGrounded = false; //grounded is false to begin with
    
	//returns a collection of 2d colliders : Colliders2D [] 
    var colliders = Physics2D.OverlapCircleAll(feet.position, grounded_Radius, ground_layers);
    for (var i = 0; i < colliders.Length; i++)
    {
        if (colliders[i].gameObject != gameObject)
        {
            isGrounded = true;
            print("I'm grounded");
        }
    }
    
}

// Update is called once per frame
function Update () {

	if(Input.GetKey(KeyCode.A)){
		transform.Translate(Vector2.left * speed);
	}
	else if(Input.GetKey(KeyCode.W) && isGrounded){
		
		body.AddForce(new Vector2(0f, 400f));
	}
	else if(Input.GetKey(KeyCode.D)){
		transform.Translate(Vector2.right * speed);
	}


}

