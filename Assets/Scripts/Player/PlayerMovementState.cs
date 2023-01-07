namespace Player 
{
    public enum PlayerMovementState
    {
        Idle,
        RunningLeft,
        RunningRight,
        WalkingLeft, // kind of running using lantern with less speed
        WalkingRight,
        TakingOff,
        Jumping,
        Falling,
        Landing,
    }
}
