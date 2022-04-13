﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KilnGod.BlazorWebGL.WebGL3D
{

    public enum EnumParametersString
    {
        RENDERER = 0x1F01,
        SHADING_LANGUAGE_VERSION = 0x8B8C,
        VENDOR = 0x1F00,
        VERSION = 0x1F02
    }

    public enum EnumParametersBool
    {
        ACTIVE_TEXTURE = 0x84E0,
        BLEND = 0x0BE2,
        CULL_FACE = 0x0B44,
        DEPTH_TEST = 0x0B71,
        DEPTH_WRITEMASK = 0x0B72,
        DITHER = 0x0BD0,
        POLYGON_OFFSET_FILL = 0x8037,
        RASTERIZER_DISCARD = 0x8C89,
        SAMPLE_ALPHA_TO_COVERAGE = 0x809E,
        SAMPLE_COVERAGE = 0x80A0,
        SAMPLE_COVERAGE_INVERT = 0x80AB,
        SCISSOR_TEST = 0x0C11,
        STENCIL_TEST = 0x0B90,
        TRANSFORM_FEEDBACK_ACTIVE = 0x8E24,
        TRANSFORM_FEEDBACK_PAUSED = 0x8E23,
        UNPACK_FLIP_Y_WEBGL = 0x9240,
        UNPACK_PREMULTIPLY_ALPHA_WEBGL = 0x9241
    }

    public enum EnumParametersBoolArray
    {
        COLOR_WRITEMASK = 0x0C23
    }

    public enum EnumParametersFloat
    {
        DEPTH_CLEAR_VALUE = 0x0B73,
        LINE_WIDTH = 0x0B21,
        MAX_TEXTURE_LOD_BIAS = 0x84FD,
        POLYGON_OFFSET_FACTOR = 0x8038,
        POLYGON_OFFSET_UNITS = 0x2A00,
        SAMPLE_COVERAGE_VALUE = 0x80AA
    }

   


    public enum EnumParamterFloatArray
    {
        ALIASED_LINE_WIDTH_RANGE = 0x846E,
        ALIASED_POINT_SIZE_RANGE = 0x846D,
        BLEND_COLOR = 0x8005,
        COLOR_CLEAR_VALUE = 0x0C22,
        DEPTH_RANGE = 0x0B70
    }

    public enum EnumParamterIntArray
    {
        MAX_VIEWPORT_DIMS = 0x0D3A,
        SCISSOR_BOX = 0x0C10,
        VIEWPORT = 0x0BA2
    }


    public enum EnumParametersInt
    {
        ALPHA_BITS = 0x0D55,
        BLEND_DST_ALPHA = 0x80CA,
        BLEND_DST_RGB = 0x80C8,
        BLEND_EQUATION = 0x8009,
        BLEND_EQUATION_ALPHA = 0x883D,
        BLEND_EQUATION_RGB = 0x8009,
        BLEND_SRC_ALPHA = 0x80CB,      
        BLEND_SRC_RGB = 0x80C9,
        BLUE_BITS = 0x0D54,
        CULL_FACE_MODE = 0x0B45,
        DEPTH_BITS = 0x0D56,
        DEPTH_FUNC = 0x0B74,
        DRAW_BUFFER0 = 0x8825, DRAW_BUFFER1 = 0x8826,DRAW_BUFFER2 = 0x8827, DRAW_BUFFER3 = 0x8828, DRAW_BUFFER4 = 0x8829, DRAW_BUFFER5 = 0x882A, DRAW_BUFFER6 = 0x882B, DRAW_BUFFER7 = 0x882C,
        DRAW_BUFFER8 = 0x882D, DRAW_BUFFER9 = 0x882E, DRAW_BUFFER10 = 0x882F, DRAW_BUFFER11 = 0x8830, DRAW_BUFFER12 = 0x8831, DRAW_BUFFER13 = 0x8832, DRAW_BUFFER14 = 0x8833, DRAW_BUFFER15 = 0x8834,
        FRAGMENT_SHADER_DERIVATIVE_HINT = 0x8B8B,
        FRONT_FACE = 0x0B46,
        GENERATE_MIPMAP_HINT,
        GREEN_BITS = 0x0D53,
        IMPLEMENTATION_COLOR_READ_FORMAT = 0x8B9B,
        IMPLEMENTATION_COLOR_READ_TYPE = 0x8B9A,
        MAX_3D_TEXTURE_SIZE = 0x8073,
        MAX_ARRAY_TEXTURE_LAYERS = 0x88FF,
        MAX_COLOR_ATTACHMENTS = 0x8CDF,
        MAX_COMBINED_TEXTURE_IMAGE_UNITS = 0x8B4D,
        MAX_COMBINED_UNIFORM_BLOCKS = 0x8A2E,
        MAX_CUBE_MAP_TEXTURE_SIZE = 0x851C,
        MAX_DRAW_BUFFERS = 0x8824,
        MAX_ELEMENTS_INDICES = 0x80E9,
        MAX_ELEMENTS_VERTICES = 0x80E8,
        MAX_FRAGMENT_INPUT_COMPONENTS = 0x9125,
        MAX_FRAGMENT_UNIFORM_BLOCKS = 0x8A2D,
        MAX_FRAGMENT_UNIFORM_COMPONENTS = 0x8B49,
        MAX_FRAGMENT_UNIFORM_VECTORS = 0x8DFD,
        MAX_PROGRAM_TEXEL_OFFSET = 0x8905,
        MAX_RENDERBUFFER_SIZE = 0x84E8,
        MAX_SAMPLES = 0x8D57,
        MAX_TEXTURE_IMAGE_UNITS = 0x8872,
        MAX_TEXTURE_SIZE = 0x0D33,
        MAX_TRANSFORM_FEEDBACK_INTERLEAVED_COMPONENTS = 0x8C8A,
        MAX_TRANSFORM_FEEDBACK_SEPARATE_ATTRIBS = 0x8C8B,
        MAX_TRANSFORM_FEEDBACK_SEPARATE_COMPONENTS = 0x8C80,
        MAX_UNIFORM_BUFFER_BINDINGS = 0x8A2F,
        MAX_VARYING_COMPONENTS = 0x8B4B,
        MAX_VARYING_VECTORS = 0x8DFC,
        MAX_VERTEX_ATTRIBS = 0x8869,
        MAX_VERTEX_OUTPUT_COMPONENTS = 0x9122,
        MAX_VERTEX_TEXTURE_IMAGE_UNITS = 0x8B4C,
        MAX_VERTEX_UNIFORM_BLOCKS = 0x8A2B,
        MAX_VERTEX_UNIFORM_COMPONENTS = 0x8B4A,
        MAX_VERTEX_UNIFORM_VECTORS = 0x8DFB,        
        MIN_PROGRAM_TEXEL_OFFSET = 0x8904,
        PACK_ALIGNMENT = 0x0D05,
        PACK_ROW_LENGTH = 0x0D02,
        PACK_SKIP_PIXELS = 0x0D04,
        PACK_SKIP_ROWS = 0x0D03,
        READ_BUFFER = 0x0C02,
        RED_BITS = 0x0D52,
        SAMPLE_BUFFERS = 0x80A8,
        SAMPLES = 0x80A9,
        STENCIL_BACK_FAIL = 0x8801,
        STENCIL_BACK_FUNC = 0x8800,
        STENCIL_BACK_PASS_DEPTH_FAIL = 0x8802,
        STENCIL_BACK_PASS_DEPTH_PASS = 0x8803,
        STENCIL_BACK_REF = 0x8CA3,
        STENCIL_BITS = 0x0D57,
        STENCIL_CLEAR_VALUE = 0x0B91,
        STENCIL_FAIL = 0x8801,
        STENCIL_FUNC = 0x0B92,
        STENCIL_PASS_DEPTH_FAIL = 0x0B95,
        STENCIL_PASS_DEPTH_PASS = 0x0B96,
        STENCIL_REF = 0x0B97,
        SUBPIXEL_BITS = 0x0D50,
        UNIFORM_BUFFER_OFFSET_ALIGNMENT = 0x8A34,
        UNPACK_ALIGNMENT = 0x0CF5,
        UNPACK_COLORSPACE_CONVERSION_WEBGL = 0x9243,
        UNPACK_IMAGE_HEIGHT = 0x806E,
        UNPACK_ROW_LENGTH = 0x0CF2,
        UNPACK_SKIP_IMAGES = 0x806D,
        UNPACK_SKIP_PIXELS = 0x0CF4,
        UNPACK_SKIP_ROWS = 0x0CF3

    }

    public enum EnumParametersUInt
    {
        STENCIL_BACK_VALUE_MASK = 0x8CA4,
        STENCIL_BACK_WRITEMASK = 0x8CA5,
        STENCIL_VALUE_MASK = 0x0B93,
        STENCIL_WRITEMASK = 0x0B98,

    }

    public enum EnumParametersLong
    {
        MAX_CLIENT_WAIT_TIMEOUT_WEBGL = 0x9247,
        MAX_COMBINED_FRAGMENT_UNIFORM_COMPONENTS = 0x8A31,
        MAX_COMBINED_VERTEX_UNIFORM_COMPONENTS = 0x8A33,
        MAX_ELEMENT_INDEX = 0x8D6B,
        MAX_SERVER_WAIT_TIMEOUT = 0x9111,
        MAX_UNIFORM_BLOCK_SIZE = 0x8A30
    }

   
}