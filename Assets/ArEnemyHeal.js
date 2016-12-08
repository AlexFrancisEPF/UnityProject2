#pragma strict

var Health = 100;
var EnemyName : String;
var meurt : AudioClip;

function OnCollisionEnter(col : Collision){
    if(col.gameObject.tag == "Fleche"){
        Health -= 30;
    }
    if(Health <= 0)
    {
        MeurtSound(); 
        GameObject.Find(EnemyName).GetComponent(ArAdvancedAI).enabled = false;
        GetComponent.<Animation>().Play("die");
        GetComponent.<Animation>()["die"].speed = 1;
        GameObject.Find(EnemyName).GetComponent(CapsuleCollider).enabled = false;
        yield WaitForSeconds (30);
        Dead();
    }

}

    function MeurtSound(){
        GetComponent.<AudioSource>().clip = meurt;
        GetComponent.<AudioSource>().Play();
    }


    function Dead()
    {
        Destroy (gameObject);
    }