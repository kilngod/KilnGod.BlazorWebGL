using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Numerics;

namespace KilnGod.BlazorWebGL.WebGL3D
{
#nullable enable
    public static class WebGLCanvasExtensions
    {
        public async static Task viewport(this WebGLCanvas webglCanvas, Rectangle viewport) => await webglCanvas.SetFunctionWebGLContext("viewport", viewport.X, viewport.Y, viewport.Width, viewport.Height);

        public async static Task viewport(this WebGLCanvas webglCanvas, int X, int Y, int Width, int Height) => await webglCanvas.SetFunctionWebGLContext("viewport", X, Y, Width, Height);

        public async static Task clear(this WebGLCanvas webglCanvas, BufferMask clear) => await webglCanvas.SetFunctionWebGLContext("clear", clear);

        public async static Task clearViewport(this WebGLCanvas webglCanvas, BufferMask clear) => await webglCanvas.SetFunctionWebGLBasis("clearViewport", clear);

        public async static Task clearColor(this WebGLCanvas webglCanvas, Color color) => await webglCanvas.SetFunctionWebGLContext("clearColor", color.toGLRed(), color.toGLGreen(), color.toGLBlue(), color.toGLAlpha());

        public async static Task clearColor(this WebGLCanvas webglCanvas, GLColor color) => await webglCanvas.SetFunctionWebGLContext("clearColor", color.R, color.G, color.B, color.A);

        public async static Task clearDepth(this WebGLCanvas webglCanvas, float depth) => await webglCanvas.SetFunctionWebGLContext("clearDepth", depth);

        public async static Task depthFunc(this WebGLCanvas webglCanvas, CompareFunction depthFunc) => await webglCanvas.SetFunctionWebGLContext("depthFunc", depthFunc);

        public async static Task<int> drawingBufferHeight(this WebGLCanvas webglCanvas) => await webglCanvas.GetFunctionWebGLContext<int>("drawingBufferHeight");

        public async static Task<int> drawingBufferWidth(this WebGLCanvas webglCanvas) => await webglCanvas.GetFunctionWebGLContext<int>("drawingBufferWidth");

        public async static Task enable(this WebGLCanvas webglCanvas, Enable enable) => await webglCanvas.SetFunctionWebGLContext("enable", enable);




        public async static Task flush(this WebGLCanvas webglCanvas) => await webglCanvas.SetFunctionWebGLContext("flush");

        public async static Task finish(this WebGLCanvas webglCanvas) => await webglCanvas.SetFunctionWebGLContext("finish");

        public async static Task clearStencil(this WebGLCanvas webglCanvas, StencilParameter value = 0) => await webglCanvas.SetFunctionWebGLContext("clearStencil", value);

        public async static Task blendFunc(this WebGLCanvas webglCanvas, BlendFactor sfactor, BlendFactor dfactor) => await webglCanvas.SetFunctionWebGLContext("blendFunc", sfactor, dfactor);

        public async static Task drawArrays(this WebGLCanvas webglCanvas, DrawMode drawMode, int first, int vertexCount) => await webglCanvas.SetFunctionWebGLContext("drawArrays", drawMode, first, vertexCount);

        public async static Task drawArraysInstanced(this WebGLCanvas webglCanvas, DrawMode drawMode, int first, int vertexCount, int instanceCount) => await webglCanvas.SetFunctionWebGLContext("drawArraysInstanced", drawMode, first, vertexCount, instanceCount);


        public async static Task drawElements(this WebGLCanvas webglCanvas, DrawMode drawMode, int count, NumberType type, int byteOffset) => await webglCanvas.SetFunctionWebGLContext("drawElements", drawMode, count, type, byteOffset);

        public async static Task drawRangeElements(this WebGLCanvas webglCanvas, DrawMode drawMode, int start, int end, NumberType type, int byteOffset) => await webglCanvas.SetFunctionWebGLContext("drawElements", drawMode, start, end, type, byteOffset);

