import { WebGLCamera } from './WebGLCamera.js';
import { WebGLControls } from './WebGLControls.js';
import { WebGLLight } from './WebGLLight.js';
import { WebGLScene } from './WebGLScene.js';
import { WebGLScenery } from './WebGLScenery.js';
import { WebGLTexture } from './WebGLTexture.js';
import { Floor } from './Floor.js';

export { WebGLCamera, WebGLControls, WebGLLight, WebGLScene, WebGLScenery, WebGLTexture, Floor };


// JavaScript Matrix library
import * as glMatrix from "./common.js";
import * as mat2 from "./mat2.js";
import * as mat2d from "./mat2d.js";
import * as mat3 from "./mat3.js";
import * as mat4 from "./mat4.js";
import * as quat from "./quat.js";
import * as quat2 from "./quat2.js";
import * as vec2 from "./vec2.js";
import * as vec3 from "./vec3.js";
import * as vec4 from "./vec4.js";

export {
    glMatrix,
    mat2, mat2d, mat3, mat4,
    quat, quat2,
    vec2, vec3, vec4,
};




export function initializeWebGL(canvasid, isWebassemblyClient, isTransparent, isPreserveDrawingBuffer, isDesynchronized) {
    // strict mode on by default in modules

    const canvas = document.getElementById(canvasid); //'webgl-canvas'
    let context = null;


    context = canvas.getContext('webgl2', { preserveDrawingBuffer: isPreserveDrawingBuffer, desynchronized: isDesynchronized, alpha: isTransparent });


    if (context) {
        canvas.webgl = new WebGLBasis(context, isWebassemblyClient, canvas);
    }


    return;
}


export function InjectScript(scriptText) {

    eval(scriptText);

}





export function setValueWebGLContext(webglCanvas, valueName, values) {
    "use strict";
    if (webglCanvas && webglCanvas.webgl) {

        const context = webglCanvas.webgl.gl;

        // Blazor "params object?[]? args" as values can be passed as an array of arrays. 
        // When the first element is an array substitute the first element as the array.
        if (Array.isArray(values)) {

            if (Array.isArray(values[0])) {

                values = values[0];
            }
        }
        context[valueName] = values;
    }
}


export function setFunctionWebGLContext(webglCanvas, functionName, values) {
    "use strict";
    if (webglCanvas && webglCanvas.webgl) {

        const context = webglCanvas.webgl.gl;

        if (Array.isArray(values)) {
            // Blazor "params object?[]? args" as values can be passed as an array of arrays. 
            // When the first element is an array substitute the first element as the array.
            if (Array.isArray(values[0])) {
                values = values[0];
            }

            // call the named webgl function
            switch (values.length) {
                case 0: //no parameters empty array
                    context[functionName]();
                    break;
                case 1:
                    context[functionName](values[0]);
                    break;
                case 2:
                    context[functionName](values[0], values[1]);
                    break;
                case 3:
                    context[functionName](values[0], values[1], values[2]);
                    break;
                case 4:
                    context[functionName](values[0], values[1], values[2], values[3]);
                    break;
                case 5:
                    context[functionName](values[0], values[1], values[2], values[3], values[4]);
                    break;
                case 6:
                    context[functionName](values[0], values[1], values[2], values[3], values[4], values[5]);
                    break;
                case 7:
                    context[functionName](values[0], values[1], values[2], values[3], values[4], values[5], values[6]);
                    break;
                default:
                    context[functionName](values); // arrays longer than 7 terms have to be managed by the receiving function
                    break;
            }
        }
        else {
            context[functionName](values);
        }
    }
}





