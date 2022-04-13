using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using KilnGod.BlazorWebGL;
using System.Drawing;
using KilnGod.BlazorWebGL.WebGL3D.Mesh.Shapes;
using KilnGod.BlazorWebGL.WebGL3D.Mesh.STL;
using System.Text.Json.Nodes;
using KilnGod.BlazorWebGL.WebGL3D;

namespace KilnGod.BlazorWebGL.TestSample.Pages
{
    public partial class WebGLCanvasTest1 : ComponentBase
    {
#nullable disable
        public WebGLCanvas Canvas3D { get; set; }

        public Rectangle Viewport { get; set; }

        [Inject]
        NavigationManager nav { get; set; }

       
#nullable enable

        public GLColor backgroundColor { get; set; } = new GLColor(0, 0, 0, 1); // black

        public bool disabledButtons { get; set; } = true;

      


        protected override void OnAfterRender(bool firstRender)
        {
            if (firstRender)
            {
                // we can't call any webgl functions until the page is fully rendered and the canvas is complete.
                Canvas3D.CanvasInitComplete += CanvasInitComplete;
            }
            base.OnAfterRender(firstRender);
        }


        private void CanvasInitComplete(WebGLCanvas glCanvas)
        {
            // we could start the rendering process here rather than having a button click to start rendering.
            disabledButtons = false;
            Viewport = new Rectangle(0, 0, glCanvas.Width, glCanvas.Height);
            StateHasChanged(); // <- this should be part of the disabledButtons set method, note statehaschanged will force an update of controls on our webpage.

     
        }

        protected async void UpdateSelected(ChangeEventArgs e)
        {
            string selectedValue = e.Value.ToString();
            ushort[] indices = null;
            float[] vertices = null;
            float[] normals = null;

            switch (selectedValue)
            {
                case "stlfile":
                    string filename = "C:\\!Source\\BlazorWebGL\\BlazorWebGL.Test\\wwwroot\\models\\stl\\EggRollBasket.stl";

                    STLReader stlReader = new STLReader(filename);
                    TriangleMesh[] meshArray = stlReader.ReadFile();

                    STLMesh tMesh = new STLMesh(meshArray);
                    indices = null;
                    vertices = tMesh.Get_Mesh_Vertices(31.0f);
                    normals = tMesh.Get_Mesh_Normals();
                    break;

                case "sphere":
                    Sphere sphere = new Sphere(50, 10, 10);
                    indices = sphere.Get_GPU_Indices_uShort();
                    vertices = sphere.Get_GPU_Vertices();
                    normals = sphere.Get_GPU_Normals();

                    break;

                case "box":
                    Box box = new Box(50, 50, 50, 3, 3, 3);
                    indices = box.Get_GPU_Indices_uShort();
                    vertices = box.Get_GPU_Vertices();
                    normals = box.Get_GPU_Normals();

                    break;

                case "cylinder":
                    Cylinder cylinder = new Cylinder(40, 40, 80, 10);
                    indices = cylinder.Get_GPU_Indices_uShort();
                    vertices = cylinder.Get_GPU_Vertices();
                    normals = cylinder.Get_GPU_Normals();

                    break;


                case "cone":
                    Cone cone = new Cone(40, 40, 80, 1);
                    indices = cone.Get_GPU_Indices_uShort();
                    vertices = cone.Get_GPU_Vertices();
                    normals = cone.Get_GPU_Normals();

                    break;

                default:
                    // clear display
                    break;
            }

            if (vertices != null)
            {
                await Canvas3D.createObject(RenderInfo.objectId);
                if (indices != null)
                {
                    await Canvas3D.setObjectValue(RenderInfo.objectId, RenderInfo.indicesId, indices);
                }
                await Canvas3D.setObjectValue(RenderInfo.objectId, RenderInfo.verticesId, vertices);
                if (normals != null)
                {
                    await Canvas3D.setObjectValue(RenderInfo.objectId, RenderInfo.normalsId, normals);
                }
                await Canvas3D.createScenery(RenderInfo.sceneId, RenderInfo.objectId);
            }

            await Canvas3D.InjectScript(RenderInfo.initializeRenderScript);

            await Canvas3D.SetFunctionWebGLBasis(RenderInfo.startRender, null);
        }


        public async void ConfigureSceneScript()
        {
            await Canvas3D.InjectScript(RenderInfo.initializeSceneScript);


            await Canvas3D.SetFunctionWebGLBasis(RenderInfo.initializeScene, null);


        }