        public async static Task drawElementsInstanced(this WebGLCanvas webglCanvas, DrawMode drawMode, int count, NumberType type, int byteOffset, int instanceCount) => await webglCanvas.SetFunctionWebGLContext("drawElementsInstanced", drawMode, count, type, byteOffset, instanceCount);


        public async static Task<bool> getParameterBool(this WebGLCanvas webglCanvas, EnumParametersBool pname) => await webglCanvas.GetValueWebGLContext<bool>("getParameter", pname);
        public async static Task<bool[]> getParameterBoolArray(this WebGLCanvas webglCanvas, int pname) => await webglCanvas.GetValueWebGLContext<bool[]>("getParameter", pname);
        public async static Task<int> getParameterInt(this WebGLCanvas webglCanvas, EnumParametersInt pname) => await webglCanvas.GetValueWebGLContext<int>("getParameter", pname);
        public async static Task<int[]> getParameterIntArray(this WebGLCanvas webglCanvas, EnumParamterIntArray pname) => await webglCanvas.GetValueWebGLContext<int[]>("getParameter", pname);
        public async static Task<uint> getParameterUInt(this WebGLCanvas webglCanvas, EnumParametersUInt pname) => await webglCanvas.GetValueWebGLContext<uint>("getParameter", pname);
        public async static Task<uint[]> getParameterUIntArray(this WebGLCanvas webglCanvas, int pname) => await webglCanvas.GetValueWebGLContext<uint[]>("getParameter", pname);
        public async static Task<long> getParameterLong(this WebGLCanvas webglCanvas, EnumParametersLong pname) => await webglCanvas.GetValueWebGLContext<long>("getParameter", pname);
        public async static Task<float> getParameterFloat(this WebGLCanvas webglCanvas, EnumParametersFloat pname) => await webglCanvas.GetValueWebGLContext<float>("getParameter", pname);
        public async static Task<float[]> getParameterFloatArray(this WebGLCanvas webglCanvas, EnumParamterFloatArray pname) => await webglCanvas.GetValueWebGLContext<float[]>("getParameter", pname);
        public async static Task<string> getParameterString(this WebGLCanvas webglCanvas, EnumParametersString pname) => await webglCanvas.GetValueWebGLContext<String>("getParameter", pname);



        // objects to store things

        public async static Task createObject(this WebGLCanvas webglCanvas, string objectId) => await webglCanvas.SetFunctionWebGLBasis("createObject", objectId);

        public async static Task setObjectValue(this WebGLCanvas webglCanvas, string objectId, string valueId, params object?[]? args) => await webglCanvas.SetFunctionWebGLBasis("setObjectValue", objectId, valueId, args);






        // query methods 

        public async static Task createQuery(this WebGLCanvas webglCanvas, string queryId) => await webglCanvas.SetFunctionWebGLBasis("createQuery", queryId);
        public async static Task deleteQuery(this WebGLCanvas webglCanvas, string queryId) => await webglCanvas.SetFunctionWebGLBasis("deleteQuery", queryId);
        public async static Task<bool> isQuery(this WebGLCanvas webglCanvas, string queryId) => await webglCanvas.GetFunctionWebGLBasis<bool>("isQuery", queryId);
        public async static Task beginQuery(this WebGLCanvas webglCanvas, string queryId, EnumsQueryTarget target) => await webglCanvas.SetFunctionWebGLBasis("createQuery", target, queryId);
        public async static Task endQuery(this WebGLCanvas webglCanvas, EnumsQueryTarget target) => await webglCanvas.SetFunctionWebGLContext("createQuery", target);
        public async static Task<string> getQuery(this WebGLCanvas webglCanvas, string queryId, EnumsQueryTarget target, EnumsQuery pname) => await webglCanvas.GetFunctionWebGLBasis<string>("getQueryParameter", queryId, target, pname);
        public async static Task<bool> getQueryParameterAvailable(this WebGLCanvas webglCanvas, string queryId) => await webglCanvas.GetFunctionWebGLBasis<bool>("getQueryParameter", queryId, EnumsQueryResult.QUERY_RESULT_AVAILABLE);
        public async static Task<uint> getQueryParameter(this WebGLCanvas webglCanvas, string queryId) => await webglCanvas.GetFunctionWebGLBasis<uint>("getQueryParameter", queryId, EnumsQueryResult.QUERY_RESULT_AVAILABLE);



