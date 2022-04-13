
export class WebGLTexture {
    // strict mode on by default in modules

    constructor(webgl, source) {
        this.gl = webgl.gl;
        this.texture = gl.createTexture();

        this.image = new Image();
        this.image.onload = () => this.handleLoadedTexture();

        if (source) {
            this.setImage(source);
        }
    }

    // Sets the texture image source
    setImage(source) {
        this.image.src = source;
    }

    // Configure texture
    handleLoadedTexture() {
        const { gl, image, texture } = this;
        // Bind
        gl.bindTexture(gl.TEXTURE_2D, texture);
        // Configure
        gl.texImage2D(gl.TEXTURE_2D, 0, gl.RGBA, gl.RGBA, gl.UNSIGNED_BYTE, image);
        gl.texParameteri(gl.TEXTURE_2D, gl.TEXTURE_MAG_FILTER, gl.LINEAR);
        gl.texParameteri(gl.TEXTURE_2D, gl.TEXTURE_MIN_FILTER, gl.LINEAR_MIPMAP_NEAREST);
        gl.generateMipmap(gl.TEXTURE_2D);
        // Clean
        gl.bindTexture(gl.TEXTURE_2D, null);
    }

}