export function setFunctionWebGLBasis(webglCanvas, functionName, values) {
    "use strict";
    if (webglCanvas && webglCanvas.webgl) {

        const webgl = webglCanvas.webgl;

        // Blazor "params object?[]? args" as values can be passed as an array of arrays. 
        // When the first element is an array substitute the first element as the array.
        if (Array.isArray(values)) {

            if (Array.isArray(values[0])) {
                values = values[0];
            }

            switch (values.length) {
                case 0: //no parameters empty array
                    webgl[functionName]();
                    break;
                case 1:
                    webgl[functionName](values[0]);
                    break;
                case 2:
                    webgl[functionName](values[0], values[1]);
                    break;
                case 3:
                    webgl[functionName](values[0], values[1], values[2]);
                    break;
                case 4:
                    webgl[functionName](values[0], values[1], values[2], values[3]);
                    break;
                case 5:
                    webgl[functionName](values[0], values[1], values[2], values[3], values[4]);
                    break;
                case 6:
                    webgl[functionName](values[0], values[1], values[2], values[3], values[4], values[5]);
                    break;
                case 7:
                    webgl[functionName](values[0], values[1], values[2], values[3], values[4], values[5], values[6]);
                    break;
                default:
                    webgl[functionName](values); // arrays longer than 7 terms have to be managed by the receiving function
                    break;
            }
        } else {
            webgl[functionName](values);
        }
    }
}



export function getValueWebGLContext(webglCanvas, valueName) {
    "use strict";
    // Blazor "params object?[]? args" as values can be passed as an array of arrays. 
    // When the first element is an array substitute the first element as the array.
    if (Array.isArray(valueName)) {
        valueName = valueName[0];
    }


    if (webglCanvas && webglCanvas.webgl) {

        const context = webglCanvas.webgl.gl;

        return context[valueName];
    }
}


export function getFunctionWebGLContext(webglCanvas, functionName, values) {
    "use strict";
    if (webglCanvas && webglCanvas.webgl) {

        const context = webglCanvas.webgl.gl;

        if (Array.isArray(values)) {
            // Blazor "params object?[]? args" as values can be passed as an array of arrays. 
            // When the first element is an array substitute the first element as the array.
            if (Array.isArray(values[0])) {
                values = values[0];
            }

            // call the named webgl function
            switch (values.length) {
                case 0: //no parameters empty array
                    return context[functionName]();
                case 1:
                    return context[functionName](values[0]);
                case 2:
                    return context[functionName](values[0], values[1]);
                case 3:
                    return context[functionName](values[0], values[1], values[2]);
                case 4:
                    return context[functionName](values[0], values[1], values[2], values[3]);
                case 5:
                    return context[functionName](values[0], values[1], values[2], values[3], values[4]);
                case 6:
                    return context[functionName](values[0], values[1], values[2], values[3], values[4], values[5]);
                case 7:
                    return context[functionName](values[0], values[1], values[2], values[3], values[4], values[5], values[6]);
                default:
                    return context[functionName](values); // arrays longer than 7 terms have to be managed by the receiving function
            }
        }
        else {
            return context[functionName](values);
        }
    }
}



export function getFunctionWebGLBasis(webglCanvas, functionName, values) {
    "use strict";
    if (webglCanvas && webglCanvas.webgl) {

        const webgl = webglCanvas.webgl;

        // Blazor "params object?[]? args" as values can be passed as an array of arrays. 
        // When the first element is an array substitute the first element as the array.
        if (Array.isArray(values)) {

            if (Array.isArray(values[0])) {
                values = values[0];
            }

            switch (values.length) {
                case 0: //no parameters empty array
                    return webgl[functionName]();
                case 1:
                    return webgl[functionName](values[0]);
                case 2:
                    return webgl[functionName](values[0], values[1]);
                case 3:
                    return webgl[functionName](values[0], values[1], values[2]);
                case 4:
                    return webgl[functionName](values[0], values[1], values[2], values[3]);
                case 5:
                    return webgl[functionName](values[0], values[1], values[2], values[3], values[4]);
                case 6:
                    return webgl[functionName](values[0], values[1], values[2], values[3], values[4], values[5]);
                case 7:
                    return webgl[functionName](values[0], values[1], values[2], values[3], values[4], values[5], values[6]);
                default:
                    return webgl[functionName](values); // arrays longer than 7 terms have to be managed by the receiving function
            }
        } else {
            return webgl[functionName](values);
        }
    }
    return null;
}

