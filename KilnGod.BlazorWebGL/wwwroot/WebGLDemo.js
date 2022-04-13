export class WebGLDemo {


    constructor(webgl) {
        
        this.webgl = webgl;
        this.gl = webgl.gl;
    }


    establishRender(programId, cameraId) {


        WebGLBasis.prototype.drawScene =
            function () {

                const scene = this.workingScene;

                this.gl.viewport(0, 0, this.gl.drawingBufferWidth, this.gl.drawingBufferHeight);
                this.gl.clear(this.gl.COLOR_BUFFER_BIT | this.gl.DEPTH_BUFFER_BIT);

                scene.updatePerspective(cameraId);

                scene.traverseScenery(object => {

                    // ideally we want a terrain list and an animation list with offsets, scales and visibility for rendering objects in a scene

                    object.draw(cameraId);
                });
            };


        WebGLBasis.prototype.renderScene =
            function () {
                drawScene();
                sceneVariables.animationRequestId = window.requestAnimationFrame(this.renderScene);
            };


        WebGLBasis.prototype.startRender =
            function () {
                this.workingScene.traverseScenery(sceneItem => {
                    sceneItem.attachProgram(programId);
                });
                renderScene();
            };



    }



    establishScene(sceneId, programId, vertexShaderId, vshade, fragmentShaderId, fshade, cameraId) {


        WebGLBasis.prototype.initializeScene =
            function () {


                const ctx = this.gl;




                ctx.clearColor(0.0, 0.0, 0.0, 1);
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
                vshade = "`"+ vshade.replace('@numLights@', numLights)+"`";
                fshade = "`"+ fshade.replace('@numLights@', numLights)+"`";



                this.createShader(vertexShaderId, this.gl.VERTEX_SHADER, vshade);
                this.createShader(fragmentShaderId, this.gl.FRAGMENT_SHADER, fshade);

                this.createProgram(programId);

                this.linkProgram(programId, [vertexShaderId, fragmentShaderId]);


                this.useProgram(programId);

                const scene = this.createScene(sceneId, programId);



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




                const camera = scene.createCamera(cameraId);
                camera.goHome([0, 60, 300]);
                camera.setFocus([0, 0, 30]);
                camera.setAzimuth(0);
                camera.setElevation(90);

                camera.addControls(webgl, sceneId);

                scene.configureTransforms(cameraId);


                // Iterate over each light and configure
                Object.keys(lightPositions).forEach(key => {
                    const light = new Light(key);
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

    }

}
