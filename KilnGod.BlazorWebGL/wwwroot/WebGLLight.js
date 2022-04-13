
export class WebGLLight {
   // strict mode on by default in modules

    constructor(id) {
        this.id = id;
        this.position = [0, 0, 0];

        // We could use the OBJ convention here (e.g. Ka, Kd, Ks, etc.),
        // but decided to use more prescriptive terms here to showcase
        // both versions
        this.ambient = [0, 0, 0, 0];
        this.diffuse = [0, 0, 0, 0];
        this.specular = [0, 0, 0, 0];
    }

    setPosition(position) {
        this.position = position.slice(0);
    }

    setDiffuse(diffuse) {
        this.diffuse = diffuse.slice(0);
    }

    setAmbient(ambient) {
        this.ambient = ambient.slice(0);
    }

    setSpecular(specular) {
        this.specular = specular.slice(0);
    }

    setProperty(property, value) {
        this[property] = value;
    }

}


// Two defined modes for the camera
//Light.PROPERTYSET = ['position', 'diffuse', 'ambient', 'specular'];
//Light.PROPERTYSET.forEach(propertyset => Light[propertyset] = propertyset);




