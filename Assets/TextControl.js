var isQuitButton = false;
var isStarterScreen = false;

function OnMouseUp()
{
    if (isQuitButton) 
    {
        //quit the game
        Application.Quit();
    }
    else if (isStarterScreen)
    {
        //load level
        Application.LoadLevel(1);
    }
    else
    {
        //load level
        Application.LoadLevel(2);
}
}