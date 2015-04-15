
function Update () {
	transform.Rotate(0, 10*Time.deltaTime, 15*Time.deltaTime);
	
	if(Input.GetKeyDown(KeyCode.Escape))
    {
        Application.Quit();
        // or ask to quit
    }
}