using System;
using System.Runtime.InteropServices;

using static sokol_gfx;

// Defines the data structures to interoperate with Sokol.
// Nothing to see here, move along.

internal enum BOOL : byte
{
    FALSE = 0,
    TRUE = 1,
}

internal static unsafe class sokol_gfx
{
    private const string LibraryName = "sokol";

    public enum sg_pixel_format : uint
    {
        _SG_PIXELFORMAT_DEFAULT = 0U,
        SG_PIXELFORMAT_NONE = 1U,
        SG_PIXELFORMAT_R8 = 2U,
        SG_PIXELFORMAT_R8SN = 3U,
        SG_PIXELFORMAT_R8UI = 4U,
        SG_PIXELFORMAT_R8SI = 5U,
        SG_PIXELFORMAT_R16 = 6U,
        SG_PIXELFORMAT_R16SN = 7U,
        SG_PIXELFORMAT_R16UI = 8U,
        SG_PIXELFORMAT_R16SI = 9U,
        SG_PIXELFORMAT_R16F = 10U,
        SG_PIXELFORMAT_RG8 = 11U,
        SG_PIXELFORMAT_RG8SN = 12U,
        SG_PIXELFORMAT_RG8UI = 13U,
        SG_PIXELFORMAT_RG8SI = 14U,
        SG_PIXELFORMAT_R32UI = 15U,
        SG_PIXELFORMAT_R32SI = 16U,
        SG_PIXELFORMAT_R32F = 17U,
        SG_PIXELFORMAT_RG16 = 18U,
        SG_PIXELFORMAT_RG16SN = 19U,
        SG_PIXELFORMAT_RG16UI = 20U,
        SG_PIXELFORMAT_RG16SI = 21U,
        SG_PIXELFORMAT_RG16F = 22U,
        SG_PIXELFORMAT_RGBA8 = 23U,
        SG_PIXELFORMAT_RGBA8SN = 24U,
        SG_PIXELFORMAT_RGBA8UI = 25U,
        SG_PIXELFORMAT_RGBA8SI = 26U,
        SG_PIXELFORMAT_BGRA8 = 27U,
        SG_PIXELFORMAT_RGB10A2 = 28U,
        SG_PIXELFORMAT_RG11B10F = 29U,
        SG_PIXELFORMAT_RG32UI = 30U,
        SG_PIXELFORMAT_RG32SI = 31U,
        SG_PIXELFORMAT_RG32F = 32U,
        SG_PIXELFORMAT_RGBA16 = 33U,
        SG_PIXELFORMAT_RGBA16SN = 34U,
        SG_PIXELFORMAT_RGBA16UI = 35U,
        SG_PIXELFORMAT_RGBA16SI = 36U,
        SG_PIXELFORMAT_RGBA16F = 37U,
        SG_PIXELFORMAT_RGBA32UI = 38U,
        SG_PIXELFORMAT_RGBA32SI = 39U,
        SG_PIXELFORMAT_RGBA32F = 40U,
        SG_PIXELFORMAT_DEPTH = 41U,
        SG_PIXELFORMAT_DEPTH_STENCIL = 42U,
        SG_PIXELFORMAT_BC1_RGBA = 43U,
        SG_PIXELFORMAT_BC2_RGBA = 44U,
        SG_PIXELFORMAT_BC3_RGBA = 45U,
        SG_PIXELFORMAT_BC4_R = 46U,
        SG_PIXELFORMAT_BC4_RSN = 47U,
        SG_PIXELFORMAT_BC5_RG = 48U,
        SG_PIXELFORMAT_BC5_RGSN = 49U,
        SG_PIXELFORMAT_BC6H_RGBF = 50U,
        SG_PIXELFORMAT_BC6H_RGBUF = 51U,
        SG_PIXELFORMAT_BC7_RGBA = 52U,
        SG_PIXELFORMAT_PVRTC_RGB_2BPP = 53U,
        SG_PIXELFORMAT_PVRTC_RGB_4BPP = 54U,
        SG_PIXELFORMAT_PVRTC_RGBA_2BPP = 55U,
        SG_PIXELFORMAT_PVRTC_RGBA_4BPP = 56U,
        SG_PIXELFORMAT_ETC2_RGB8 = 57U,
        SG_PIXELFORMAT_ETC2_RGB8A1 = 58U,
        SG_PIXELFORMAT_ETC2_RGBA8 = 59U,
        SG_PIXELFORMAT_ETC2_RG11 = 60U,
        SG_PIXELFORMAT_ETC2_RG11SN = 61U,
        _SG_PIXELFORMAT_NUM = 62U,
        _SG_PIXELFORMAT_FORCE_U32 = 2147483647U
    }

