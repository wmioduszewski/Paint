﻿using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using MdsPaint.Utils;

namespace MdsPaint.PluginManagment
{
    public abstract class MdsPaintPluginBase
    {
        public Panel PanelPointer { get; set; }

        public Bitmap Picture { get; set; }

        public abstract Image ButtonImage { get; }
        public abstract string PanelLabel { get; }

        public abstract void ProcessBitmap(Bitmap source, Bitmap dest);

        public RibbonPanel RibbonPanel
        {
            get
            {
                return InitRibbonPanel();
            }
        }

        private RibbonPanel InitRibbonPanel()
        {
            var button = new RibbonButton(Name) { Tag = this };
            button.Click += button_Click;
            button.SmallImage = ButtonImage;
            var panel = new RibbonPanel(PanelLabel);
            panel.Items.Add(button);
            return panel;
        }

        static void button_Click(object sender, EventArgs e)
        {
            var btn = (RibbonButton)sender;
            var plugin = (MdsPaintPluginBase)(btn.Tag);
            var panel = plugin.PanelPointer;
            var panelDim = panel.Size;
            var source = new Bitmap(panelDim.Width, panelDim.Height);
            panel.DrawToBitmap(source, new Rectangle(0, 0, panelDim.Width, panelDim.Height));
            
            plugin.ProcessBitmap(source,plugin.Picture);
            
            plugin.PanelPointer.Invalidate();
        }

        public abstract string Name { get; }
    }
}