        public async void ConfigureSceneCSharp()
        {
            // this is for illustration and will very slow when run on blazor server and is not the recommend approach for blazor server. 
            await Canvas3D.createObject(RenderInfo.sceneVariables);
            await Canvas3D.setObjectValue(RenderInfo.sceneVariables, RenderInfo.sceneId, RenderInfo.sceneId);
            await Canvas3D.setObjectValue(RenderInfo.sceneVariables, RenderInfo.cameraId, RenderInfo.cameraId);
            await Canvas3D.setObjectValue(RenderInfo.sceneVariables, RenderInfo.vertexShaderId, RenderInfo.vertexShaderId);
            await Canvas3D.setObjectValue(RenderInfo.sceneVariables, RenderInfo.fragmentShaderId, RenderInfo.fragmentShaderId);
            await Canvas3D.setObjectValue(RenderInfo.sceneVariables, RenderInfo.programId, RenderInfo.programId);


            await Canvas3D.clearColor(Color.Black);
            await Canvas3D.clearDepth(1);
            await Canvas3D.enable(Enable.DEPTH_TEST );
            await Canvas3D.enable( Enable.BLEND);
            await Canvas3D.depthFunc(CompareFunction.LESS);
            await Canvas3D.blendFunc(BlendFactor.SRC_ALPHA, BlendFactor.ONE_MINUS_SRC_ALPHA);

            await Canvas3D.createObject("lightPositions");
            await Canvas3D.setObjectValue("lightPositions", "red", new int[] { -150, 500, -150});
            await Canvas3D.setObjectValue("lightPositions", "green", new int[] { 150, 500, -150 });
            await Canvas3D.setObjectValue("lightPositions", "blue", new int[] { 150, 500, 150 });

            int numLights = 3;
            await Canvas3D.createShader(RenderInfo.vertexShaderId, ShaderType.VERTEX_SHADER,RenderInfo.vshade.Replace("@numLights@", numLights.ToString()));

            await Canvas3D.createShader(RenderInfo.fragmentShaderId, ShaderType.FRAGMENT_SHADER, RenderInfo.fshade.Replace("@numLights@", numLights.ToString()));

            await Canvas3D.createProgram(RenderInfo.programId);

            await Canvas3D.linkProgram(RenderInfo.programId, new string[] { RenderInfo.vertexShaderId, RenderInfo.fragmentShaderId });

            await Canvas3D.useProgram(RenderInfo.programId);

            await Canvas3D.createScene(RenderInfo.sceneId, RenderInfo.programId );

       
                

            
/*


            scene.uMaterialDiffuse = 'uKd';
            scene.uMaterialAmbient = 'uKa';
            scene.uMaterialSpecular = 'uKs';
            scene.uLightAmbient = 'uLa';
            scene.uLightDiffuse = 'uLd';
            scene.uLightSpecular = 'uLs';
            scene.uOpticalDensity = 'uNi';
            scene.uSpecularExponent = 'uNs';
            scene.uTransparency = 'uD';



            // scene attributes
            scene.attributeList = [
                scene.aVertexPosition,
                scene.aVertexNormal
            ];


            // scene uniforms
            scene.uniformList = [
                scene.uProjectionMatrix,
                scene.uModelViewMatrix,
                scene.uNormalMatrix,
                scene.uMaterialDiffuse,
                scene.uMaterialAmbient,
                scene.uMaterialSpecular,
                scene.uLightPosition,
                scene.uLightAmbient,
                scene.uLightDiffuse,
                scene.uLightSpecular,
                scene.uSpecularExponent,
                scene.uTransparency,
                scene.uOpticalDensity,
                scene.uIllum,
                scene.uWireframe
            ];


            scene.setupProgramAttributes(scene.attributeList);
            scene.setupProgramUniforms(scene.uniformList);




            const camera = scene.createCamera(sceneVariables.cameraId);
            camera.goHome([0, 60, 300]);
            camera.setFocus([0, 0, 30]);
            camera.setAzimuth(0);
            camera.setElevation(90);

            camera.addControls(webgl, sceneVariables.sceneId);

            scene.configureTransforms(sceneVariables.cameraId);


            // Iterate over each light and configure
            Object.keys(lightPositions).forEach(key => {
            const light = new Light(key);
            light.setPosition(lightPositions[key]);
            switch (key)
            {
                case 'red':
                    light.setDiffuse([1, 0, 0]);
                    light.setAmbient([1, 0, 0]);
                    break;
                case 'green':
                    light.setDiffuse([0, 1, 0]);
                    light.setAmbient([0, 1, 0]);
                    break;
                case 'blue':
                    light.setDiffuse([0, 0, 1]);
                    light.setAmbient([0, 0, 1]);
                    break;

            }

            light.setSpecular([0.1, 0.1, 0.1]);

            scene.addLight(light);
        });


            let lightpositions = scene.getLightArray('position');
            let lightdiffuse = scene.getLightArray('diffuse');
            let lightspecular = scene.getLightArray('specular');
            let lightambient = scene.getLightArray('ambient');

            scene.uniform3fv(scene.uLightPosition, lightpositions);
            scene.uniform3fv(scene.uLightDiffuse, lightdiffuse);
            scene.uniform3fv(scene.uLightSpecular, lightspecular);
            scene.uniform3fv(scene.uLightAmbient, lightambient);


            scene.uniform3fv(scene.uMaterialAmbient, [.5, .5, .5]);
            scene.uniform3fv(scene.uMaterialDiffuse, [0.5, 0.5, 0.5]);
            scene.uniform3fv(scene.uMaterialSpecular, [.5, .5, .5]);
            scene.uniform1f(scene.uSpecularExponent, 0.5);
            scene.uniform1f(scene.uOpticalDensity, 0.5);
            scene.uniform1f(scene.uTransparency, 0.9);
            scene.uniform1i(scene.uIllum, 1);

            const floor = new Floor(80, 20);

            scene.addScenery(floor);

            */
        }
}


    



