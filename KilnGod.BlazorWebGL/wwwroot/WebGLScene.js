
import { WebGLScenery } from './WebGLScenery.js';
import { WebGLCamera } from './WebGLCamera.js';
import { WebGLLight } from './WebGLLight.js';

import * as mat4 from "./mat4.js";

//const OBJFile = require("./OBJFile");

// assorted BlazorWebGL friendly classes for rendering


// Manages scenery in a 3D scene.
//
// note the scene assumes certain properties may exist in the shader script and attached via the program attributes and uniforms 
// items in the program naming covention are aVertexPosition, aVertexNormal, aVertexColor, aVertexTextureCoords
// object naming convention items are visible, alias, scalars, textureCoords, diffuse, Ka, Ks, Ns, d, illum, ibo, vao, vertices, ... etc
export class WebGLScene {
 // strict mode on by default in modules

    constructor(webgl, programId) {
        this.webgl = webgl;

        this.programId = programId;

        this.program = webgl.programStorage[programId];

        this.sceneryStorage = [];

        this.lightStorage = [];

        this.cameraStorage = [];

        this.attributeList = [];
        this.uniformList = [];

       

        this.aVertexPosition = 'aVertexPosition';
        this.aVertexNormal = 'aVertexNormal';
        this.aVertexColor = 'aVertexColor';
        this.aVertexTextureCoords = 'aVertexTextureCoords';
        this.aVertexTangent = 'aVertexTangent';

        this.uMaterialDiffuse = 'uMaterialDiffuse';
        this.uMaterialAmbient = 'uMaterialAmbient';
        this.uMaterialSpecular = 'uKs';

        this.uIllum = 'uIllum';
        this.uWireframe = 'uWireframe';
        

        this.uModelViewMatrix = 'uModelViewMatrix';
        this.uProjectionMatrix = 'uProjectionMatrix';
        this.uNormalMatrix = 'uNormalMatrix';

   
        this.uLightPosition = 'uLightPosition';
        
        this.uLightAmbient = 'uLightAmbient';
        this.uLightDiffuse = 'uLightDiffuse';
        this.uLightSpecular = 'uLs';
        this.uOpticalDensity = 'uNi';
        this.uSpecularExponent = 'uNs';
        this.uTransparency = 'uD';
        
 
        
    }


    setupProgramAttributes(attributeList) {
        this.webgl.setProgramAttributes(this.programId, attributeList);
    }

    setupProgramUniforms(uniformList) {
        this.webgl.setProgramUniforms(this.programId, uniformList);
    }

    createCamera(cameraId) {

        this.cameraStorage[cameraId] = new WebGLCamera(WebGLCamera.ORBITING_TYPE);

        this.webgl.createStandardizedMatrixStorage(cameraId);

        return this.cameraStorage[cameraId];
    }


    // manage camera tranforms
    // note the standard naming convention of the matrices 
    configureTransforms(cameraId) {
        this.stack = []; //? is this necessary?

        this.calculateModelView(cameraId);
        this.updatePerspective(cameraId);
        this.calculateNormal(cameraId);
    }

    // Calculates the Model-View matrix
    calculateModelView(cameraId) {
        this.webgl.matrixStorage[cameraId].modelViewMatrix = this.cameraStorage[cameraId].getViewTransform();
    }

    translateModelView(cameraId, delta3) {
        mat4.translate(this.webgl.matrixStorage[cameraId].modelViewMatrix, this.webgl.matrixStorage[cameraId].modelViewMatrix, delta3);
    }

    // Calculates the Normal matrix
    calculateNormal(cameraId) {
        mat4.copy(this.webgl.matrixStorage[cameraId].normalMatrix, this.webgl.matrixStorage[cameraId].modelViewMatrix);
        mat4.invert(this.webgl.matrixStorage[cameraId].normalMatrix, this.webgl.matrixStorage[cameraId].normalMatrix);
        mat4.transpose(this.webgl.matrixStorage[cameraId].normalMatrix, this.webgl.matrixStorage[cameraId].normalMatrix);
    }

    // Updates perspective
    updatePerspective(cameraId) {
        mat4.perspective(
            this.webgl.matrixStorage[cameraId].projectionMatrix,
            this.cameraStorage[cameraId].fov,
            this.webgl.gl.canvas.width / this.webgl.gl.canvas.height,
            this.cameraStorage[cameraId].minZ,
            this.cameraStorage[cameraId].maxZ
        );
    }