export class WebGLBasis {
    // strict mode on by default in modules

    constructor(glContext, isWebAssemblyClient, canvas) {
        // reference for GLContext
        this.gl = glContext;
        // reference for .NetCalls  

        this.canvas = canvas;

        // is the rest of the Blazor page "in process" with the WebGL canvas?
        this.isWebAssemblyClient = isWebAssemblyClient;


        // often we want to repeatedly show similar objects, we keep one copy per WebGLContext
        this.typedArrayStorage = [];

        // vertex, index, normal storage etc
        this.vertexArrayStorage = [];

        // shaders
        this.shaderStorage = [];

        // programs 
        this.programStorage = [];

        // buffer storage
        this.bufferStorage = [];

        // frame buffer storage
        this.frameBufferStorage = [];

        this.renderbufferStorage = [];

        // this is a list of our scenes, we assume each scene is a rendering "world" unto itself, scenes only required if using cameras
        this.sceneStorage = [];

        // this is a little bit different as this represents related convention named matrices with a camera
        // this is about lists of lists of arrays using standard naming
        this.matrixStorage = [];

        this.objectStorage = [];

        this.errors = {};

        this.fileStorage = [];

        this.samplerStorage = [];



        this.queryStorage = [];

        this.textureStorage = [];

    }

    autoResizeCanvas() {
        const expandFullScreen = () => {
            this.width = window.innerWidth;
            this.height = window.innerHeight;
        };
        expandFullScreen();
        // Resize screen when the browser has triggered the resize event
        window.addEventListener('resize', expandFullScreen);
    }


    clearViewport(value) {
        this.gl.viewport(0, 0, this.gl.drawingBufferWidth, this.gl.drawingBufferHeight);
        this.gl.clear(value);
    }

    // object methods 

    createObject(objectId) {
        this.objectStorage[objectId] = [];
        this.objectStorage[objectId].alias = objectId;
    }

    deleteObject(objectId) {
        const storage = this.objectStorage.get(objectId);
        const index = this.objectStorage.indexOf(storage);
        this.objectStorage.splice(index, 1);
        storage = null;
    }

    setObjectValue(objectId, valueId, values) {
        if (Array.isArray(values) && Array.isArray(values[0])) {
            values = values[0];
        }

        this.objectStorage[objectId][valueId] = values;
    }

    getObjectValue(objectId, valueId) {
        return this.objectStorage[objectId][valueId]
    }

    // query methods

    createQuery(queryId) {
        this.queryStorage[queryId] = this.gl.createQuery();
        this.queryStorage[queryId].alias = queryId;
    }

    deleteQuery(queryId) {
        const query = this.queryStorage.get(queryId);
        const index = this.queryStorage.indexOf(query);
        this.queryStorage.splice(index, 1);
        this.gl.deleteQuery(query);
        query = null;
    }

    beginQuery(target, queryId) {
        this.gl.beginQuery(target, this.queryStorage[queryId]);
    }

    endQuery(target) {
        this.gl.endQuery(target);
    }

    getQuery(target, pname) {
        const query = this.gl.getQuery(target, pname);
        const index = this.queryStorage.indexOf(query);
        if (index < 0) { return null; }
        return query.alias;
    }

    // sampler methods

    createSampler(samplierId) {
        this.samplerStorage[samplierId] = this.gl.createSampler();
    }


    deleteSampler(samplierId) {
        const sampler = this.samplerStorage.get(samplierId);
        const index = this.samplerStorage.indexOf(sampler);
        this.samplerStorage.splice(index, 1);
        this.gl.deleteSampler(sampler);
        sampler = null;
    }

    bindSampler(samplerId, unit) {
        this.gl.bindSampler(unit, this.samplerStorage[samplierId]);
    }

    getSamplerParameter(samplerId, pname) {
        return this.gl.getSamplerParameter(this.samplerStorage[samplierId], pname);
    }

    // render buffer methods

