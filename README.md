## What
A 3D implementation of a self-organizing map for colors defined in 4-space RGBA. 
Self-organizing maps are amazing because of their ability to map high-dimensional data
into lower-dimensional domains while retaining some of the information that is present
in the high-dimensional space. A form of data-compression, if you will. This project is
a demonstration of that ability by using 4-data-dimensional colors (red, green, blue, and alpha components)
and mapping those colors into 3-dimensional space (which you're actually seeing as 2D...).

I've provided this animation, as well as a couple static images so you can see what it looks like:
<img src="https://raw.githubusercontent.com/RutledgePaulV/self-organizing-3d/master/animation.gif"/>

You'll notice that prior to training the network, the colors of varying hues and opacities are randomly scattered,
as in this image:

<img src="https://lh4.googleusercontent.com/-_b3bkL7cJrQ/VFGtm8aiJpI/AAAAAAAAA6g/d3E-2RN5oRM/w641-h643-no/untrained.PNG"/>

However, after training, not only have the colors been organized into grouping by hue, but you'll also realize that
similar opacities have been grouped together throughout. In this way, you are able to make some general claims about
the nature of that 4th dimension of the color based upon where in the 3-D cube it is found, and so a higher data dimension
is at least partially captured in a lower spacial dimension. Here is an image after training the network:

<img src="https://lh4.googleusercontent.com/--rLvIC75KrU/VFGtmoPicLI/AAAAAAAAA6c/kmGKmhBEv3I/w644-h643-no/trained.PNG"/>