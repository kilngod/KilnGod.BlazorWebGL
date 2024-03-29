﻿

// Abstraction over common controls for user interaction with a 3D scene
export class WebGLControls {
     // strict mode on by default in modules

    constructor(webgl, camera, sceneId) {
        this.webgl = webgl;
        this.gl = webgl.gl;
      
        this.sceneId = sceneId;
        
        this.camera = camera;
        this.picker = null;

        this.dragging = false;
        this.picking = false;
        this.ctrl = false;

        this.x = 0;
        this.y = 0;
        this.lastX = 0;
        this.lastY = 0;
        this.button = 0;
        this.key = 0;

        this.dloc = 0;
        this.dstep = 0;
        this.motionFactor = 10;
        this.keyIncrement = 5;


        // need to set and dispose of event listeners properly
        this.webgl.canvas.onmousedown = event => this.onMouseDown(event);
        this.webgl.canvas.onmouseup = event => this.onMouseUp(event);
        this.webgl.canvas.onmousemove = event => this.onMouseMove(event);
        this.webgl.canvas.onwheel = event => this.onWheel(event);
        window.onkeydown = event => this.onKeyDown(event);
        window.onkeyup = event => this.onKeyUp(event);

    }


    // Sets picker for picking objects
    setPicker(picker) {
        this.picker = picker;
    }

    // Returns 3D coordinates
    get2DCoords(event) {
        let top = 0,
            left = 0,
            canvas = this.webgl.canvas;

        while (canvas && canvas.tagName !== 'BODY') {
            top += this.webgl.canvas.offsetTop;
            left += this.webgl.canvas.offsetLeft;
            canvas = this.webgl.canvas.offsetParent;
        }

        left += window.pageXOffset;
        top -= window.pageYOffset;

        return {
            x: event.clientX - left,
            y: this.webgl.canvas.height - (event.clientY - top)
        };
    }

    onMouseUp(event) {
        this.dragging = false;

        if (!event.shiftKey && this.picker) {
            this.picking = false;
            this.picker.stop();
        }
    }

    onMouseDown(event) {
        this.dragging = true;

        this.x = event.clientX;
        this.y = event.clientY;
        this.button = event.button;

        this.dstep = Math.max(this.camera.position[0], this.camera.position[1], this.camera.position[2]) / 100;

        if (!this.picker) return;

        const coordinates = this.get2DCoords(event);
        this.picking = this.picker.find(coordinates);

        if (!this.picking) this.picker.stop();
    }

    onMouseMove(event) {
        this.lastX = this.x;
        this.lastY = this.y;

        this.x = event.clientX;
        this.y = event.clientY;

        if (!this.dragging) return;

        this.ctrl = event.ctrlKey;
        this.alt = event.altKey;

        const dx = this.x - this.lastX;
        const dy = this.y - this.lastY;

        if (this.picking && this.picker.moveCallback) {
            this.picker.moveCallback(dx, dy);
            return;
        }

        if (!this.button) {
            this.alt
                ? this.dolly(dy)
                : this.rotate(dx, dy);
        }
    }

    onWheel(event) {
        // buttons=4 is mouse wheel down
        // wheelDelta = -120 out/ 120 in
        if (event.wheelDelta > 0 && this.camera.fov < 150.0 * 3.141592 / 180.0) {
            this.camera.fov = this.camera.fov + 0.05;
        } else if (event.wheelDelta < 0 && this.camera.fov > 10.0 * 3.141592/180.0) {
            this.camera.fov = this.camera.fov - 0.05;
        }
        
    }

    onKeyDown(event) {
        this.key = event.keyCode;
        this.ctrl = event.ctrlKey;

        if (this.ctrl) return;

        switch (this.key) {
            case 37:
                return this.camera.changeAzimuth(-this.keyIncrement);
            case 38:
                return this.camera.changeElevation(this.keyIncrement);
            case 39:
                return this.camera.changeAzimuth(this.keyIncrement);
            case 40:
                return this.camera.changeElevation(-this.keyIncrement);
        }
    }

    onKeyUp(event) {
        if (event.keyCode === 17) {
            this.ctrl = false;
        }
    }


    dolly(value) {
        if (value > 0) {
            this.dloc += this.dstep;
        }
        else {
            this.dloc -= this.dstep;
        }

        this.camera.dolly(this.dloc);
    }

    rotate(dx, dy) {
        const { width, height } = this.webgl.canvas;

        const deltaAzimuth = -20 / width;
        const deltaElevation = -20 / height;

        const azimuth = dx * deltaAzimuth * this.motionFactor;
        const elevation = dy * deltaElevation * this.motionFactor;

        this.camera.changeAzimuth(azimuth);
        this.camera.changeElevation(elevation);
    }

}