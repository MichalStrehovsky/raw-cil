using System;
using System.Runtime.InteropServices;

using static sokol_app;
using static sokol_gfx;
using static sokol_glue;
using static sokol_gl;

unsafe static class Program
{
    static sg_image img;

    static Random rng = new Random();

    private static int GetRandom() => rng.Next();

    [UnmanagedCallersOnly]
    static void Init()
    {
        sg_desc desc = new sg_desc
        {
            context = sapp_sgcontext(),
        };
        sg_setup(&desc);

        sgl_desc gldesc = new sgl_desc
        {
            sample_count = sapp_sample_count(),
        };
        sgl_setup(&gldesc);
        
        sg_image_desc imagedesc = new sg_image_desc
        {
            width = 320,
            height = 168,
            pixel_format = sg_pixel_format.SG_PIXELFORMAT_RGBA8,
            min_filter = sg_filter.SG_FILTER_NEAREST,
            mag_filter = sg_filter.SG_FILTER_NEAREST,
            usage = sg_usage.SG_USAGE_STREAM,
        };
        img = sg_make_image(&imagedesc);
    }

    [UnmanagedCallersOnly]
    static void Frame()
    {
        int[] pixels = Fire.Run();
        fixed (int* pImg = pixels)
        {
            sg_image_content content = new sg_image_content
            {
                content0 = new sg_subimage_content
                {
                    ptr = pImg,
                    size = pixels.Length * sizeof(int),
                }
            };
            sg_update_image(img, &content);
        }

        sgl_defaults();

        sgl_enable_texture();
        sgl_texture(img);

        sgl_begin_quads();
        sgl_v2f_t2f(-1.0f, -1.0f, 1.0f, 1.0f);
        sgl_v2f_t2f(1.0f, -1.0f, 0.0f, 1.0f);
        sgl_v2f_t2f(1.0f, 1.0f, 0.0f, 0.0f);
        sgl_v2f_t2f(-1.0f, 1.0f, 1.0f, 0.0f);
        sgl_end();

        sg_pass_action pass_action = new sg_pass_action();
        sg_begin_default_pass(&pass_action, sapp_width(), sapp_height());
        sgl_draw();
        sg_end_pass();
        sg_commit();
    }

    [UnmanagedCallersOnly]
    static void Cleanup()
    {
        sgl_shutdown();
        sg_shutdown();
    }

    static void Main()
    {
        Fire.Random = &GetRandom;

        var desc = new sapp_desc
        {
            init_cb = &Init,
            frame_cb = &Frame,
            cleanup_cb = &Cleanup,
            width = 640,
            height = 480,
        };
        sapp_run(&desc);
    }
}
