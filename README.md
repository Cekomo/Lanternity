# Lanternity
Try to escape from spirit vale by using soul lantern

# Bugs to be fixed
- If the lamb is in use, it's position changes instantly after jumping (minor-animation).
- Create a new class that controls lantern actions wrt conditions
- When the code is adjusted during run, getter methods inside PlayerProperties script throw exception
- There can be problem on capture spirits with beam, latern captures other spirit too when one of it is catched.

# Parts to be refactored
- PlayerHand and PlayerMouse controllers can be merged
- PlayerMovement enum class is disabled due to no related implementation
- Lantern use does not get triggered after letting up moving instantly (x-axis)
- CONSIDER IMPLEMENTING NEW INPUT SYSTEM
- Convert all input functions inside a singleton class and use that class wherever neccessary
- LanternBeam state now affects some part of the code like disabling movement. You may want to gather the
states that blocks those actions later instead of declaring that state inside conditional statements.
- Consider creating parent class to store spirits and so on to use them classes like scanner/catcher