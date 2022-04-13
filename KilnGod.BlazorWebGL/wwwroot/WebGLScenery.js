
export class WebGLScenery {
   // strict mode on by default in modules

    constructor(scene, jsonObject) {

        this.scene = scene;
        
        this.alias = jsonObject.alias;

        this.visible = true;
        if (jsonObject.visible==false) {
            this.visible = jsonObject.visible;
        }

        this.wireframe = false;
        if (jsonObject.wireframe) {
            this.wireframe = true;
        }
        if (jsonObject.ambient) {
            this.ambient = jsonObject.ambient ? jsonObject.ambient : [1,1,1,1];
        }
        if (jsonObject.diffuse) {
            this.diffuse = jsonObject.diffuse;
        }

        this.diffuse = jsonObject.diffuse ? jsonObject.diffuse : [1,1,1,1];
        if (jsonObject.specular) {
            this.specular = jsonObject.specular;
        }

        if (jsonObject.indices) {
            this.indicesStorageId = this.alias + "_indicesArray";
            scene.createUint16Array(this.indicesStorageId, jsonObject.indices);
        }

        if (jsonObject.vertices) {
            this.verticesStorageId = this.alias + "_verticesArray";
            scene.createFloat32Array(this.verticesStorageId, jsonObject.vertices);
        }

        if (jsonObject.normals) {
            this.normalsStorageId = this.alias + "_normalsArray";
            scene.createFloat32Array(this.normalsStorageId, jsonObject.normals);
        }
        else if (jsonObject.vertices && jsonObject.indices){
            // lets try to calculate normals
            try {
                const normals = this.calculateNormals(jsonObject.vertices, jsonObject.indices);
                this.normalsStorageId = this.alias + "_normalsArray";
                scene.createFloat32Array(this.normalsStorageId, normals);
            }
            catch (err) { } // try to calculate normals but its okay to blowup
        }

        if (jsonObject.scalars) {
            this.scalarsStorageId = this.alias + "_scalarsArray";
            scene.createFloat32Array(this.scalarsStorageId, jsonObject.scalars);
        }

        if (jsonObject.textureCoords) {
            this.textureCoordsStorageId = this.alias + "_textureCoordsArray";
            scene.createFloat32Array(this.textureCoordsStorageId, jsonObject.textureCoords);


            if (jsonObject.tangents) {
                this.tangentsStorageId = this.alias + "_tangentsArray";
                scene.createFloat32Array(this.tangentsStorageId, jsonObject.tangents);
            }
            else {
                const tangents = this.calculateTangents(jsonObject.verticies, jsonObject.textureCoords, jsonObject.indices);
                this.tangentsStorageId = this.alias + "_tangentsArray";
                scene.createFloat32Array(this.tangentsStorageId, tangents);
            }

        }

       


        if (jsonObject.image) {
            this.image = jsonObject.image;
        }

        // initialze values
       
        this.diffuse = jsonObject.diffuse || [1, 1, 1, 1];
        this.Kd = this.Kd || this.diffuse.slice(0, 3);


    
        this.ambient = jsonObject.ambient || [0.2, 0.2, 0.2, 1];
        this.Ka = this.Ka || this.ambient.slice(0, 3);
    

        if (jsonObject.specular) {
            this.specular = jsonObject.specular;
            this.Ks = this.Ks || this.specular.slice(0, 3);
        }

        if (jsonObject.specularExponent) {
            this.specularExponent = jsonObject.specularExponent;
            this.Ns = this.Ns || this.specularExponent;
        }

        if (jsonObject.transparency) {
            this.transparency = jsonObject.transparency;
            this.d = this.d || this.transparency;
        }

        if (jsonObject.illum) {
            this.illum = jsonObject.illum;
        }

        /*
        this.diffuse = jsonObject.diffuse || [1, 1, 1, 1];
        this.Kd = this.Kd || this.diffuse.slice(0, 3);

        this.ambient = jsonObject.ambient || [0.2, 0.2, 0.2, 1];
        this.Ka = this.Ka || this.ambient.slice(0, 3);

        this.specular = jsonObject.specular || [1, 1, 1, 1];
        this.Ks = this.Ks || this.specular.slice(0, 3);

        this.specularExponent = jsonObject.specularExponent || 0;
        this.Ns = this.Ns || this.specularExponent;

        this.d = this.d || 1;
        this.transparency = jsonObject.transparency || this.d;

        this.illum = jsonObject.illum || 1;
        */
        scene.sceneryStorage[this.alias] = this;

        return this;
    }



