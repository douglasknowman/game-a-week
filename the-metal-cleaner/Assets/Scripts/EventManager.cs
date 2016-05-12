/*****************************************************\
*
*  Copyright (C) 2016, Douglas Knowman 
*  douglasknowman@gmail.com
*
*  Distributed under the terms of GNU GPL v3 license.
*  Always KISS.
*
\*****************************************************/

public enum GameEventType
{
    PapersTaked, PaperOnGround, LevelUp, ScoreUp, LifesUp, PapersUp
}

delegate void GameEvent(GameEventType type,int val);

static class EventManager
{
    public static GameEvent gameEvent;

    public static void  ClearAll()
    {
        gameEvent = null;
    }

}
