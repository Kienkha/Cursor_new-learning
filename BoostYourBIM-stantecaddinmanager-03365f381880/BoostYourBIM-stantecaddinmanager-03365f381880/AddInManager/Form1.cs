using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace AddInManager
{
    public partial class Form1 : Form
    {
        public static string disabled = ".disabled";
        public Form1()
        {
            InitializeComponent();

            cboVersion.Items.Add("<all>");
            cboVersion.SelectedIndex = 0;
            buildGrid();
        }

        private void buildGrid()
        {          
            dataGridView1.Rows.Clear();
            IList<string> paths = new List<string>();
            paths.Add(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Autodesk", "Revit", "Addins"));
            paths.Add(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Autodesk", "ApplicationPlugins"));
            paths.Add(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Autodesk", "Revit", "Addins"));
            IList<string> files = new List<string>();
            foreach (string path in paths)
            {
                try
                {
                    string[] foo = Directory.GetFiles(path, "*.addin", SearchOption.AllDirectories);
                    foreach (string f in foo)
                    {
                        files.Add(f);
                    }
                }
                catch
                { }
            }
            foreach (string path in paths)
            {
                try
                {
                    string[] foo = Directory.GetFiles(path, "*.addin" + disabled, SearchOption.AllDirectories);
                    foreach (string f in foo)
                    {
                        files.Add(f);
                    }
                }
                catch
                { }
            }
            foreach (string file in files)
            {
                string[] split = file.Split('\\');
                string version = "";
                string user = "no";
                foreach (string s in split)
                {
                    if (s.StartsWith("20") && s.Length == 4)
                    {
                        version = s;
                    }
                    if (s == Environment.UserName)
                    {
                        user = "yes";
                    }
                }

                string name = "";
                using (StreamReader sr = new StreamReader(file))
                {
                    string thisLine = "";
                    while (thisLine != null)
                    {
                        thisLine = sr.ReadLine();
                        if (thisLine == null)
                            break;

                        if (thisLine.Contains("<Name>") && thisLine.Contains("</Name>"))
                        {
                            name = thisLine.Replace("<Name>", "").Replace("</Name>", "");
                            break;
                        }

                        if (thisLine.Contains("<Text>") && thisLine.Contains("</Text>"))
                        {
                            name = thisLine.Replace("<Text>", "").Replace("</Text>", "");
                            break;
                        }
                    }
                }
                name = name.TrimStart(' ').TrimEnd(' ');

                string enabled = "";
                if (file.EndsWith(disabled))
                    enabled = "no";
                else
                    enabled = "yes";

                if (version == cboVersion.Text || cboVersion.Text == "<all>")
                    dataGridView1.Rows.Add(new string[] { name, user, enabled, version, file });

                if (!cboVersion.Items.Contains(version))
                {
                    cboVersion.Items.Add(version);
                }
            }


        }

        private void btnEnDis_Click(object sender, EventArgs e)
        {

            string readonlyfiles = "";
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                string filename = row.Cells["AddinPath"].Value.ToString();
                if (File.Exists(filename))
                {
                    FileInfo fi = new FileInfo(filename);
                    if (fi.IsReadOnly)
                    {
                        readonlyfiles += filename + Environment.NewLine;
                    }
                    else
                    {
                        try
                        {
                            if (filename.EndsWith(disabled))
                            {
                                string nodis = filename.Replace(disabled, "");
                                File.Copy(filename, nodis);
                                File.Delete(filename);
                            }
                            else
                            {
                                File.Copy(filename, filename + disabled);
                                File.Delete(filename);
                            }
                        }
                        catch
                        {
                            readonlyfiles += filename + Environment.NewLine;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("File does not exist: " + filename);
                }
            }
            if (readonlyfiles != "")
            {
                MessageBox.Show("Cannot rename these files." + Environment.NewLine + readonlyfiles);
            }
            buildGrid();
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Selected = true;
            }
        }

        private void btnInvert_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Selected)
                    row.Selected = false;
                else
                    row.Selected = true;
            }
        }

        private void btnSelEnabled_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                string enabled = row.Cells["IsEnabled"].Value.ToString();
                if (enabled == "yes")
                    row.Selected = true;
                else
                    row.Selected = false;
            }
        }

        private void btnSelDis_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                string enabled = row.Cells["IsEnabled"].Value.ToString();
                if (enabled == "no")
                    row.Selected = true;
                else
                    row.Selected = false;
            }
        }

        private void cboVersion_SelectedIndexChanged(object sender, EventArgs e)
        {
            buildGrid();
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            using (FormAbout form = new FormAbout())
            {
                form.ShowDialog();
            }
        }
    }
}