    // Returns computed normals for provided vertices.
    // Note: Indices have to be completely defined--NO TRIANGLE_STRIP only TRIANGLES.
    calculateNormals(vs, ind) {
        const
            x = 0,
            y = 1,
            z = 2,
            ns = [];

        // For each vertex, initialize normal x, normal y, normal z
        for (let i = 0; i < vs.length; i += 3) {
            ns[i + x] = 0.0;
            ns[i + y] = 0.0;
            ns[i + z] = 0.0;
        }

        // We work on triads of vertices to calculate
        for (let i = 0; i < ind.length; i += 3) {
            // Normals so i = i+3 (i = indices index)
            const v1 = [], v2 = [], normal = [];

            // p2 - p1
            v1[x] = vs[3 * ind[i + 2] + x] - vs[3 * ind[i + 1] + x];
            v1[y] = vs[3 * ind[i + 2] + y] - vs[3 * ind[i + 1] + y];
            v1[z] = vs[3 * ind[i + 2] + z] - vs[3 * ind[i + 1] + z];

            // p0 - p1
            v2[x] = vs[3 * ind[i] + x] - vs[3 * ind[i + 1] + x];
            v2[y] = vs[3 * ind[i] + y] - vs[3 * ind[i + 1] + y];
            v2[z] = vs[3 * ind[i] + z] - vs[3 * ind[i + 1] + z];

            // Cross product by Sarrus Rule
            normal[x] = v1[y] * v2[z] - v1[z] * v2[y];
            normal[y] = v1[z] * v2[x] - v1[x] * v2[z];
            normal[z] = v1[x] * v2[y] - v1[y] * v2[x];

            // Update the normals of that triangle: sum of vectors
            for (let j = 0; j < 3; j++) {
                ns[3 * ind[i + j] + x] = ns[3 * ind[i + j] + x] + normal[x];
                ns[3 * ind[i + j] + y] = ns[3 * ind[i + j] + y] + normal[y];
                ns[3 * ind[i + j] + z] = ns[3 * ind[i + j] + z] + normal[z];
            }
        }

        // Normalize the result.
        // The increment here is because each vertex occurs.
        for (let i = 0; i < vs.length; i += 3) {
            // With an offset of 3 in the array (due to x, y, z contiguous values)
            const nn = [];
            nn[x] = ns[i + x];
            nn[y] = ns[i + y];
            nn[z] = ns[i + z];

            let len = Math.sqrt((nn[x] * nn[x]) + (nn[y] * nn[y]) + (nn[z] * nn[z]));
            if (len === 0) len = 1.0;

            nn[x] = nn[x] / len;
            nn[y] = nn[y] / len;
            nn[z] = nn[z] / len;

            ns[i + x] = nn[x];
            ns[i + y] = nn[y];
            ns[i + z] = nn[z];
        }

        return ns;
    }


    // Calculate tangets for a given set of vertices
    calculateTangents(vs, tc, ind) {
        const tangents = [];

        for (let i = 0; i < vs.length / 3; i++) {
            tangents[i] = [0, 0, 0];
        }

        let
            a = [0, 0, 0],
            b = [0, 0, 0],
            triTangent = [0, 0, 0];

        for (let i = 0; i < ind.length; i += 3) {
            const i0 = ind[i];
            const i1 = ind[i + 1];
            const i2 = ind[i + 2];

            const pos0 = [vs[i0 * 3], vs[i0 * 3 + 1], vs[i0 * 3 + 2]];
            const pos1 = [vs[i1 * 3], vs[i1 * 3 + 1], vs[i1 * 3 + 2]];
            const pos2 = [vs[i2 * 3], vs[i2 * 3 + 1], vs[i2 * 3 + 2]];

            const tex0 = [tc[i0 * 2], tc[i0 * 2 + 1]];
            const tex1 = [tc[i1 * 2], tc[i1 * 2 + 1]];
            const tex2 = [tc[i2 * 2], tc[i2 * 2 + 1]];

            vec3.subtract(a, pos1, pos0);
            vec3.subtract(b, pos2, pos0);

            const c2c1b = tex1[1] - tex0[1];
            const c3c1b = tex2[0] - tex0[1];

            triTangent = [c3c1b * a[0] - c2c1b * b[0], c3c1b * a[1] - c2c1b * b[1], c3c1b * a[2] - c2c1b * b[2]];

            vec3.add(triTangent, tangents[i0], triTangent);
            vec3.add(triTangent, tangents[i1], triTangent);
            vec3.add(triTangent, tangents[i2], triTangent);
        }

        // Normalize tangents
        const ts = [];
        tangents.forEach(tan => {
            vec3.normalize(tan, tan);
            ts.push(tan[0]);
            ts.push(tan[1]);
            ts.push(tan[2]);
        });

        return ts;
    }


