var levelToLoad : String;
var anim : Animation;
var sound : AudioClip;
var soundhover : AudioClip;
var QuitButton : boolean = false;
function OnMouseEnter(){
	audio.PlayOneShot(soundhover); 
}

function OnMouseUp(){
	yield new WaitForSeconds(0.35);
	if(QuitButton){
		Application.Quit();
	}
	else{
		if(anim)
			anim.CrossFade("Take 001");
		audio.PlayOneShot(sound);
		
		
		yield new WaitForSeconds(1.0);
		Application.LoadLevel(levelToLoad);
	}
}
@script RequireComponent(AudioSource)