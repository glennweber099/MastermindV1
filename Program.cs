using MastermindV1.Classes;

/// <summary>
/// Initial setup of console app and sets the value of Mastermind answer
/// </summary>
LogicLayer logicLayer = new LogicLayer();
while (true)
{
    int TotalAttempts = 0;
    bool solved = false;
    string answer = logicLayer.SetMastermindAnswer();
    Presentation.InitialMenuSetUp();
    //Limits player to 10 total attempts
    while (TotalAttempts < 10)
    {

        if (logicLayer.AttemptValues(answer))
        {
            //If successfull, set solved to true and break out of loop
            TotalAttempts = TotalAttempts + 1;
            Presentation.UserAttemptsMessage(TotalAttempts);
            solved = true;
            break;
        }
        else
        {
            //If unsuccessfull, add attempts to count of total attempts taken so far
            TotalAttempts = TotalAttempts + 1;
            Presentation.UserAttemptsMessage(TotalAttempts);
            solved = false;
        }

    }

    if (solved)
    {
        Presentation.SuccessfulGame();
    }
    else
    {
        Presentation.UnsuccessfulGame();
    }
    break;
}