        // sampler methods
        public async static Task createSampler(this WebGLCanvas webglCanvas, string samplerId) => await webglCanvas.SetFunctionWebGLBasis("createSampler", samplerId);
        public async static Task deleteSampler(this WebGLCanvas webglCanvas, string samplerId) => await webglCanvas.SetFunctionWebGLBasis("deleteSampler", samplerId);
        public async static Task bindSampler(this WebGLCanvas webglCanvas, string samplerId) => await webglCanvas.SetFunctionWebGLBasis("bindSampler", samplerId);
        public async static Task<bool> isSampler(this WebGLCanvas webglCanvas, string samplerId) => await webglCanvas.GetFunctionWebGLBasis<bool>("isSampler", samplerId);
        public async static Task<int> getSamplerParameterInt(this WebGLCanvas webglCanvas, string samplerId, EnumSamplerInt value) => await webglCanvas.GetFunctionWebGLBasis<int>("getSamplerParameter", samplerId, value);
        public async static Task<float> getSamplerParameterFloat(this WebGLCanvas webglCanvas, string samplerId, EnumSamplerFloat value) => await webglCanvas.GetFunctionWebGLBasis<float>("getSamplerParameter", samplerId, value);
        public async static Task<bool> getSamplerParameterBool(this WebGLCanvas webglCanvas, string samplerId, EnumSamplerBool value) => await webglCanvas.GetFunctionWebGLBasis<bool>("getSamplerParameter", samplerId, value);
        public async static Task<uint> getSamplerParameterUint(this WebGLCanvas webglCanvas, string samplerId, EnumSamplerUInt value) => await webglCanvas.GetFunctionWebGLBasis<uint>("getSamplerParameter", samplerId, value);


        // renderbuffer methods
        public async static Task createRenderbuffer(this WebGLCanvas webglCanvas, string renderbufferId) => await webglCanvas.SetFunctionWebGLBasis("createRenderbuffer", renderbufferId);
        public async static Task deleteRenderbuffer(this WebGLCanvas webglCanvas, string renderbufferId) => await webglCanvas.SetFunctionWebGLBasis("deleteRenderbuffer", renderbufferId);
        public async static Task bindRenderbuffer(this WebGLCanvas webglCanvas, string renderbufferId) => await webglCanvas.SetFunctionWebGLContext("bindRenderbuffer", renderbufferId);
        public async static Task<bool> isRenderbuffer(this WebGLCanvas webglCanvas, string renderbufferId) => await webglCanvas.GetFunctionWebGLBasis<bool>("isRenderbuffer", renderbufferId);
        public async static Task<int> getRenderbufferParameter(this WebGLCanvas webglCanvas, RenderbufferParameter pname) => await webglCanvas.GetFunctionWebGLBasis<int>("getRenderbufferParameter", pname);
        public async static Task renderbufferStorage(this WebGLCanvas webglCanvas, RenderbufferFormat internalformat, int width, int height) => await webglCanvas.SetFunctionWebGLContext("renderbufferStorage", internalformat, width, height);


        // framebuffer methods

        public async static Task bindFramebuffer(this WebGLCanvas webglCanvas, string bufferId, BufferTargetType bufferType) => await webglCanvas.SetFunctionWebGLBasis("bindFramebuffer", bufferId, bufferType);

        public async static Task<int> checkFramebufferStatus(this WebGLCanvas webglCanvas, EnumFrameBuffer target) => await webglCanvas.GetFunctionWebGLBasis<int>("checkFramebufferStatus", target);

        public async static Task<int> getFramebufferAttachmentParameter(this WebGLCanvas webglCanvas, EnumFrameBuffer target, FramebufferAttachment attachment, FramebufferAttachmentParameter pname) => await webglCanvas.GetFunctionWebGLContext<int>("getFramebufferAttachmentParameter", target, attachment, pname);