    // Sets all matrix uniforms
    setMatrixUniforms(cameraId) {

        this.calculateNormal(cameraId);
 
        this.webgl.gl.uniformMatrix4fv(this.program.uniformLocations.uModelViewMatrix, false, this.webgl.matrixStorage[cameraId].modelViewMatrix);
        this.webgl.gl.uniformMatrix4fv(this.program.uniformLocations.uProjectionMatrix, false, this.webgl.matrixStorage[cameraId].projectionMatrix);
        this.webgl.gl.uniformMatrix4fv(this.program.uniformLocations.uNormalMatrix, false, this.webgl.matrixStorage[cameraId].normalMatrix);
       
       
    }


    // Pushes matrix onto the stack
    push(cameraId) {
        const matrix = mat4.create();
        mat4.copy(matrix, this.webgl.matrixStorage[cameraId].modelViewMatrix);
        this.stack.push(matrix);
    }

    // Pops and returns matrix off the stack
    pop(cameraId) {
        return this.stack.length
            ? this.webgl.matrixStorage[cameraId].modelViewMatrix = this.stack.pop()
            : null;
    }



    /// manageAttributes
    
    setAttributeList(attributeIdArray) {
        attributeIdArray.forEach(attributeId => {
            this.program.attributeLocations[attributeId] = this.webgl.gl.getAttribLocation(program, attributeId);
        });
    }

    vertexAttribPointer(AttributeId, size, pointerType, normalized, stride, offset) {
        
        this.webgl.vertexAttribPointer(this.programId, AttributeId, size, pointerType, normalized, stride, offset);
    }


    enableVertexAttribArray(AttributeId) {
        this.webgl.enableVertexAttribArray(this.programId, AttributeId);
    }


    /// manage uniforms
    setUniformList(uniformIdArray) {
        uniformIdArray.forEach(uniformId => {
            this.program.uniformLocations[uniformId] = this.webgl.gl.getUniformLocation(program, uniformId);
        });
    } 

    uniform1i(uniformId, value) {
        const ulocation = this.program.uniformLocations[uniformId];
        this.webgl.gl.uniform1i(ulocation, value);
    }

    uniform1f(uniformId, value) {
        const ulocation = this.program.uniformLocations[uniformId];
        this.webgl.gl.uniform1f(ulocation, value);
    }

    /*
    uniform1i(uniformId, value, offset = null, length = null) {
        this.webgl.gl.uniform1i(this.program.uniformLocations[uniformId], value, offset, length);
    }*/

    uniform3fv(uniformId, array) {
        const ulocation = this.program.uniformLocations[uniformId];
        this.webgl.gl.uniform3fv(ulocation, array);
    }

    /*
    uniform3fv(uniformId, array, offset = null, length = null) {
        this.webgl.gl.uniform3fv(this.program.uniformLocations[uniformId], array, offset, length);
    }
    */

    uniformMatrix3fv(uniformId, matrixStorageId, matrixId, offset = null, length = null) {
        const ulocation = this.program.uniformLocations[uniformId];
        this.webgl.gl.uniform3fv(ulocation, this.webgl.matrixStorage[matrixStorageId][matrixId], offset, length);
    }


    uniform4fv(uniformId, array) {
        const ulocation = this.program.uniformLocations[uniformId];
        this.webgl.gl.uniform4fv(ulocation, array);
    }

    /*
    uniform4fv(uniformId, array, offset = null, length = null) {
        this.webgl.gl.uniform4fv(this.program.uniformLocations[uniformId], array, offset, length);
    }
    */

    uniformMatrix4fv(uniformId, transpose, matrixStorageId, matrixId) {
        const ulocation = this.program.uniformLocations[uniformId];
        this.webgl.gl.uniformMatrix4fv(ulocation, transpose, this.webgl.matrixStorage[matrixStorageId][matrixId]);
    }

    createBindVertextArray(vertextArrayId) {
        this.webgl.createBindVertextArray(vertextArrayId);
    }


    bindVertexArray(vertextArrayId) {
        this.webgl.bindVertexArray(vertextArrayId);
    }

    bindBuffer(bufferId, bufferType) {
        this.webgl.gl.bindBuffer(bufferType, this.webgl.bufferStorage[bufferId]);
    }


    drawAllElements(storageArrayId, mode) {
        const storageArray = this.webgl.typedArrayStorage[storageArrayId];

        this.webgl.gl.drawElements(mode, storageArray.arrayLength, storageArray.arrayType, 0);
    }


    
    createBindBufferData(bufferId, bufferType, bufferUsage, storageArrayId) {
        this.webgl.createBindBufferData(bufferId, bufferType, bufferUsage, storageArrayId);
    }

