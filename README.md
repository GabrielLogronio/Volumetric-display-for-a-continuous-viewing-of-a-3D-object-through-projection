# Volumetric-display-for-a-continuous-viewing-of-a-3D-object-through-projection
Thesis for the Master Degree in Computer Science at Università degli Studi di Milano. 
Development of a volumetric display that allows the user to freely wlk around the device to view all the different sides of the virtual object with a continue and smooth transition.
A screen, like a monitor or a television, is placed horizontally on a surface and a cone of a semi-transparent and reflective material is placed, point-down, on top of it.
A special image is displayed and reflected on the cone, giving the impression of an object floating mid-air.
The image is rotated to follow the user in his movements and give the continuity.

Works in 6 steps:
- Track the user's position through the Kinect sensor
- Extract the viewing angle between the device and the user
- Apply the viewing angle to the virtual object
- Pre-process the image to appear straight once reflected on the curve cone
- Place the image between the the center and the user
- Interact with gestures or voice

For more info check the paper.