    attachProgram(programId) {

        const scene = this.scene;

        const program = this.scene.webgl.programStorage[programId];

        const gl = this.scene.webgl.gl;



        // Indices

        if (this.indicesStorageId && scene.aVertexPosition in program.attributeLocations) {

            this.iboBufferStorageId = this.alias + '_ibo';

            scene.createBindBufferData(this.iboBufferStorageId, gl.ELEMENT_ARRAY_BUFFER, gl.STATIC_DRAW, this.indicesStorageId)
        }
        else {
         //   this.wireframe = true;
        }


        this.vaoId = this.alias + '_vao';

        this.scene.createBindVertextArray(this.vaoId);


        // Positions
        if (this.verticesStorageId && scene.aVertexPosition in program.attributeLocations) {
            this.vertexBufferObject = gl.createBuffer();
            this.vertexBufferStorageId = this.alias + '_vertexBuffer';
            scene.createBindBufferData(this.vertexBufferStorageId, gl.ARRAY_BUFFER, gl.STATIC_DRAW, this.verticesStorageId);

            scene.vertexAttribPointer(scene.aVertexPosition, 3, scene.webgl.typedArrayStorage[this.verticesStorageId].arrayType, false, 0, 0);
            scene.enableVertexAttribArray(scene.aVertexPosition);
        }

        // verticies
    


        // Normals
        if (this.normalsStorageId && scene.aVertexNormal in program.attributeLocations) {
            this.normalBufferObject = gl.createBuffer();

            this.normalBufferId = this.alias + '_normalBuffer';
            scene.createBindBufferData(this.normalBufferId, gl.ARRAY_BUFFER, gl.STATIC_DRAW, this.normalsStorageId);

            scene.vertexAttribPointer(scene.aVertexNormal, 3, scene.webgl.typedArrayStorage[this.normalsStorageId].arrayType, false, 0, 0);
            scene.enableVertexAttribArray(scene.aVertexNormal);


        }

        // Color Scalars
        if (this.scalarsStorageId && scene.aVertexColor in program.attributeLocations) {
            this.colorBufferObject = gl.createBuffer();
            this.scalarsBufferId = this.alias + '_scalarsBuffer';
            scene.createBindBufferData(this.scalarsBufferId, gl.ARRAY_BUFFER, gl.STATIC_DRAW, this.scalarsStorageId);

            scene.vertexAttribPointer(scene.aVertexColor, 4, this.scene.webgl.typedArrayStorage[this.scalarsStorageId].arrayType, false, 0, 0);
            scene.enableVertexAttribArray(scene.aVertexColor);

        }

        // Textures coordinates
        if (this.textureCoordsStorageId && scene.aVertexTextureCoords in program.attributeLocations) {
            this.textureBufferObject = gl.createBuffer();

            this.textureCoordsId = this.alias + '_textureCoordsBuffer';
            scene.createBindBufferData(this.textureCoordsId, gl.ARRAY_BUFFER, gl.STATIC_DRAW, this.textureCoordsStorageId);

            scene.vertexAttribPointer(scene.aVertexTextureCoords, 2, scene.webgl.typedArrayStorage[this.textureCoordsStorageId].arrayType, false, 0, 0);
            scene.enableVertexAttribArray(scene.aVertexTextureCoords);

 
        }

        // Tangents
        if (this.tangentsStorageId && scene.aVertexTangent in program.attributeLocations) {
            this.tangentBufferObject = gl.createBuffer();

            this.tangentBufferId = this.alias + '_tangentBuffer';
            scene.createBindBufferData(this.tangentBufferId, gl.ARRAY_BUFFER, gl.STATIC_DRAW, this.tangentsStorageId);

            scene.vertexAttribPointer(scene.aVertexTangent, 3, scene.webgl.typedArrayStorage[this.tangentsStorageId].arrayType, false, 0, 0);
            scene.enableVertexAttribArray(scene.aVertexTangent);

        }

        // Image texture
        if (this.image) {
            this.texture = new Texture(gl, this.image);
        }

        // Clean up
        this.scene.webgl.clearVertexIndexBuffers();
    }

    bindDrawClean() {
        const webgl = this.scene.webgl;
        const gl = webgl.gl;
        // Bind
        webgl.bindVertexArray(this.vaoId);

        
        let drawType = gl.TRIANGLES;
        if (this.wireframe) {
            drawType = gl.LINES;
        }
        // Draw, note STL files do not have index buffers and these would need to be computed if applicable. 
        if (this.iboBufferStorageId) {

            webgl.bindBuffer(this.iboBufferStorageId, gl.ELEMENT_ARRAY_BUFFER);

            webgl.drawAllElements(this.indicesStorageId, drawType)

            webgl.clearVertexIndexBuffers();
        }
        else
        {
            webgl.bindBuffer(this.vertexBufferStorageId, gl.ARRAY_BUFFER);

            webgl.drawAllArrays(this.verticesStorageId, gl.TRIANGLES);
          //  gl.drawArrays(gl.TRIANGLES, 0, webgl.typedArrayStorage[this.verticesStorageId].array.length/3);
            // Cleanup
            webgl.clearVertexBuffers();
        }
        

        
    }


    draw(cameraId, worldOffest) {
        const scene = this.scene;
        scene.calculateModelView(cameraId);
      //  scene.push(cameraId);


        if (worldOffest) {
            scene.translateModelView(cameraId, worldOffest);
        }
        

        scene.setMatrixUniforms(cameraId);
      //  scene.pop(cameraId);

        if (this.diffuse) {
            scene.uniform3fv(scene.uMaterialDiffuse, this.diffuse.slice(0,3));
        }
        if (this.ambient) {
            scene.uniform3fv(scene.uMaterialAmbient, this.ambient.slice(0, 3));
        }
        if (this.wireframe) {
            scene.uniform1i(scene.uWireframe, true);
        }
        else {
            scene.uniform1i(scene.uWireframe, false);
        }

        this.bindDrawClean();
        
    }

}