    // typed array storage, we could easily duplicate the same object thousands of times in a scene we only need one copy of the vertex, index, normal or texture arrays etc for an entire scene.
    removeStorage(storageArrayId) {
        this.webgl.removeStorage(storageArrayId);
    }

    createInt8Array(storageArrayId, values) {
        this.webgl.createInt8Array(storageArrayId, values);
    }

    createInt16Array(storageArrayId, values) {
        this.webgl.createInt16Array(storageArrayId, values);
    }

    createInt32Array(storageArrayId, values) {
        this.webgl.createInt32Array(storageArrayId, values);
    }

    createBigInt64Array(storageArrayId, values) {
        this.webgl.createBigInt64Array(storageArrayId, values);
    }

    createFloat32Array(storageArrayId, values) {
        this.webgl.createFloat32Array(storageArrayId, values);
    }

    createFloat64Array(storageArrayId, values) {
        this.webgl.createFloat64Array(storageArrayId, values);
    }

    createUint8Array(storageArrayId, values) {
        this.webgl.createUint8Array(storageArrayId, values);
    }

    createUint8ClampedArray(storageArrayId, values) {
        this.webgl.createUint8ClampedArray(storageArrayId, values);
    }

    createUint16Array(storageArrayId, values) {
        this.webgl.createUint16Array(storageArrayId, values);
    }

    createUint32Array(storageArrayId, values) {
        this.webgl.createUint32Array(storageArrayId, values);
    }

    createBigUint64Array(storageArrayId, values) {
        this.webgl.createBigUint64Array(storageArrayId, values);
    }

    emptyScene() {
        //cleanup everything, free all resources
    }

    emptyScenry() {

    }

    // Find the item with given alias
    getScenery(alias) {
        return this.sceneryStorage.find(object => object.alias === alias);
    }

    // Asynchronously load a file
    // the debugger will stop on the catch with a null error function so it does not trigger the error method. 
    // the call is async and the addScenery method will be called after the response completes, which is a bit spooky.
    loadScenery(fileName, alias, attributes) {
        return fetch(fileName)
            .then(response => response.json())
            .then(object => {
                object.visible = true;
                object.alias = alias || object.alias;
                this.addScenery(object, attributes);
            })
            .catch((err) => { errmsg = err; console.error(errmsg, ...arguments) });
    }

    // Helper function for returning as list of items for a given model
    loadSceneryByParts(path, count, alias) {
        for (let i = 1; i <= count; i++) {
            const part = `${path}${i}.json`;
            this.loadScenery(part, alias);
        }
    }

 
 

    // Add object to scene, by settings default and configuring all necessary
    // buffers and textures
    addScenery(object, attributes) {
        if (attributes) {
            Object.assign(object, attributes);
        }
        // json object format
        // Push to our scenery list for later access

        const sceneItem = new WebGLScenery(this, object);

    

        this.sceneryStorage.push(sceneItem);

       
    }

    // Traverses function over every item in the scene
    traverseScenery(cb) {
        for (let i = 0; i < this.sceneryStorage.length; i++) {
            // Break out of the loop as long as any value is returned
            if (cb(this.sceneryStorage[i], i) !== undefined) break;
        }
    }

    // Removes an item from the scene with a given alias
    removeScenery(alias) {
        const object = this.get(alias);
        const index = this.sceneryStorage.indexOf(object);
        this.sceneryStorage.splice(index, 1);
    }

    // Renders an item first
    renderSceneryFirst(alias) {
        const object = this.get(alias);
        const index = this.sceneryStorage.indexOf(object);
        if (index === 0) return;

        this.sceneryStorage.splice(index, 1);
        this.sceneryStorage.splice(0, 0, object);
      
    }


    // Pushes an item up the render priority
    renderScenerySooner(alias) {
        const object = this.get(alias);
        const index = this.sceneryStorage.indexOf(object);
        if (index === 0) return;

        this.sceneryStorage.splice(index, 1);
        this.sceneryStorage.splice(index - 1, 0, object);
      
    }

    // lights used in this scene
    addLight(light) {
        if (!(light instanceof WebGLLight)) {
            console.error('The parameter is not a light');
            return;
        }
        this.lightStorage.push(light);
    }

    getLight(index) {
        if (typeof index === 'string') {
            return this.lightStorage.find(light => light.id === index);
        } else {
            return this.lightStorage[index];
        }
    }

    getLightArray(type) {
        return this.lightStorage.reduce((result, light) => {
            result = result.concat(light[type]);
            return result;
        }, []);
    }





}


