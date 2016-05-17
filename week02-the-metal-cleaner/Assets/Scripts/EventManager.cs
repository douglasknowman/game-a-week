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
    PapersTaked, PaperOnGround, LevelUp, ScoreUp, LifesUp, PapersUp,GameOver
}

public enum SfxEventType 
{ 
    Jump, Shoot, PaperTake, SpearTake, PaperGround, SpearColl, JumpEnd
}
delegate void GameEvent(GameEventType type,int val);
delegate void SfxEvent(SfxEventType type);

static class EventManager
{
    public static GameEvent gameEvent;
    public static SfxEvent sfxEvent;

    public static void  ClearAll()
    {
        gameEvent = null;
        sfxEvent = null;
    }

}