        public async static Task readBuffer(this WebGLCanvas webglCanvas, FramebufferSource source) => await webglCanvas.SetFunctionWebGLContext("readBuffer", source);
        // source for subsequent ReadPixels, CopyTexImage2D, CopyTexSubImage2D, and CopyTexSubImage3D commands

        public async static Task invalidateFramebuffer(this WebGLCanvas webglCanvas, EnumFrameBuffer target, FramebufferAttachment attachments) => await webglCanvas.SetFunctionWebGLContext("invalidateFramebuffer", target, attachments);


        public async static Task invalidateSubFramebuffer(this WebGLCanvas webglCanvas, EnumFrameBuffer target, FramebufferAttachment attachments, int x, int y, int width, int height) => await webglCanvas.SetFunctionWebGLContext("invalidateSubFramebuffer", target, attachments, x, y, width, height);


        public async static Task blitFramebuffer(this WebGLCanvas webglCanvas, int srcX0, int srcY0, int srcX1, int srcY1, int dstX0, int dstY0, int dstX1, int dstY1, BufferMask mask, FramebufferFilter filter)
            => await webglCanvas.SetFunctionWebGLContext("blitFramebuffer", srcX0, srcY0, srcX1, srcY1, dstX0, dstY0, dstX1, dstY1, mask, filter);
        public async static Task framebufferTextureLayer(this WebGLCanvas webglCanvas, EnumFrameBuffer target, FramebufferAttachment attachment, string textureId, int level, int layer) => await webglCanvas.SetFunctionWebGLBasis("framebufferTextureLayer", target, attachment, textureId, level, layer);


        // textures - confusing texture are slotted into an enumeration of at least 8 slots up to 32 slots 
        //? activate textureId into slot, textures need to be fully wrapped objects, 
        public async static Task activeTexture(this WebGLCanvas webglCanvas, string textureId, TextureSlot slot) => await webglCanvas.SetFunctionWebGLBasis("activeTexture", textureId, slot);

        public async static Task createTexture(this WebGLCanvas webglCanvas, string textureId) => await webglCanvas.SetFunctionWebGLBasis("createTexture", textureId);

        public async static Task createBindTexture(this WebGLCanvas webglCanvas, TextureTarget target, string textureId) => await webglCanvas.SetFunctionWebGLBasis("createTexture", target, textureId);

        public async static Task bindTexture(this WebGLCanvas webglCanvas, TextureTarget target, string textureId) => await webglCanvas.SetFunctionWebGLBasis("bindTexture", target, textureId);

        public async static Task deleteTexture(this WebGLCanvas webglCanvas, string textureId) => await webglCanvas.SetFunctionWebGLBasis("createTexture", textureId);


        public async static Task isTexture(this WebGLCanvas webglCanvas, string textureId) => await webglCanvas.SetFunctionWebGLBasis("isTexture", textureId);

        public async static Task generateMipmap(this WebGLCanvas webglCanvas, TextureTarget target) => await webglCanvas.SetFunctionWebGLContext("generateMipmap", target);

        public async static Task<int> getTexParameter(this WebGLCanvas webglCanvas, TextureTarget target, TextureParameter pname) => await webglCanvas.GetFunctionWebGLContext<int>("getTexParameter", target, pname);

        public async static Task copyTexImage2D(this WebGLCanvas webglCanvas, Texture2DType target, int level, PixelFormat internalformat, int x, int y, int width, int height, int border) => await webglCanvas.SetFunctionWebGLContext("copyTexImage2D", target, level, internalformat, x, y, width, height, border);
        public async static Task copyTexSubImage2D(this WebGLCanvas webglCanvas, Texture2DType target, int level, int xoffset, int yoffset, int x, int y, int width, int height) => await webglCanvas.SetFunctionWebGLContext("copyTexSubImage2D", target, level, xoffset, yoffset, x, y, width, height);