    createRenderbuffer(renderbufferId) {
        this.renderbufferStorage[renderbufferId] = this.gl.createRenderbuffer();
    }

    isRenderbuffer(renderbufferId) {
        return this.gl.isRenderbuffer(this.renderbufferStorage[renderbufferId]);
    }

    deleteRenderbuffer(renderbufferId) {
        const renderbuffer = this.renderbufferStorage.get(renderbufferId);
        const index = this.renderbufferStorage.indexOf(renderbuffer);
        this.renderbufferStorage.splice(index, 1);
        this.gl.deleteRenderbuffer(renderbuffer);
        renderbuffer = null;
    }

    bindRenderbuffer(renderbufferId) {
        this.gl.bindRenderbuffer(this.gl.RENDERBUFFER, this.renderbufferStorage[renderbufferId]);
    }

    getRenderbufferParameter(pname) {
        this.gl.getRenderbufferParameter(this.gl.RENDERBUFFER, pname);
    }

    renderbufferStorage(internalformat, width, height) {
        this.gl.renderbufferStorage(this.gl.RENDERBUFFER, internalformat, width, height);
    }


    // framebuffer methods


    framebufferTextureLayer(target, attachment, textureId, level, layer) {
        this.gl.framebufferTextureLayer(target, attachment, this.textureStorage[textureId], level, layer);
    }

    // texture methods




    createTexture(textureId) {
        this.textureStorage[textureId] = this.createTexture();
        this.textureStorage[textureId].alias = textureId;
    }

    createBindTexture(target, textureId) {
        this.textureStorage[textureId] = this.createTexture();
        this.textureStorage[textureId].alias = textureId;
        this.gl.bindTexture(target, this.textureStorage[textureId]);
    }

    deleteTexture(textureId) {
        const texture = this.textureStorage.get(textureId);
        const index = this.textureStorage.indexOf(texture);
        this.textureStorage.splice(index, 1);
        this.gl.deleteTexture(texture);
        storage = null;
    }

    bindTexture(target, textureId) {
        this.gl.bindTexture(target, this.textureStorage[textureId]);
    }

    isTexture(textureId) {
        this.gl.isTexture(this.textureStorage[textureId])
    }

    //note for our purposes we will only support arraybufferview and image data as these are fully cross platform

    texImage2D(target, level, internalformat, type, pixels) {
        this.gl.texImage2D(target, level, internalformat, internalformat, type, pixels)
    }

    texImage2D(target, level, internalformat, width, height, border, type, storageArrayId) {
        this.gl.texImage2D(target, level, internalformat, width, height, border, internalformat, type, this.typedArrayStorage[storageArrayId]);
    }


    texImage2D(target, level, internalformat, width, height, border, type, storageArrayId, srcOffset) {

        this.gl.texImage2D(target, level, internalformat, width, height, border, internalformat, type, this.typedArrayStorage[storageArrayId], srcOffset);
    }
    /* // webgl does not support compressed textures for OpenGL 3.0
    compressedTexImage2D() { }
    compressedTexSubImage2D() { }
    */

    /* // once a texture is bound all these call are made on the gl context
    copyTexImage2D() { }
    copyTexSubImage2D() { }    
    getTexParameter() { }
    texParameterf() { }
    texParameteri() { }
    texSubImage2D() { }
    */

    createScenery(sceneId, objectId, values) {
        const scene = this.sceneStorage[sceneId];
        const jsonObject = this.objectStorage[objectId];
        if (values && values[0]) {
            scene.addScenery(jsonObject, values);
        }
        else {
            scene.addScenery(jsonObject);
        }

    }

    createShader(shaderId, shaderType, shaderScript) {
        const shader = this.gl.createShader(shaderType);

        this.gl.shaderSource(shader, shaderScript);

        this.shaderStorage[shaderId] = shader;
        // we only compile shader when we link, most browsers support parallel compilation of shaders
    }



    createProgram(programId) {
        const program = this.gl.createProgram();
        this.programStorage[programId] = program;

        // attribute locations the interface between our code and the webgl engine
        program.attributeLocations = [];

        // uniform locations the interface between our code and the webgl engine
        program.uniformLocations = [];

        return program;
    }