    public static class RenderInfo
    {
        public const string sceneVariables = "sceneVariable";
        public static string sceneId = "scene1";
        public static string cameraId = "camera1";
        public static string vertexShaderId = "vshader1";
        public static string fragmentShaderId = "fshader1";
        public static string programId = "program1";
        

        public static string objectId = "sltObject1";
        public static string verticesId = "vertices";
        public static string normalsId = "normals";
        public static string indicesId = "indices";
        public static int lightCount = 3;

        public const string vshade = @"#version 300 es
            precision mediump float;

            const int numLights = @numLights@;

            uniform mat4 uModelViewMatrix;
            uniform mat4 uProjectionMatrix;
            uniform mat4 uNormalMatrix;
            uniform vec3 uLightPosition[numLights];

            in vec3 aVertexPosition;
            in vec3 aVertexNormal;
            in vec4 aVertexColor;

            out vec3 vNormal;
            out vec3 vLightRay[numLights];
            out vec3 vEye[numLights];

            void main(void)
            {
                vec4 vertex = uModelViewMatrix * vec4(aVertexPosition, 1.0);
                vNormal = vec3(uNormalMatrix * vec4(aVertexNormal, 1.0));

                for (int i = 0; i < numLights; i++)
                {
                    vec4 lightPosition = vec4(uLightPosition[i], 1.0);
                    vLightRay[i] = vertex.xyz - lightPosition.xyz;
                    vEye[i] = -vec3(vertex.xyz);
                }

                gl_Position = uProjectionMatrix * uModelViewMatrix * vec4(aVertexPosition, 1.0);
            }";

        public const string fshade = @"#version 300 es
            precision mediump float;

            const int numLights = @numLights@;

            uniform vec3 uLa[numLights];
            uniform vec3 uLd[numLights];
            uniform vec3 uLs[numLights];
            uniform vec3 uLightPosition[numLights];
            uniform vec3 uKa;
            uniform vec3 uKd;
            uniform vec3 uKs;
            uniform float uNs;
            uniform float uD;
            uniform int uIllum;
            uniform bool uWireframe;

            in vec3 vNormal;
            in vec3 vLightRay[numLights];
            in vec3 vEye[numLights];

            out vec4 fragColor;

            vec3 projectOnPlane(in vec3 p, in vec3 pc, in vec3 pn)
            {
                float distance = dot(pn, p - pc);
                return p - distance * pn;
            }