        public async static Task texImage2D(this WebGLCanvas webglCanvas, Texture2DType target, int level, PixelFormat internalformat, int width, int height, int border, PixelType type, string storageArrayId) => await webglCanvas.SetFunctionWebGLBasis("texImage2D", target, level, internalformat, width, height, border, type, storageArrayId);
        public async static Task texImage2D(this WebGLCanvas webglCanvas, Texture2DType target, int level, PixelFormat internalformat, int width, int height, int border, PixelType type, string storageArrayId, int srcOffset) => await webglCanvas.SetFunctionWebGLBasis("texImage2D", target, level, internalformat, width, height, border, type, storageArrayId, srcOffset);
        public async static Task texImage2D(this WebGLCanvas webglCanvas, Texture2DType target, int level, PixelFormat internalformat, PixelType type, string imageID) => await webglCanvas.SetFunctionWebGLBasis("texImage2D", target, level, internalformat, type, imageID);

        public async static Task texSubImage2D(this WebGLCanvas webglCanvas, Texture2DType target, int level, int xoffset, int yoffset, PixelFormat format, PixelType type, string imageID) => await webglCanvas.SetFunctionWebGLBasis("texSubImage2D", target, level, format, type, imageID);
        public async static Task texSubImage2D(this WebGLCanvas webglCanvas, Texture2DType target, int level, int xoffset, int yoffset, int width, int height, PixelFormat format, PixelType type, string storageArrayId) => await webglCanvas.SetFunctionWebGLBasis("texSubImage2D", target, level, xoffset, yoffset, width, height, format, type, storageArrayId);


        /* // WebGL does not support compressed textures from OpenGL 3.0
        public async static Task compressedTexImage2D(Texture2DType target, int level, PixelFormat internalformat, int width, int height, int border, [AllowShared] ArrayBufferView pixels) { }
        public async static Task compressedTexSubImage2D(Texture2DType target, int level, int xoffset, int yoffset, int width, int height, PixelFormat format, [AllowShared] ArrayBufferView pixels) { }
        */



        // shaders and programs

        public async static Task createShader(this WebGLCanvas webglCanvas, string shaderId, ShaderType shaderType, string shaderCode) => await webglCanvas.SetFunctionWebGLBasis("createShader", shaderId, shaderType, shaderCode);

        public async static Task createProgram(this WebGLCanvas webglCanvas, string programId) => await webglCanvas.SetFunctionWebGLBasis("createProgram", programId);

        public async static Task attachShaderProgram(this WebGLCanvas webglCanvas, string programId, string shaderId) => await webglCanvas.SetFunctionWebGLBasis("attachShaderProgram", programId, shaderId);

        public async static Task linkProgram(this WebGLCanvas webglCanvas, string programId, string[] shaderIdArray) => await webglCanvas.SetFunctionWebGLBasis("linkProgram", programId, shaderIdArray);

        public async static Task useProgram(this WebGLCanvas webglCanvas, string programId) => await webglCanvas.SetFunctionWebGLBasis("useProgram", programId);

        public async static Task createScene(this WebGLCanvas webGLCanvas, string sceneId, string programId) => await webGLCanvas.SetFunctionWebGLBasis("createScene", sceneId, programId);

        public async static Task createAttributeLocation(this WebGLCanvas webglCanvas, string programId, string locationId) => await webglCanvas.SetFunctionWebGLBasis("createAttributeLocation", programId, locationId);

        public async static Task createUniformLocation(this WebGLCanvas webglCanvas, string programId, string locationId) => await webglCanvas.SetFunctionWebGLBasis("createUniformLocation", programId, locationId);



        // create and pass  
        public async static Task createFloat32Array(this WebGLCanvas webglCanvas, string storageArrayId, params object?[]? args) => await webglCanvas.SetFunctionWebGLBasis("createFloat32Array", storageArrayId, args);

        public async static Task createFloat64Array(this WebGLCanvas webglCanvas, string storageArrayId, params object?[]? args) => await webglCanvas.SetFunctionWebGLBasis("createFloat64Array", storageArrayId, args);

