// This file was hand-ported from WASM at https://github.com/binji/raw-wasm/tree/566f04cf7a963323f0dcbcb272207225e408adca/doomfire
// See THIRD-PARTY-NOTICES.TXT for details.

// FIRE_WIDTH = 320
// FIRE_HEIGHT = 168
// FIRE_WIDTH * FIRE_HEIGHT = 53760
// FIRE_WIDTH * (FIRE_HEIGHT - 1) = 53440

// This disables some auto-behaviors of ILASM that are annoying when not referencing a core library module.
.mscorlib

.assembly fire { }

.field static int8[] firePixels
.field static int32[] canvas
.field static int32 palette at PaletteData

// Emitting as "cil" to save one section
.data cil PaletteData = bytearray (
  070707FF1F0707FF2F0F07FF470F07FF571707FF671F07FF
  771F07FF8F2707FF9F2F07FFAF3F07FFBF4707FFC74707FF
  DF4F07FFDF5707FFDF5707FFD75F07FFD75F07FFD7670FFF
  CF6F0FFFCF770FFFCF7F0FFFCF8717FFC78717FFC78F17FF
  C7971FFFBF9F1FFFBF9F1FFFBFA727FFBFA727FFBFAF2FFF
  B7AF2FFFB7B72FFFB7B737FFCFCF6FFFDFDF9FFFEFEFC7FF
  FFFFFFFF)

// This is the "module constructor" - it runs before any other code from this module runs.
.method specialname rtspecialname static void .cctor()
{
    .locals (int32 i)

    ldc.i4 53760
    dup
    newarr int8
    stsfld int8[] firePixels
    newarr int32
    stsfld int32[] canvas

    // Fill bottom row with color 36, (R=0xff, G=0xff, B=0xff).
    ldc.i4 320
    stloc i
    // firePixels[53440 - 1 + i] = 36
loop:
    ldsfld int8[] firePixels
    ldc.i4 53439
    ldloc i
    add
    ldc.i4 36
    stelem int8
    // loop if --i != 0
    ldloc i
    ldc.i4.1
    sub
    dup
    stloc i
    brtrue loop

    ret
}

// For external visibility sake, we have to put this method into a type.
// Interface is better than a class because interfaces don't derive from System.Object and this
// binary can stay "import-free". No practical advantage to that except we're saving some bytes.
.class interface public abstract Fire
{
    .field public static method int32*() Random

    .method public static int32[] Run()
    {
        .locals init (int32 i, int32 pixel, int32 randIdx)

    xloop:
    yloop:
        ldsfld int8[] firePixels
        ldloc i
        ldc.i4 320
        add
        dup
        stloc i
        ldelem int8
        dup
        stloc pixel
        brfalse zeroPixel

        ldsfld method int32*() Fire::Random
        calli int32()
        ldc.i4.3
        and
        stloc randIdx

        ldsfld int8[] firePixels
        ldloc i
        ldloc randIdx
        sub
        ldc.i4 319
        sub
        ldloc pixel
        ldloc randIdx
        ldc.i4.1
        and
        sub
        stelem int8
        br endif

    zeroPixel:
        ldsfld int8[] firePixels
        ldloc i
        ldc.i4 320
        sub
        ldc.i4.0
        stelem int8

    endif:

        ldloc i
        ldc.i4 53440
        blt.un yloop

        ldloc i
        ldc.i4 53439
        sub
        dup
        stloc i
        ldc.i4 320
        bne.un xloop

        // copy from firePixels to canvasData, using palette data.
        ldc.i4 53760
        stloc i

    copywithpalette:
        // --i
        ldloc i
        ldc.i4.1
        sub
        stloc i

        // canvas[i] = (&palette)[firePixels[i]]
        ldsfld int32[] canvas
        ldloc i
        ldsflda int32 palette
        ldsfld int8[] firePixels
        ldloc i
        ldelem int8
        ldc.i4.2
        shl
        add
        ldind.i4
        stelem int32

        // loop if i != 0
        ldloc i
        brtrue copywithpalette

        ldsfld int32[] canvas
        ret
    }
}