            void main(void)
            {
                // wireframe shading 
                if (uWireframe || uIllum == 0)
                {
                    fragColor = vec4(uKd, uD);
                    return;
                }

                // lambert term 
                if (uIllum == 1)
                {
                    vec3 color = vec3(0.0);
                    vec3 light = vec3(0.0);
                    vec3 eye = vec3(0.0);
                    vec3 reflection = vec3(0.0);
                    vec3 normal = normalize(vNormal);
                    for (int i = 0; i < numLights; i++)
                    {
                        light = normalize(vLightRay[i]);
                        color += (uLd[i] * uKd * clamp(dot(normal, -light), 0.0, 1.0));
                    }
                    fragColor = vec4(color, uD);
                }

                // phong shading version 1
                if (uIllum == 2)
                {
                    vec3 color = vec3(0.0);
                    vec3 light = vec3(0.0);
                    vec3 eye = vec3(0.0);
                    vec3 reflection = vec3(0.0);
                    vec3 normal = normalize(vNormal);
                    for (int i = 0; i < numLights; i++)
                    {
                        eye = normalize(vEye[i]);
                        light = normalize(vLightRay[i]);
                        reflection = reflect(light, normal);
                        color += (uLd[i] * uKd * clamp(dot(normal, -light), 0.0, 1.0));
                        color += (uLs[i] * uKs * pow(max(dot(reflection, eye), 0.0), uNs) * 4.0);
                    }
                    fragColor = vec4(color, uD);
                }

                // phong shading version 2
                if (uIllum == 3)
                {
                    vec3 finalColor = vec3(0.0, 0.0, 0.0);
                    vec3 N = normalize(vNormal);
                    vec3 L = vec3(0.0, 0.0, 0.0);
                    vec3 E = vec3(0.0, 0.0, 0.0);
                    vec3 R = vec3(0.0, 0.0, 0.0);
                    vec3 deltaRay = vec3(0.0);

                    const int lSize = numLights / 2 + 1;
                    const float step = 0.25;
                    const float invTotal = 1.0 / ((float(numLights) + 1.0) * (float(numLights) + 1.0));

                    float dx = 0.0;
                    float dz = 0.0;
                    float LT = 0.0;

                    for (int i = 0; i < numLights; i++)
                    {
                        dx = 0.0;
                        dz = 0.0;
                        E = normalize(vEye[i]);
                        for (int x = -lSize; x <= lSize; x++)
                        {
                            dx = dx + step;
                            for (int z = -lSize; z <= lSize; z++)
                            {
                                dz = dz + step;
                                deltaRay = vec3(vLightRay[i].x + dx, vLightRay[i].y, vLightRay[i].z + dz);
                                L = normalize(deltaRay);
                                R = reflect(L, N);
                                finalColor += (uLd[i] * uKd * clamp(dot(N, -L), 0.0, 1.0) * invTotal);
                                finalColor += (uLs[i] * uKs * pow(max(dot(R, E), 0.0), uNs));
                            }
                        }
                    }
                    fragColor = vec4(finalColor, uD);
                }
            }";



        public const string initializeScene = "initializeScene";