    deleteProgram(programId) {

    }


    attachShaderProgram(programId, shaderId) {
        this.gl.attachShader(this.programStorage[programId], this.shaderStorage[shaderId]);
    }


    compileOnce(shaderId) {
        if (this.shaderStorage[shaderId].compiled) return;
        this.gl.compileShader(this.shaderStorage[shaderId]);

        if (!this.gl.getShaderParameter(this.shaderStorage[shaderId], this.gl.COMPILE_STATUS)) {
            console.error(this.gl.getShaderInfoLog(shader));
        }
        this.shaderStorage[shaderId].compiled = true;
    }

    linkProgram(programId, shaderIdArray) {
        // need to review parallel compilation
        for (const shaderId of shaderIdArray) {
            this.compileOnce(shaderId);
            this.attachShaderProgram(programId, shaderId);
        }

        this.gl.linkProgram(this.programStorage[programId]);

        this.gl.validateProgram(this.programStorage[programId]);

        const success = this.gl.getProgramParameter(this.programStorage[programId], this.gl.LINK_STATUS);
        if (success) {
            return this.programStorage[programId];
        }
        else {
            console.error('Link failed: ' + this.gl.getProgramInfoLog(this.programStorage[programId]));
            shaderIdArray.forEach(shaderId => this.errors[shaderId] = ' log:' + this.gl.getShaderInfoLog(this.shaderStorage[shaderId]));
            this.programStorage[programId] = null;
            return null;
        }
    }

    validateProgram(programId) {
        this.gl.validateProgram(this.programStorage[programId]);

        const success = this.gl.getProgramParameter(this.programStorage[programId], this.gl.LINK_STATUS);

        if (!success) {
            console.error('Link failed: ' + this.gl.getProgramInfoLog(this.programStorage[programId]));
        }

    }

    useProgram(programId) {
        this.gl.useProgram(this.programStorage[programId]);
    }


    // vertex methods


    createVertexArray(vertexArrayId) {
        const gl = this.gl;

        this.vertexArrayStorage[vertexArrayId] = gl.createVertexArray();
    }

    createBindVertextArray(vertexArrayId) {
        const gl = this.gl;

        this.vertexArrayStorage[vertexArrayId] = gl.createVertexArray();
        gl.bindVertexArray(this.vertexArrayStorage[vertexArrayId]);
    }


    bindVertexArray(vertexArrayId) {
        const gl = this.gl;
        gl.bindVertexArray(this.vertexArrayStorage[vertexArrayId]);
    }


    clearVertexBuffers() {
        const gl = this.gl;

        gl.bindVertexArray(null);
        gl.bindBuffer(gl.ARRAY_BUFFER, null);

    }

    clearVertexIndexBuffers() {
        const gl = this.gl;

        gl.bindVertexArray(null);
        gl.bindBuffer(gl.ARRAY_BUFFER, null);
        gl.bindBuffer(gl.ELEMENT_ARRAY_BUFFER, null);
    }


    // buffer methods


    createBuffer(bufferId) {
        const gl = this.gl;
        this.bufferStorage[bufferId] = gl.createBuffer();
    }


    createBindBufferData(bufferId, bufferType, bufferUsage, storageArrayId) {
        const gl = this.gl;

        this.bufferStorage[bufferId] = gl.createBuffer();
        gl.bindBuffer(bufferType, this.bufferStorage[bufferId]);

        gl.bufferData(bufferType, this.typedArrayStorage[storageArrayId].array, bufferUsage);

    }

    bindBuffer(bufferId, bufferType) {
        const gl = this.gl;

        gl.bindBuffer(bufferType, this.bufferStorage[bufferId]);
    }

    bufferData(storageArrayId, bufferType, bufferUsage) {
        const gl = this.gl;

        gl.bufferData(bufferType, this.typedArrayStorage[storageArrayId].array, bufferUsage);
    }


