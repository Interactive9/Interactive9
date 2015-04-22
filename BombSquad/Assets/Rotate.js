public var time : float;
public var count : int;
public var style : GUIStyle;


function Update () {
	transform.Rotate(0, 10*Time.deltaTime, 15*Time.deltaTime);
}

function OnGUI() {
	time -= Time.unscaledDeltaTime;
	count = 60;
    
    var minutes : int = Mathf.CeilToInt(time) / 60;
    var seconds : int = Mathf.CeilToInt(time) % 60;
  	count = count + seconds;
  	style.fontSize = 40;
  	
    if (count>0 && time > -60){
      //displaying in the 3Dtext
    	GUI.TextField (Rect (7*Screen.width/8, Screen.height/20, 100, 100), "0:"+count.ToString(),style);
	}else{
		Handheld.Vibrate();
	}
}