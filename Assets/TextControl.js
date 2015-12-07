var isQuitButton = false;

function OnMouseUp()
{
    if (isQuitButton) 
    {
        //quit the game
        Application.Quit();
    }
    else
    {
        //load level
        Application.LoadLevel(1);
    }
}