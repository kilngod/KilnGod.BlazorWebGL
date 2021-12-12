using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace KilnGod.BlazorWebGL.TestSample.Other;

public static class MandelbrotExtensions
{



    public static void CalcCPUParallel(int[] buffer, int width, int height, float left, float right, float bottom, float top, int max_iterations)
    {
        int icnt = width;

        Parallel.For(0, icnt, i =>
        {
            for (int j = 0; j < height; j++)
            {
                int index = i + j * width;  // ILGPU-like index
                    int img_x = index % width;
                int img_y = index / width;

                float x0 = left + img_x * (right - left) / width;
                float y0 = bottom + img_y * (top - bottom) / height;
                float x = 0.0f;
                float y = 0.0f;
                int iteration = 0;
                while ((x * x + y * y < 2 * 2) && (iteration < max_iterations))
                {
                    float xtemp = x * x - y * y + x0;
                    y = 2 * x * y + y0;
                    x = xtemp;
                    iteration += 1;
                }
                buffer[index] = iteration;
            }
        });
    }

    public static async Task Draw(BasicCanvas basicCanvas, int[] data, int width, int height, int iterations, Color color)
    {

        byte[] result = new byte[width * height * 4];

        for (int i = 0; i < width * height; i++)
        {
            Color fillColor = color;


            if (data[i] >= iterations)
            {
                fillColor = color;
            }
            else
            {

                int red = data[i] * 30 % 256;
                int green = data[i] * 20 % 256;
                int blue = data[i] * 50 % 256;

                fillColor = Color.FromArgb(255, red, green, blue);

            }


            result[i * 4] = fillColor.R;
            result[i * 4 + 1] = fillColor.G;
            result[i * 4 + 2] = fillColor.B;
            result[i * 4 + 3] = fillColor.A;

        }

        await basicCanvas.CreateImageDataCopyByteArray("Mandelbrot", width, height, result);
        await basicCanvas.PutImageData("Mandelbrot", 0, 0);
    }



}