    public enum sg_face_winding : uint
    {
        _SG_FACEWINDING_DEFAULT = 0U,
        SG_FACEWINDING_CCW = 1U,
        SG_FACEWINDING_CW = 2U,
        _SG_FACEWINDING_NUM = 3U,
        _SG_FACEWINDING_FORCE_U32 = 2147483647U
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct sg_image
    {
        public uint id;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct sg_desc
    {
        public uint _start_canary;
        public int buffer_pool_size;
        public int image_pool_size;
        public int shader_pool_size;
        public int pipeline_pool_size;
        public int pass_pool_size;
        public int context_pool_size;
        public int uniform_buffer_size;
        public int staging_buffer_size;
        public int sampler_cache_size;
        public sg_context_desc context;
        public uint _end_canary;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct sg_gl_context_desc
    {
        public BOOL force_gles2;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct sg_metal_context_desc
    {
        public void* device;
        public IntPtr renderpass_descriptor_cb;
        public IntPtr renderpass_descriptor_userdata_cb;
        public IntPtr drawable_cb;
        public IntPtr drawable_userdata_cb;
        public void* user_data;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct sg_d3d11_context_desc
    {
        public void* device;
        public void* device_context;
        public IntPtr render_target_view_cb;
        public IntPtr render_target_view_userdata_cb;
        public IntPtr depth_stencil_view_cb;
        public IntPtr depth_stencil_view_userdata_cb;
        public void* user_data;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct sg_wgpu_context_desc
    {
        public void* device;
        public IntPtr render_view_cb;
        public IntPtr render_view_userdata_cb;
        public IntPtr resolve_view_cb;
        public IntPtr resolve_view_userdata_cb;
        public IntPtr depth_stencil_view_cb;
        public IntPtr depth_stencil_view_userdata_cb;
        public void* user_data;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct sg_context_desc
    {
        public sg_pixel_format color_format;
        public sg_pixel_format depth_format;
        public int sample_count;
        public sg_gl_context_desc gl;
        public sg_metal_context_desc metal;
        public sg_d3d11_context_desc d3d11;
        public sg_wgpu_context_desc wgpu;
    }

    [DllImport(LibraryName)]
    public static extern void sg_setup(sg_desc* desc);

    [DllImport(LibraryName)]
    public static extern void sg_shutdown();

    [DllImport(LibraryName)]
    public static extern void sg_end_pass();

    [DllImport(LibraryName)]
    public static extern void sg_commit();

    public enum sg_filter : uint
    {
        _SG_FILTER_DEFAULT = 0U,
        SG_FILTER_NEAREST = 1U,
        SG_FILTER_LINEAR = 2U,
        SG_FILTER_NEAREST_MIPMAP_NEAREST = 3U,
        SG_FILTER_NEAREST_MIPMAP_LINEAR = 4U,
        SG_FILTER_LINEAR_MIPMAP_NEAREST = 5U,
        SG_FILTER_LINEAR_MIPMAP_LINEAR = 6U,
        _SG_FILTER_NUM = 7U,
        _SG_FILTER_FORCE_U32 = 2147483647U
    }

    public enum sg_action : uint
    {
        _SG_ACTION_DEFAULT = 0U,
        SG_ACTION_CLEAR = 1U,
        SG_ACTION_LOAD = 2U,
        SG_ACTION_DONTCARE = 3U,
        _SG_ACTION_NUM = 4U,
        _SG_ACTION_FORCE_U32 = 2147483647U
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct sg_color_attachment_action
    {
        public sg_action action;
        public fixed float val[4];
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct sg_depth_attachment_action
    {
        public sg_action action;
        public float val;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct sg_stencil_attachment_action
    {
        public sg_action action;
        public byte val;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct sg_pass_action
    {
        public uint _start_canary;
        public sg_color_attachment_action color0;
        public sg_color_attachment_action color1;
        public sg_color_attachment_action color2;
        public sg_color_attachment_action color3;
        public sg_depth_attachment_action depth;
        public sg_stencil_attachment_action stencil;
        public uint _end_canary;
    }

    [DllImport(LibraryName)]
    public static extern void sg_begin_default_pass(sg_pass_action* pass_action, int width, int height);

    public enum sg_image_type : uint
    {
        _SG_IMAGETYPE_DEFAULT = 0U,
        SG_IMAGETYPE_2D = 1U,
        SG_IMAGETYPE_CUBE = 2U,
        SG_IMAGETYPE_3D = 3U,
        SG_IMAGETYPE_ARRAY = 4U,
        _SG_IMAGETYPE_NUM = 5U,
        _SG_IMAGETYPE_FORCE_U32 = 2147483647U
    }

    public enum sg_usage : uint
    {
        _SG_USAGE_DEFAULT = 0U,
        SG_USAGE_IMMUTABLE = 1U,
        SG_USAGE_DYNAMIC = 2U,
        SG_USAGE_STREAM = 3U,
        _SG_USAGE_NUM = 4U,
        _SG_USAGE_FORCE_U32 = 2147483647U
    }

    public enum sg_wrap : uint
    {
        _SG_WRAP_DEFAULT = 0U,
        SG_WRAP_REPEAT = 1U,
        SG_WRAP_CLAMP_TO_EDGE = 2U,
        SG_WRAP_CLAMP_TO_BORDER = 3U,
        SG_WRAP_MIRRORED_REPEAT = 4U,
        _SG_WRAP_NUM = 5U,
        _SG_WRAP_FORCE_U32 = 2147483647U
    }

    public enum sg_border_color : uint
    {
        _SG_BORDERCOLOR_DEFAULT = 0U,
        SG_BORDERCOLOR_TRANSPARENT_BLACK = 1U,
        SG_BORDERCOLOR_OPAQUE_BLACK = 2U,
        SG_BORDERCOLOR_OPAQUE_WHITE = 3U,
        _SG_BORDERCOLOR_NUM = 4U,
        _SG_BORDERCOLOR_FORCE_U32 = 2147483647U
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct sg_subimage_content
    {
        public void* ptr;
        public int size;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct sg_image_content
    {
        public sg_subimage_content content0;
        public sg_subimage_content content1;
        public sg_subimage_content content2;
        public sg_subimage_content content3;
        public sg_subimage_content content4;
        public sg_subimage_content content5;
        public sg_subimage_content content6;
        public sg_subimage_content content7;
        public sg_subimage_content content8;
        public sg_subimage_content content9;
        public sg_subimage_content content10;
        public sg_subimage_content content11;
        public sg_subimage_content content12;
        public sg_subimage_content content13;
        public sg_subimage_content content14;
        public sg_subimage_content content15;
        public sg_subimage_content content16;
        public sg_subimage_content content17;
        public sg_subimage_content content18;
        public sg_subimage_content content19;
        public sg_subimage_content content20;
        public sg_subimage_content content21;
        public sg_subimage_content content22;
        public sg_subimage_content content23;
        public sg_subimage_content content24;
        public sg_subimage_content content25;
        public sg_subimage_content content26;
        public sg_subimage_content content27;
        public sg_subimage_content content28;
        public sg_subimage_content content29;
        public sg_subimage_content content30;
        public sg_subimage_content content31;
        public sg_subimage_content content32;
        public sg_subimage_content content33;
        public sg_subimage_content content34;
        public sg_subimage_content content35;
        public sg_subimage_content content36;
        public sg_subimage_content content37;
        public sg_subimage_content content38;
        public sg_subimage_content content39;
        public sg_subimage_content content40;
        public sg_subimage_content content41;
        public sg_subimage_content content42;
        public sg_subimage_content content43;
        public sg_subimage_content content44;
        public sg_subimage_content content45;
        public sg_subimage_content content46;
        public sg_subimage_content content47;
        public sg_subimage_content content48;
        public sg_subimage_content content49;
        public sg_subimage_content content50;
        public sg_subimage_content content51;
        public sg_subimage_content content52;
        public sg_subimage_content content53;
        public sg_subimage_content content54;
        public sg_subimage_content content55;
        public sg_subimage_content content56;
        public sg_subimage_content content57;
        public sg_subimage_content content58;
        public sg_subimage_content content59;
        public sg_subimage_content content60;
        public sg_subimage_content content61;
        public sg_subimage_content content62;
        public sg_subimage_content content63;
        public sg_subimage_content content64;
        public sg_subimage_content content65;
        public sg_subimage_content content66;
        public sg_subimage_content content67;
        public sg_subimage_content content68;
        public sg_subimage_content content69;
        public sg_subimage_content content70;
        public sg_subimage_content content71;
        public sg_subimage_content content72;
        public sg_subimage_content content73;
        public sg_subimage_content content74;
        public sg_subimage_content content75;
        public sg_subimage_content content76;
        public sg_subimage_content content77;
        public sg_subimage_content content78;
        public sg_subimage_content content79;
        public sg_subimage_content content80;
        public sg_subimage_content content81;
        public sg_subimage_content content82;
        public sg_subimage_content content83;
        public sg_subimage_content content84;
        public sg_subimage_content content85;
        public sg_subimage_content content86;
        public sg_subimage_content content87;
        public sg_subimage_content content88;
        public sg_subimage_content content89;
        public sg_subimage_content content90;
        public sg_subimage_content content91;
        public sg_subimage_content content92;
        public sg_subimage_content content93;
        public sg_subimage_content content94;
        public sg_subimage_content content95;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct sg_image_desc
    {
        public uint _start_canary;
        public sg_image_type type;
        public BOOL render_target;
        public int width;
        public int height;
        public int num_slices;
        public int num_mipmaps;
        public sg_usage usage;
        public sg_pixel_format pixel_format;
        public int sample_count;
        public sg_filter min_filter;
        public sg_filter mag_filter;
        public sg_wrap wrap_u;
        public sg_wrap wrap_v;
        public sg_wrap wrap_w;
        public sg_border_color border_color;
        public uint max_anisotropy;
        public float min_lod;
        public float max_lod;
        public sg_image_content content;
        public byte* label;
        public uint gl_texture1;
        public uint gl_texture2;
        public uint gl_texture_target;
        public void* mtl_texture1;
        public void* mtl_texture2;
        public void* d3d11_texture;
        public void* d3d11_shader_resource_view;
        public void* wgpu_texture;
        public uint _end_canary;
    }

    [DllImport(LibraryName)]
    public static extern sg_image sg_make_image(sg_image_desc* desc);

    [DllImport(LibraryName)]
    public static extern void sg_update_image(sg_image img, sg_image_content* data);
}

internal unsafe static class sokol_gl
{
    [StructLayout(LayoutKind.Sequential)]
    public struct sgl_desc
    {
        public int max_vertices;
        public int max_commands;
        public int pipeline_pool_size;
        public sg_pixel_format color_format;
        public sg_pixel_format depth_format;
        public int sample_count;
        public sg_face_winding face_winding;
    }

    private const string LibraryName = "sokol";

    [DllImport(LibraryName)]
    public static extern void sgl_setup(sgl_desc* desc);

    [DllImport(LibraryName)]
    public static extern void sgl_defaults();

    [DllImport(LibraryName)]
    public static extern void sgl_draw();

    [DllImport(LibraryName)]
    public static extern void sgl_shutdown();

    [DllImport(LibraryName)]
    public static extern void sgl_end();

    [DllImport(LibraryName)]
    public static extern void sgl_begin_quads();


    [DllImport(LibraryName)]
    public static extern void sgl_enable_texture();

    [DllImport(LibraryName)]
    public static extern void sgl_texture(sg_image img);


    [DllImport(LibraryName)]
    public static extern void sgl_v2f_t2f(float x, float y, float u, float v);
}

internal static unsafe class sokol_app
{
    private const string LibraryName = "sokol";

    [DllImport(LibraryName)]
    public static extern int sapp_sample_count();

    [DllImport(LibraryName)]
    public static extern int sapp_width();

    [DllImport(LibraryName)]
    public static extern int sapp_height();

    [StructLayout(LayoutKind.Sequential)]
    public struct sapp_desc
    {
        public delegate* unmanaged<void> init_cb;
        public delegate* unmanaged<void> frame_cb;
        public delegate* unmanaged<void> cleanup_cb;
        public IntPtr event_cb;
        public IntPtr fail_cb;
        public void* user_data;
        public IntPtr init_userdata_cb;
        public IntPtr frame_userdata_cb;
        public IntPtr cleanup_userdata_cb;
        public IntPtr event_userdata_cb;
        public IntPtr fail_userdata_cb;
        public int width;
        public int height;
        public int sample_count;
        public int swap_interval;
        public BOOL high_dpi;
        public BOOL fullscreen;
        public BOOL alpha;
        public byte* window_title;
        public BOOL user_cursor;
        public BOOL enable_clipboard;
        public int clipboard_size;
        public BOOL enable_dragndrop;
        public int max_dropped_files;
        public int max_dropped_file_path_length;
        public byte* html5_canvas_name;
        public BOOL html5_canvas_resize;
        public BOOL html5_preserve_drawing_buffer;
        public BOOL html5_premultiplied_alpha;
        public BOOL html5_ask_leave_site;
        public BOOL ios_keyboard_resizes_canvas;
        public BOOL gl_force_gles2;
    }

    [DllImport(LibraryName)]
    public static extern void sapp_run(sapp_desc* desc);
}

internal static unsafe class sokol_glue
{
    private const string LibraryName = "sokol";

    [DllImport(LibraryName)]
    public static extern sg_context_desc sapp_sgcontext();
}
