# BlazorWebGL Library  
### by KilnGod (I love ceramics)

## Supported Elements
My initial review of WebGL support with Blazor returned a number of "interesting" libraries, often game oriented.
These libraries did not support proper JavaScript modularization or support of both server and WebAssembly operation 
with a single library. Therefore I wrote this custom library to achieve modularization and single library support 
for both server and WebAssembly as an example for others to follow. 

## Purpose

My goal with this library is support of visualization and simulation rather than game development. Yes, it would 
be great to load game landscapes as this falls under simulation however full game controls may or may not be supported.

## 2D Visualization

The "BasicCanvas" component is a modularized wrapper around the 2D WebGl Context, all 2D WebGl Context methods are 
implemented as C# extension methods of the BasicCanvas component. For performance reasons, one can inject JavaScript
methods to speed rendering on the canvas by reducing the number of calls over the wire when rendering from webserver.
For 2D "Visualization" I am wrapping "plotly.js" in a Blazor component, no need to reinvent the wheel. 

## 3D Visualization and Simulation

The "WebGLCanvas" component is a modularized wrapper around the 3D WebGl Context. All 3D WebGl methods are implemented 
as C# extension methods with additional javascript objects following in the footsteps of 3D frameworks presented 
in the book "Real-Time 3D Graphics with WebGL 2" co-authored by Diego Cantor and Farhad Ghayour. I highly recommend 
"Real-Time 3D Graphics with WebGL 2" book for anyone interested in a good background on "OpenGL ES 3.0" 3D based 
rendering.

## Performance
Its useful to understand WebGL in the browser is implemented natively on Windows in DirectX 12 or Vulkan, Android/Linux 
in Vulkan or OpenGL, Mac/iOS in Metal perhaps wrapped as Vulkan or OpenGL. There is a minium of one wrapper call inside 
the browser to the native API, likely two on Apple devices depending on the browser. This adds a small amount of overhead 
to each call. However, given the nature of 3D rendering this is not a significant impact on performance. The biggest drag
on WebGL performance in a server hosted environment are the client/server calls over the "SignalR" wire Blazor uses. This 
overhead can be avoided with WebAssembly deployment or highly mindful use of client side JavaScript in server hosted 
application. Also hybrid Blazor applications (Server + WebAssembly) will become routine in the next release of Blazor.    

## Browser Support
Chromium based browsers Chrome and Edge support both WebAssemble and WebGl2 (OpenGL 3.0) specification. Currently Mozilla 
and Safari do not support WebAssembly and have no plans to support WebAssembly as this would defeat Apple's 30% app store 
commission. Note games are a principle revenue driver for Apple App store. Safari was last to the party with WebGL2 support 
only starting February 23, 2022 and no indication if WebGL2 support would ever arrive. It was laudable that Apple's website 
had WebGL2 features not visible in Safari browsers for many years. I wonder if Intel based Macs version of Safari support 
WebGL2? I feel distinctly sorry for anyone who bought an Intel based Mac in recent years. In my opinion Apple clearly diverted 
the majority of their developer resources to their M1 processor since 2018, WebGl2 specification was finalized in January 2017.
It appears M1 support delayed Safari's WebGL2 support by 3 to 5 years. My guess is Intel Mac do not support WebGL2 as I can't 
see Apple updating Metal on Intel Macs, but who knows? I experienced Apple's "unplanned" product obsolesce with an iPhone 3 
and an Intel based Mac Mini which was obsolete on arrival due to last generation hardware under the hood. It's clear to me 
all Intel based Macs are effectively end of life products with minimal future support. Likely best to install Linux on an Intel 
Mac and call it a day.

## Future Innovations
1) 3D complete object viewing
2) 3D data visualization from c#





