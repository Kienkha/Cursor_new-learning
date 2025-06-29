using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AddInManager
{
    public partial class FormAbout : Form
    {
        public FormAbout()
        {
            InitializeComponent();
            LinkLabel.Link llStantec = new LinkLabel.Link();
            llStantec.LinkData = "http://www.stantec.com/";
            linkLabelStantec.Links.Add(llStantec);

            LinkLabel.Link llBoost = new LinkLabel.Link();
            llBoost.LinkData = "https://boostyourbim.wordpress.com/";
            linkLabelBoost.Links.Add(llBoost);
        }

        private void linkLabelBoost_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(e.Link.LinkData as string);
        }

        private void linkLabelStantec_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(e.Link.LinkData as string);
        }
    }
}