    setProgramAttributes(programId, attributeIdArray) {
        const gl = this.gl;
        const program = this.programStorage[programId];

        attributeIdArray.forEach(attributeId => {
            program.attributeLocations[attributeId] = gl.getAttribLocation(program, attributeId);
        });
    }

    vertexAttribPointer(programId, AttributeId, size, pointerType, normalized, stride, offset) {
        const gl = this.gl;
        const program = this.programStorage[programId];

        gl.vertexAttribPointer(program.attributeLocations[AttributeId], size, pointerType, normalized, stride, offset);
    }

    enableVertexAttribArray(programId, AttributeId) {
        const gl = this.gl;
        const program = this.programStorage[programId];

        gl.enableVertexAttribArray(program.attributeLocations[AttributeId]);
    }

    disableVertexAttribArray(programId, AttributeId) {
        const gl = this.gl;
        const program = this.programStorage[programId];

        gl.disableVertexAttribArray(program.attributeLocations[AttributeId]);
    }

    createAttributeLocation(programId, AttributeId) {
        const gl = this.gl;
        const program = this.programStorage[programId];

        program.attributeLocations[AttributeId] = gl.getAttribLocation(program, AttributeId);
    }

    // uniform methods

    setProgramUniforms(programId, uniformIdArray) {
        const gl = this.gl;
        const program = this.programStorage[programId];

        uniformIdArray.forEach(uniformId => {
            program.uniformLocations[uniformId] = this.gl.getUniformLocation(program, uniformId);
        });
    }

    createUniformLocation(programId, uniformId) {
        const gl = this.gl;
        const program = this.programStorage[programId];

        program.uniformLocations[uniformId] = gl.getUniformLocation(program, uniformId);
    }


    uniform1f(programId, uniformId, value) {
        const gl = this.gl;
        const program = this.programStorage[programId];
        const ulocation = program.uniformLocations[uniformId];
        gl.uniform1f(ulocation, value);
    }

    uniform2fv(programId, uniformId, valueArray, offset = null, length = null) {
        const gl = this.gl;
        const program = this.programStorage[programId];
        const ulocation = program.uniformLocations[uniformId];
        gl.uniform2fv(ulocation, valueArray, offset, length);
    }

    uniform3fv(programId, uniformId, valueArray, offset = null, length = null) {
        const gl = this.gl;
        const program = this.programStorage[programId];
        const ulocation = program.uniformLocations[uniformId];
        gl.uniform3fv(ulocation, valueArray, offset, length);
    }


    uniform4fv(programId, uniformId, valueArray, offset = null, length = null) {
        const gl = this.gl;
        const program = this.programStorage[programId];
        const ulocation = program.uniformLocations[uniformId];
        gl.uniform4fv(ulocation, valueArray, offset, length);
    }

    uniformMatrix2fv(programId, uniformId, transpose, matrixStorageId, matrixId) {
        const gl = this.gl;
        const program = this.programStorage[programId];
        const ulocation = program.uniformLocations[uniformId];
        gl.uniformMatrix2fv(ulocation, transpose, this.matrixStorage[matrixStorageId][matrixId]);
    }

    uniformMatrix3fv(programId, uniformId, transpose, matrixStorageId, matrixId) {
        const gl = this.gl;
        const program = this.programStorage[programId];
        const ulocation = program.uniformLocations[uniformId];
        gl.uniformMatrix3fv(ulocation, transpose, this.matrixStorage[matrixStorageId][matrixId]);
    }


    uniformMatrix4fv(programId, uniformId, transpose, matrixStorageId, matrixId) {
        const gl = this.gl;
        const program = this.programStorage[programId];
        const ulocation = program.uniformLocations[uniformId];
        gl.uniformMatrix4fv(ulocation, transpose, this.matrixStorage[matrixStorageId][matrixId]);
    }

    // draw methods

    drawAllElements(storageArrayId, mode) {
        const gl = this.gl;
        const storageArray = this.typedArrayStorage[storageArrayId];

        gl.drawElements(mode, storageArray.arrayLength, storageArray.arrayType, 0);
    }

