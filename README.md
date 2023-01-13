# Lanternity
Try to escape from spirit vale by using soul lantern

# Bugs to be fixed
- If the lamb is in use, it's position changes instantly after jumping (minor-animation).
- Create a new class that controls lantern actions wrt conditions
- Spirit Scanner class does not work properly
- When the code is adjusted during run, getter methods inside PlayerProperties script throw exception.

# Parts to be refactored
- Split playerMovement script 
- Split MovePlayerX() function
- PlayerHand and PlayerMouse controllers can be merged
- PlayerMovement enum class is disabled due to no related implementation
- Lantern use does not get triggered after letting up moving instantly (x-axis)