        public async static Task createUint8Array(this WebGLCanvas webglCanvas, string storageArrayId, params object?[]? args) => await webglCanvas.SetFunctionWebGLBasis("createUint8Array", storageArrayId, args);

        public async static Task createUint8ClampedArray(this WebGLCanvas webglCanvas, string storageArrayId, params object?[]? args) => await webglCanvas.SetFunctionWebGLBasis("Uint8ClampedArray", storageArrayId, args);

        public async static Task createUint16Array(this WebGLCanvas webglCanvas, string storageArrayId, params object?[]? args) => await webglCanvas.SetFunctionWebGLBasis("createUint16Array", storageArrayId, args);

        public async static Task createUint32Array(this WebGLCanvas webglCanvas, string storageArrayId, params object?[]? args) => await webglCanvas.SetFunctionWebGLBasis("Uint32Array", storageArrayId, args);

        public async static Task createInt16Array(this WebGLCanvas webglCanvas, string storageArrayId, params object?[]? args) => await webglCanvas.SetFunctionWebGLBasis("createInt16Array", storageArrayId, args);

        public async static Task createInt32Array(this WebGLCanvas webglCanvas, string storageArrayId, params object?[]? args) => await webglCanvas.SetFunctionWebGLBasis("createInt32Array", storageArrayId, args);

        public async static Task createInt64Array(this WebGLCanvas webglCanvas, string storageArrayId, params object?[]? args) => await webglCanvas.SetFunctionWebGLBasis("createInt64Array", storageArrayId, args);


        // vertex 

        public async static Task createVertexArray(this WebGLCanvas webglCanvas, string vertexArrayId) => await webglCanvas.SetFunctionWebGLBasis("createVertexArray", vertexArrayId);
        public async static Task createBindVertextArray(this WebGLCanvas webglCanvas, string vertextArrayId) => await webglCanvas.SetFunctionWebGLBasis("createBindVertextArray", vertextArrayId);
        public async static Task bindVertexArray(this WebGLCanvas webglCanvas, string vertextArrayId) => await webglCanvas.SetFunctionWebGLBasis("bindVertexArray", vertextArrayId);


        public async static Task clearVertexIndexBuffers(this WebGLCanvas webglCanvas) => await webglCanvas.SetFunctionWebGLBasis("clearVertexIndexBuffers");

        public async static Task vertexAttribPointer(this WebGLCanvas webglCanvas, string progId, string vertextPositionId, int size, NumberType pointerType, bool normalized, int stride, int offset) => await webglCanvas.SetFunctionWebGLBasis("vertexAttribPointer", progId, vertextPositionId, size, pointerType, normalized, stride, offset);


        public async static Task enableVertexAttribArray(this WebGLCanvas webglCanvas, string progId, string vertextPositionId) => await webglCanvas.SetFunctionWebGLBasis("enableVertexAttribArray", progId, vertextPositionId);

        public async static Task disableVertexAttribArray(this WebGLCanvas webglCanvas, int index) => await webglCanvas.SetFunctionWebGLBasis("disableVertexAttribArray", index);





        // buffers

        public async static Task createBindBufferData(this WebGLCanvas webglCanvas, string bufferId, BufferTargetType bufferType, BufferUsage bufferUsage, string storageArrayId) => await webglCanvas.SetFunctionWebGLBasis("createBindBufferData", bufferId, bufferType, bufferUsage, storageArrayId);


        public async static Task createBuffer(this WebGLCanvas webglCanvas, string bufferId) => await webglCanvas.SetFunctionWebGLBasis("createBuffer", bufferId);


        public async static Task bindBuffer(this WebGLCanvas webglCanvas, string bufferId, BufferTargetType bufferType) => await webglCanvas.SetFunctionWebGLBasis("bindBuffer", bufferId, bufferType);



        public async static Task bufferData(this WebGLCanvas webglCanvas, string storageArrayId, BufferTargetType bufferType, BufferUsage bufferUsage) => await webglCanvas.SetFunctionWebGLBasis("bufferData", storageArrayId, bufferType, bufferUsage);