        public static string initializeSceneScript = @"

(function () {

    var sceneVariables = {};


    WebGLBasis.prototype."+RenderInfo.initializeScene+@" =
        function () {
                
            

            sceneVariables.sceneId = '" + RenderInfo.sceneId + @"';
            sceneVariables.cameraId = '" + RenderInfo.cameraId + @"';
            sceneVariables.vertexShaderId = '" + RenderInfo.vertexShaderId + @"';
            sceneVariables.fragmentShaderId = '" + RenderInfo.fragmentShaderId + @"';
            sceneVariables.programId = '" + RenderInfo.programId + @"';
           


            let vshade = `" + vshade + @"`;

            let fshade = `" + fshade + @"`;



            this.gl.clearColor(0.0, 0.0, 0.0, 1);
            this.gl.clearDepth(1);
            // enabling depth testing
            this.gl.enable(this.gl.DEPTH_TEST);
            this.gl.depthFunc(this.gl.LESS);
            // enabling alpha blending
            this.gl.enable(this.gl.BLEND);
            this.gl.blendFunc(this.gl.SRC_ALPHA, this.gl.ONE_MINUS_SRC_ALPHA);


            // Light positions for each individual light in the scene
            const lightPositions = {
                'red': [-150, 500, -150],
                'green': [150, 500, -150],
                'blue': [150, 500, 150]
            };


            var numLights = Object.keys(lightPositions).length;
            vshade = vshade.replace('@numLights@', numLights);
            fshade = fshade.replace('@numLights@', numLights);



            this.createShader(sceneVariables.vertexShaderId, this.gl.VERTEX_SHADER, vshade);
            this.createShader(sceneVariables.fragmentShaderId, this.gl.FRAGMENT_SHADER, fshade);

            this.createProgram(sceneVariables.programId);

            this.linkProgram(sceneVariables.programId, [sceneVariables.vertexShaderId, sceneVariables.fragmentShaderId]);


            this.useProgram(sceneVariables.programId);

            const scene = this.createScene(sceneVariables.sceneId, sceneVariables.programId);



            scene.uMaterialDiffuse = 'uKd';
            scene.uMaterialAmbient = 'uKa';
            scene.uMaterialSpecular = 'uKs';
            scene.uLightAmbient = 'uLa';
            scene.uLightDiffuse = 'uLd';
            scene.uLightSpecular = 'uLs';
            scene.uOpticalDensity = 'uNi';
            scene.uSpecularExponent = 'uNs';
            scene.uTransparency = 'uD';



            // scene attributes
            scene.attributeList = [
                scene.aVertexPosition,
                scene.aVertexNormal
            ];


            // scene uniforms
            scene.uniformList = [
                scene.uProjectionMatrix,
                scene.uModelViewMatrix,
                scene.uNormalMatrix,
                scene.uMaterialDiffuse,
                scene.uMaterialAmbient,
                scene.uMaterialSpecular,
                scene.uLightPosition,
                scene.uLightAmbient,
                scene.uLightDiffuse,
                scene.uLightSpecular,
                scene.uSpecularExponent,
                scene.uTransparency,
                scene.uOpticalDensity,
                scene.uIllum,
                scene.uWireframe
            ];


            scene.setupProgramAttributes(scene.attributeList);
            scene.setupProgramUniforms(scene.uniformList);




            const camera = scene.createCamera(sceneVariables.cameraId);
            camera.goHome([0, 60, 300]);
            camera.setFocus([0, 0, 30]);
            camera.setAzimuth(0);
            camera.setElevation(90);

            camera.addControls(this, sceneVariables.sceneId);

            scene.configureTransforms(sceneVariables.cameraId);


            // Iterate over each light and configure
            Object.keys(lightPositions).forEach(key => {
                const light = new WebGLLight(key);
                light.setPosition(lightPositions[key]);
                switch (key) {
                    case 'red':
                        light.setDiffuse([1, 0, 0]);
                        light.setAmbient([1, 0, 0]);
                        break;
                    case 'green':
                        light.setDiffuse([0, 1, 0]);
                        light.setAmbient([0, 1, 0]);
                        break;
                    case 'blue':
                        light.setDiffuse([0, 0, 1]);
                        light.setAmbient([0, 0, 1]);
                        break;

                }

                light.setSpecular([0.1, 0.1, 0.1]);

                scene.addLight(light);
            });


            let lightpositions = scene.getLightArray('position');
            let lightdiffuse = scene.getLightArray('diffuse');
            let lightspecular = scene.getLightArray('specular');
            let lightambient = scene.getLightArray('ambient');

            scene.uniform3fv(scene.uLightPosition, lightpositions);
            scene.uniform3fv(scene.uLightDiffuse, lightdiffuse);
            scene.uniform3fv(scene.uLightSpecular, lightspecular);
            scene.uniform3fv(scene.uLightAmbient, lightambient);


            scene.uniform3fv(scene.uMaterialAmbient, [.5, .5, .5]);
            scene.uniform3fv(scene.uMaterialDiffuse, [0.5, 0.5, 0.5]);
            scene.uniform3fv(scene.uMaterialSpecular, [.5, .5, .5]);
            scene.uniform1f(scene.uSpecularExponent, 0.5);
            scene.uniform1f(scene.uOpticalDensity, 0.5);
            scene.uniform1f(scene.uTransparency, 0.9);
            scene.uniform1i(scene.uIllum, 1);

            const floor = new Floor(80, 20);

            scene.addScenery(floor);


        };


}) ()
";


        public const string startRender = "startRender";

        public static string initializeRenderScript = @"


(function () {



    WebGLBasis.prototype.drawScene =
        function (){
   
            const scene = this.workingScene;
   
            this.gl.viewport(0, 0, this.gl.drawingBufferWidth, this.gl.drawingBufferHeight);
            this.gl.clear(this.gl.COLOR_BUFFER_BIT | this.gl.DEPTH_BUFFER_BIT);

            scene.updatePerspective('" + RenderInfo.cameraId + @"');
  
            scene.traverseScenery(object => {

                // ideally we want a terrain list and an animation list with offsets, scales and visibility for rendering objects in a scene
           
                 object.draw('" + RenderInfo.cameraId + @"');
            });
        };


    WebGLBasis.prototype.renderScene =
        function () {
            this.drawScene();
            this.animationRequestId = window.requestAnimationFrame(this.renderScene);
        };


    WebGLBasis.prototype." + RenderInfo.startRender+ @" =
        function () {    
            this.workingScene.traverseScenery(sceneItem => {
                sceneItem.attachProgram('" + RenderInfo.programId + @"');
            });
            this.renderScene();   
        };


}) ()
";

    }





}