    drawElements(storageArrayId, mode, offset, count) {
        const gl = this.gl;
        const storageArray = this.typedArrayStorage[storageArrayId];

        gl.drawElements(mode, count, storageArray.arrayType, offset * storageArray.elementByteSize);
    }

    drawRangeElements(storageArrayId, mode, start, end, offset) {
        const gl = this.gl;
        const storageArray = this.typedArrayStorage[storageArrayId];

        gl.drawRangeElements(mode, start, end, storageArray.arrayType, offset * storageArray.elementByteSize);
    }


    drawAllArrays(storageArrayId, mode) {
        const gl = this.gl;
        const storageArray = this.typedArrayStorage[storageArrayId];

        gl.drawArrays(mode, 0, storageArray.arrayLength / 3); // number of verities rather than number of elements
    }

    // scene methods

    createScene(sceneId, programId) {
        this.sceneStorage[sceneId] = new WebGLScene(this, programId);
        // we assume if we crate a new scene it automatically becomes are working scene. 
        // If we are working with multiple threads we can only build scenes in a single thread at a time.
        this.workingScene = this.sceneStorage[sceneId];
        return this.sceneStorage[sceneId];
    }

    deleteScene(sceneId) {

    }

    addLight(sceneId, light) {

        this.sceneStorage[sceneId].addLight(light);

    }

    emptyScene(sceneId) {
        // probably should stop drawing if this is the currently animated scene.
        this.sceneStorage[sceneId].emptyScene();
    }

    switchWorkingScene(sceneId) {
        this.workingScene = this.sceneStorage[SceneId];
    }


    // matrix ops!, we can always change the library

    // matricies are related to a common storage identifier
    createStandardizedMatrixStorage(matrixStorageId) {

        this.matrixStorage[matrixStorageId] = [];

        // create standard storage matricies for a camera
        this.matrixStorage[matrixStorageId].modelViewMatrix = mat4.create();
        this.matrixStorage[matrixStorageId].projectionMatrix = mat4.create();
        this.matrixStorage[matrixStorageId].normalMatrix = mat4.create();

    }


    createMatrix2(matrixStorageId, matrixId) {
        if (!this.matrixStorage[matrixStorageId]) {
            this.matrixStorage[matrixStorageId] = [];
        }
        this.matrixStorage[matrixStorageId][matrixId] = mat2.create();
    }

    setIdentity2(matrixStorageId, matrix2Id) {
        mat2.identity(this.matrixStorage[matrixStorageId][matrix2Id]);
    }



    createMatrix3(matrixStorageId, matrixId) {
        if (!this.matrixStorage[matrixStorageId]) {
            this.matrixStorage[matrixStorageId] = [];
        }
        this.matrixStorage[matrixStorageId][matrixId] = mat3.create();
    }


    setIdentity3(matrixStorageId, matrix3Id) {
        mat3.identity(this.matrixStorage[matrixStorageId][matrix3Id]);
    }



    createMatrix4(matrixStorageId, matrixId) {
        if (!this.matrixStorage[matrixStorageId]) {
            this.matrixStorage[matrixStorageId] = [];
        }
        this.matrixStorage[matrixStorageId][matrixId] = mat4.create();
    }

    perspective4(matrixStorageId, matrixIdOut, fovy, aspect, near, far) {
        mat4.perspective(this.matrixStorage[matrixStorageId][matrixIdOut], fovy, aspect, near, far);
    }

    setIdentity4(matrixStorageId, matrix4Id) {
        mat4.identity(this.matrixStorage[matrixStorageId][matrix4Id]);
    }

    translate4(matrixStorageId, matrix4IdOut, matrix4IdIn, delta3) {
        mat4.translate(this.matrixStorage[matrixStorageId][matrix4IdOut], this.matrixStorage[matrixStorageId][matrix4IdIn], delta3)
    }


    // storage methods for WebGL/JavaScript built in Typed Arrays

