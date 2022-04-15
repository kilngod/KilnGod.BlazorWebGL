# BlazorWebGL Library  
### by KilnGod (I love ceramics)

## Supported Elements
My initial review of WebGL support with Blazor returned a number of "interesting" libraries, often game oriented.
These libraries did not support proper JavaScript modularization or support of both server and webassembly operation 
with a single library. Therefore I wrote this custom library to acheive modularization and single library support 
for both server and webassembly as an example for others to follow. 

## Purpose

My goal with this library is support of visualization and simulation rather than game development. Yes, it would 
be great to load game landscapes as this falls under simulation however full game controls may or may not be supported.

## 2D Visualization

The "BasicCanvas" component is a modularized wrapper around the 2D WebGl Context, all 2D WebGl Context methods are 
implemented as C# extension methods of the BasicCanvas component. For performnce reasons, one can inject JavaScript
methods to speed rendering on the canvas by reducing the number of calls over the wire when rendering from webserver.

## 3D Visualization and Simulation

The "WebGLCanvas" component is a modularized wrapper around the 3D WebGl Context. All 3D WebGl methods are implemented 
as C# extension methods with additional javascript objects following in the footsteps of 3D frameworks presented 
in the book "Real-Time 3D Graphics with WebGL 2" co-authored by Diego Cantor and Farhad Ghayour. I highly recommend 
"Real-Time 3D Graphics with WebGL 2" book for anyone interested in a good background on "OpenGL ES 3.0" 3D based 
rendering.

## Performance
Its useful to understand WebGL in the browser is implemented natively on Windows in DirectX 12 or Vulkan, Android/Linux 
in Vulkan or OpenGL, Mac/iOS in Metal perhaps wrapped as Vulkan or OpenGL. There is a minium of one wrapper call inside 
the browser to the native API, likely two on Apple devices. This adds a small amount of overhead to each call. However, 
given the nature of 3D rendering this is not a significant impact on performance. The biggest drag on WebGL performance 
in a server hosted environment are the client/server calls over the "SignalR" wire blazor uses. This overhead can be 
avoided with WebAssembly deployment or highly mindful use of client side JavaScript in server hosted application. Also 
hybrid Blazor applications (Server + WebAssembly) will become routine in the next release of Blazor.    

## Browser Support
Cromium based browsers Chrome and Edge support both WebAssemble and WebGl2 (OpenGL 3.0) specification. Currently Mozilla 
and Safari do not support WebAssembly and have no plans to support WebAssembly as this would defeat Apple's 30% app store 
commission for games and applications. Note games are a principle revenue driver for Apple. Safari was last to the party 
with WebGL2 support only starting Feburary 23, 2022, it was lauadable that Apple's website had WebGL2 features not visible
in Safari browsers for many years. I feel distinctly sorry for anyone who bought an Intel based Mac in recent years. In 
my opinion Apple clearly diverted the majority of their developer resources to their M1 processor since 2018. It appears 
this delayed Safari WebGL2 support for approximately 5 years. I wonder if Intel based Macs version of Safari 
support WebGL2? My guess is Intel Mac do not as I can't see Apple updating Metal on Intel Macs, but who knows? I experienced 
Apples "unplanned" product obselence with an iPhone 3 and an Intel based Mac Mini that was obselete on arrival. It's clear 
to me all Intel based Macs are effectively end of life products with minimal future support. Likely wise to install Linux 
and call it a day with Intel based Macs.






