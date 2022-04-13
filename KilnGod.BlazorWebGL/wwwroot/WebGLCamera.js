import * as vec3 from "./vec3.js";
import * as vec4 from "./vec4.js";
import * as mat4 from "./mat4.js";
import { WebGLControls } from './WebGLControls.js';

export class WebGLCamera {
     // strict mode on by default in modules

    constructor(type = WebGLCamera.ORBITING_TYPE) {
        this.position = vec3.create();
        this.focus = vec3.create();
        this.home = vec3.create();

        this.up = vec3.create();
        this.right = vec3.create();
        this.normal = vec3.create();

        this.matrix = mat4.create();

        // You could have these options be passed in via the constructor
        // or allow the consumer to change them directly
        this.steps = 0;
        this.azimuth = 0;
        this.elevation = 0;
        this.fov = 45.0 * 3.141592/180.0;
        this.minZ = 0.1;
        this.maxZ = 10000;

        this.setType(type);

        this.controls = null;
    }


    addControls(webgl, sceneId) {
        this.controls = new WebGLControls(webgl, this, sceneId);
    }

    // Return whether the camera is in orbiting mode
    isOrbiting() {
        return this.type === WebGLCamera.ORBITING_TYPE;
    }

    // Return whether the camera is in tracking mode
    isTracking() {
        return this.type === WebGLCamera.TRACKING_TYPE;
    }

    // Change camera type
    setType(type) {
        ~WebGLCamera.TYPES.indexOf(type)
            ? this.type = type
            : console.error(`Camera type (${type}) not supported`);
    }

    // Position the camera back home
    goHome(home) {
        if (home) {
            this.home = home;
        }

        this.setPosition(this.home);
        this.setAzimuth(0);
        this.setElevation(0);
    }

    // Dolly the camera
    dolly(stepIncrement) {
        const normal = vec3.create();
        const newPosition = vec3.create();
        vec3.normalize(normal, this.normal);

        const step = stepIncrement - this.steps;

        if (this.isTracking()) {
            newPosition[0] = this.position[0] - step * normal[0];
            newPosition[1] = this.position[1] - step * normal[1];
            newPosition[2] = this.position[2] - step * normal[2];
        }
        else {
            newPosition[0] = this.position[0];
            newPosition[1] = this.position[1];
            newPosition[2] = this.position[2] - step;
        }

        this.steps = stepIncrement;
        this.setPosition(newPosition);
    }

    // Change camera position
    setPosition(position) {
        vec3.copy(this.position, position);
        this.update();
    }

    // Change camera focus
    setFocus(focus) {
        vec3.copy(this.focus, focus);
        this.update();
    }




    // Set camera azimuth
    setAzimuth(azimuth) {
        this.changeAzimuth(azimuth - this.azimuth);
    }

    // Change camera azimuth
    changeAzimuth(azimuth) {
        this.azimuth += azimuth;

        if (this.azimuth > 360 || this.azimuth < -360) {
            this.azimuth = this.azimuth % 360;
        }

        this.update();
    }

    // Set camera elevation
    setElevation(elevation) {
        this.changeElevation(elevation - this.elevation);
    }

    // Change camera elevation
    changeElevation(elevation) {
        this.elevation += elevation;

        if (this.elevation > 360 || this.elevation < -360) {
            this.elevation = this.elevation % 360;
        }

        this.update();
    }

    // alternative to azimuth and elevation

    setRotation(rx, ry, rz) {
        this.rx = rx;
        this.ry = ry;
        this.rz = rz;
        this.update();
    }

    // pitch is inclination nose to tail of an aircraft
    setPitch(degrees) {
        this.setRotation(this.rx, degrees, this.rz);
    }

    // yaw is the rotation around the vertical axis of an aircraft
    setYaw(degrees) {
        this.setRotation(degrees, this.ry, this.rz);
    }

    // roll is the rotation around the main axis of an aircraft
    setRoll(degrees) {
        this.setRotation(this.rx, this.ry, degrees);
    }


    // Update the camera orientation
    calculateOrientation() {
        const right = vec4.create();
        vec4.set(right, 1, 0, 0, 0);
        vec4.transformMat4(right, right, this.matrix);
        vec3.copy(this.right, right);

        const up = vec4.create();
        vec4.set(up, 0, 1, 0, 0);
        vec4.transformMat4(up, up, this.matrix);
        vec3.copy(this.up, up);

        const normal = vec4.create();
        vec4.set(normal, 0, 0, 1, 0);
        vec4.transformMat4(normal, normal, this.matrix);
        vec3.copy(this.normal, normal);
    }

    // Update camera values
    update() {
        mat4.identity(this.matrix);

        if (this.isTracking()) {
            mat4.translate(this.matrix, this.matrix, this.position);
            mat4.rotateY(this.matrix, this.matrix, this.azimuth * Math.PI / 180);
            mat4.rotateX(this.matrix, this.matrix, this.elevation * Math.PI / 180);
        }
        else {
            mat4.rotateY(this.matrix, this.matrix, this.azimuth * Math.PI / 180);
            mat4.rotateX(this.matrix, this.matrix, this.elevation * Math.PI / 180);
            mat4.translate(this.matrix, this.matrix, this.position);
        }

        // We only update the position if we have a tracking camera.
        // For an orbiting camera we do not update the position. If
        // Why do you think we do not update the position?
        if (this.isTracking()) {
            const position = vec4.create();
            vec4.set(position, 0, 0, 0, 1);
            vec4.transformMat4(position, position, this.matrix);
            vec3.copy(this.position, position);
        }

        this.calculateOrientation();
    }

    // Returns the view transform
    getViewTransform() {
        const matrix = mat4.create();
        mat4.invert(matrix, this.matrix);
        return matrix;
    }

}

// Two defined modes for the camera
WebGLCamera.TYPES = ['ORBITING_TYPE', 'TRACKING_TYPE'];
WebGLCamera.TYPES.forEach(type => WebGLCamera[type] = type);