    deleteStorage(storageArrayId) {
        const storage = this.typedArrayStorage.get(storageArrayId);
        const index = this.typedArrayStorage.indexOf(storage);
        this.typedArrayStorage.splice(index, 1);
        storage = null; // release the memory?
    }


    createInt8Array(storageArrayId, values) {
        if (Array.isArray(values) && Array.isArray(values[0])) {
            values = values[0];
        }
        this.typedArrayStorage[storageArrayId] = new TypedArrayStorage(new Int8Array(values), this.gl.BYTE, values.length, 1);
    }

    createInt16Array(storageArrayId, values) {
        if (Array.isArray(values) && Array.isArray(values[0])) {
            values = values[0];
        }
        this.typedArrayStorage[storageArrayId] = new TypedArrayStorage(new Int16Array(values), this.gl.SHORT, values.length, 2);
    }

    createInt32Array(storageArrayId, values) {
        if (Array.isArray(values) && Array.isArray(values[0])) {
            values = values[0];
        }
        this.typedArrayStorage[storageArrayId] = new TypedArrayStorage(new Int32Array(values), this.gl.INT, values.length, 4);
    }

    createBigInt64Array(storageArrayId, values) {
        if (Array.isArray(values) && Array.isArray(values[0])) {
            values = values[0];
        }
        this.typedArrayStorage[storageArrayId] = new TypedArrayStorage(new BigInt64Array(values), this.gl.INT64, values.length, 8);
    }

    createFloat32Array(storageArrayId, values) {
        if (Array.isArray(values) && Array.isArray(values[0])) {
            values = values[0];
        }
        this.typedArrayStorage[storageArrayId] = new TypedArrayStorage(new Float32Array(values), this.gl.FLOAT, values.length, 4);
    }

    createFloat64Array(storageArrayId, values) {
        if (Array.isArray(values) && Array.isArray(values[0])) {
            values = values[0];
        }
        this.typedArrayStorage[storageArrayId] = new TypedArrayStorage(new Float64Array(values), this.gl.FLOAT64, values.length, 8);
    }

    createUint8Array(storageArrayId, values) {
        if (Array.isArray(values) && Array.isArray(values[0])) {
            values = values[0];
        }
        this.typedArrayStorage[storageArrayId] = new TypedArrayStorage(new Uint8Array(values), this.gl.UNSIGNED_BYTE, values.length, 1);
    }

    createUint8ClampedArray(storageArrayId, values) {
        if (Array.isArray(values) && Array.isArray(values[0])) {
            values = values[0];
        }
        this.typedArrayStorage[storageArrayId] = new TypedArrayStorage(new Uint8ClampedArray(values), this.gl.UNSIGNED_BYTE, values.length, 1);
    }

    createUint16Array(storageArrayId, values) {
        if (Array.isArray(values) && Array.isArray(values[0])) {
            values = values[0];
        }
        this.typedArrayStorage[storageArrayId] = new TypedArrayStorage(new Uint16Array(values), this.gl.UNSIGNED_SHORT, values.length, 2);
    }

    createUint32Array(storageArrayId, values) {
        if (Array.isArray(values) && Array.isArray(values[0])) {
            values = values[0];
        }
        this.typedArrayStorage[storageArrayId] = new TypedArrayStorage(new Uint32Array(values), this.gl.UNSIGNED_INT, values.length, 4);
    }

    createBigUint64Array(storageArrayId, values) {
        if (Array.isArray(values) && Array.isArray(values[0])) {
            values = values[0];
        }
        this.typedArrayStorage[storageArrayId] = new TypedArrayStorage(new BigUint64Array(values), this.gl.UNSIGNED_INT64, values.length, 8);
    }

}


// this class to simplify management of typed arrays that WebGL uses for rendering. While seemingly random to include this class here it makes the script complete.
export class TypedArrayStorage {
    constructor(typedArrayData, arrayType, arrayLength, elementByteSize) {
        this.array = typedArrayData;
        this.arrayType = arrayType;
        this.arrayLength = arrayLength;
        this.elementByteSize = elementByteSize;
    }
}
