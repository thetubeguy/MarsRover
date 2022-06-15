I have assumed that: 
	
	The rover is controlled by instructing it to move left or right by a number of degrees and move forwards by a number of units.

	The rover can utilise any navigation system provided by a planet (surface), if a CoordinateSystem class is written to support it.

	Dead reckoning is used for navigation purposes.


I have written 2 classes that conform to the ICoordinateSystem interface.

Cartesian:

This class implements the solution to the Mars Rover task.  The Class processes a sequence of navigations instructions (which are mapped to rover instructions) and returns the new rover position. 

This class can only process 2D rectangular surfaces.


Geographic:

This class deals with spherical surfaces using the geographic coordinate system.  After setting starting coordinates, the ChangePosition() method accepts a single instruction with the coordinates of the destination.

The class calculates a distance and bearing to the destination. It then instructs the rover to turn the smallest angle onto the bearing and then move forwards the correct distance. 

Simple limits have been implemented by specifying 2 coordinates to form the lower left and upper right corners of the surface.  



Further Work:

Validation of the instruction format.

Implementaion of the MoverRover() method by subscription to an event broadcast by the CreateRoverCommand() method.

Wrap - around for geographic limits.

Implementation of the Program class to read instructions from a file.

Create more tests for edge cases.
