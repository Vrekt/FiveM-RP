using static CitizenFX.Core.Native.API;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using CitizenFX.Core.UI;
using CitizenFX.Core;
using System;

namespace client
{
    public static class Renderer
    {
        public static void RenderText(string text, Vector3 position, float scale)
        {
            float x = 0, y = 0;
            var visible = World3dToScreen2d(position.X, position.Y, position.Z, ref x, ref y);
            if (visible)
            {
                SetTextScale(scale, scale);
                SetTextFont(0);
                SetTextProportional(true);
                SetTextColour(255, 255, 255, 255);
                SetTextDropshadow(0, 0, 0, 0, 255);
                SetTextEdge(2, 0, 0, 0, 150);
                SetTextDropShadow();
                SetTextOutline();
                SetTextEntry("STRING");
                SetTextCentre(true);
                AddTextComponentString(text);
                DrawText(x, y);
            }
        }

        public static void RenderText(string text, float x, float y, float scale, int font)
        {
            SetTextScale(scale, scale);
            SetTextFont(font);
            SetTextColour(255, 255, 255, 255);
            SetTextDropshadow(0, 0, 0, 0, 255);
            SetTextEdge(2, 0, 0, 0, 150);
            SetTextDropShadow();
            SetTextOutline();
            SetTextEntry("STRING");
            AddTextComponentString(text);
            DrawText(x, y);
        }

        public static void RenderHelpText(string text, bool loop, int duration)
        {
            SetTextComponentFormat("STRING");
            AddTextComponentString(text);
            DisplayHelpTextFromStringLabel(0, loop, true, duration);

        }

        public static void RenderBox(Vector3 position, float width, float height, int duration, bool loop)
        {
            float x = 0, y = 0;
            var visible = World3dToScreen2d(position.X + 0.5F, position.Y + 0.5F, position.Z, ref x, ref y);
            if (visible)
            {
                SetTextComponentFormat("STRING");
                AddTextComponentString("Testing");
                DisplayHelpTextFromStringLabel(0, loop, true, duration);
            }
        }

    }
}