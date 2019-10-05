﻿using RainbowMage.OverlayPlugin;
using System;
using System.Reflection;

namespace Qitana.PingPlugin
{
    public class OverlayAddonMain : IOverlayAddon
    {
        // OverlayPluginのリソースフォルダ
        public static string ResourcesDirectory = String.Empty;
        public static string UpdateMessage = String.Empty;

        public OverlayAddonMain()
        {
            // OverlayPlugin.Coreを期待
            Assembly asm = System.Reflection.Assembly.GetCallingAssembly();
            if (asm.Location == null || asm.Location == "")
            {
                // 場所がわからないなら自分の場所にする
                asm = Assembly.GetExecutingAssembly();
            }
            ResourcesDirectory = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(asm.Location), "resources");
        }

        static OverlayAddonMain()
        {
            // static constructor should be called only once
            //UpdateMessage = UpdateChecker.Check();
            UpdateMessage = "UpdateChecker is Disabled.";
        }

        public string Name => "Ping";

        public string Description => "Show ping statistics of current server.";

        public Type OverlayType => typeof(PingOverlay);

        public Type OverlayConfigType => typeof(PingOverlayConfig);

        public Type OverlayConfigControlType => typeof(PingOverlayConfigPanel);

        public IOverlay CreateOverlayInstance(IOverlayConfig config) => new PingOverlay((PingOverlayConfig)config);

        public IOverlayConfig CreateOverlayConfigInstance(string name) => new PingOverlayConfig(name);

        public System.Windows.Forms.Control CreateOverlayConfigControlInstance(IOverlay overlay) => new PingOverlayConfigPanel((PingOverlay)overlay);

        public void Dispose() { }
    }
}