        // uniforms

        public async static Task uniformMatrix4fv(this WebGLCanvas webglCanvas, string progId, string uProjectionMatrixId, bool transpose, string matrixStorageId, string projectionMatrixId) => await webglCanvas.SetFunctionWebGLBasis("uniformMatrix4fv", progId, uProjectionMatrixId, transpose, matrixStorageId, projectionMatrixId);

        public async static Task<bool> getUniformBool(this WebGLCanvas webglCanvas, string progId, string uniformId) => await webglCanvas.GetFunctionWebGLBasis<bool>(progId, uniformId);
        public async static Task<int> getUniformInt(this WebGLCanvas webglCanvas, string progId, string uniformId) => await webglCanvas.GetFunctionWebGLBasis<int>(progId, uniformId);

        public async static Task<float> getUniformFloat(this WebGLCanvas webglCanvas, string progId, string uniformId) => await webglCanvas.GetFunctionWebGLBasis<float>(progId, uniformId);

        public async static Task<bool[]> getUniformBoolArray(this WebGLCanvas webglCanvas, string progId, string uniformId) => await webglCanvas.GetFunctionWebGLBasis<bool[]>(progId, uniformId);

        public async static Task<int[]> getUniformIntArray(this WebGLCanvas webglCanvas, string progId, string uniformId) => await webglCanvas.GetFunctionWebGLBasis<int[]>(progId, uniformId);

        public async static Task<float[]> getUniformFloatArray(this WebGLCanvas webglCanvas, string progId, string uniformId) => await webglCanvas.GetFunctionWebGLBasis<float[]>(progId, uniformId);


        // draw methods


        public async static Task drawAllElements(this WebGLCanvas webglCanvas, string storageArrayId, DrawMode drawMode) => await webglCanvas.SetFunctionWebGLBasis("drawAllElements", storageArrayId, drawMode);

        public async static Task drawElements(this WebGLCanvas webglCanvas, string storageArrayId, DrawMode drawMode, int count, int offset) => await webglCanvas.SetFunctionWebGLBasis("drawElements", storageArrayId, drawMode, count, offset);

        public async static Task drawRangeElements(this WebGLCanvas webglCanvas, string storageArrayId, DrawMode drawMode, int start, int end, int offset) => await webglCanvas.SetFunctionWebGLBasis("drawRangeElements", storageArrayId, drawMode, start, end, offset);





        // matrix 

        public async static Task createMatrix4(this WebGLCanvas webglCanvas, string matrixStorageId, string matrix4Id) => await webglCanvas.SetFunctionWebGLBasis("createMatrix4", matrixStorageId, matrix4Id);


        public async static Task perspective4(this WebGLCanvas webglCanvas, string matrixStorageId, string matrixIdOut, float fovy, float aspect, float near, float far) => await webglCanvas.SetFunctionWebGLBasis("perspective4", matrixStorageId, matrixIdOut, fovy, aspect, near, far);


        public async static Task setIdentity4(this WebGLCanvas webglCanvas, string progId, string ArrayId) => await webglCanvas.SetFunctionWebGLBasis("setIdentity4", progId, ArrayId);

        public async static Task translate4(this WebGLCanvas webglCanvas, string matrixStorageId, string matrix4IdOut, string matrix4IdIn, float[] offset3) => await webglCanvas.SetFunctionWebGLBasis("translate4", matrixStorageId, matrix4IdOut, matrix4IdIn, offset3);

        public async static Task translate4(this WebGLCanvas webglCanvas, string matrixStorageId, string matrix4IdOut, string matrix4IdIn, Vector3 offset3) => await webglCanvas.SetFunctionWebGLBasis("translate4", matrixStorageId, matrix4IdOut, matrix4IdIn, new float[] { offset3.X, offset3.Y, offset3.Z });



        public async static Task createScenery(this WebGLCanvas webglCanvas, string sceneId, string objectId, params object?[]? args) => await webglCanvas.SetFunctionWebGLBasis("createScenery", sceneId, objectId, args);



    }
}
