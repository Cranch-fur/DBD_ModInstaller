using Microsoft.Win32;
using Newtonsoft.Json.Linq;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dead_By_Daylight_Mod_Installer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) => this.Close();
        private void button2_Click(object sender, EventArgs e) => this.WindowState = FormWindowState.Minimized;
        private async void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            panel1.Capture = false; await Task.Run(() =>
            {
                Message mouse = Message.Create(Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
                WndProc(ref mouse);
            });
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            if (Globals.REGISTRY_VALUE_PAKSFOLDERPATH.Length > 4) // Length 4 = NONE
                textBox1.Text = Globals.REGISTRY_VALUE_PAKSFOLDERPATH;
        }



        private void button4_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(Globals.REGISTRY_VALUE_PAKSFOLDERPATH))
                return;

            string ModPackage = InitializeModPackage();
            if (ModPackage.Length > 4)
            {
                var JsModPackage = JArray.Parse(ModPackage);
                foreach (JObject jsEntry in JsModPackage)
                {
                    DialogResult askformodinstall = MessageBox.Show($"Do you want to install \"{(string)jsEntry["modtitle"]}\" mod from package?", Globals.PROGRAM_EXECUTABLE, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (askformodinstall == DialogResult.Yes)
                    {
                        byte[] InitializedFileByteArray = InitializeUnrealFile(Globals.REGISTRY_VALUE_PAKSFOLDERPATH + $"\\{(string)jsEntry["sourcefile"]}");
                        if (InitializedFileByteArray != null)
                        {
                            if (WriteAllBytesToFile(Globals.REGISTRY_VALUE_PAKSFOLDERPATH + $"\\{(string)jsEntry["sourcefile"]}", ReplaceBytes(InitializedFileByteArray, HexToByteArray(((string)jsEntry["original"]).Replace(" ", "")), HexToByteArray(((string)jsEntry["changed"]).Replace(" ", "")))))
                            {
                                MessageBox.Show($"\"{(string)jsEntry["modtitle"]}\" Mod has been successfully installed!", Globals.PROGRAM_EXECUTABLE, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                            }
                            else
                            {
                                MessageBox.Show($"An error occured when tried to install \"{(string)jsEntry["modtitle"]}\" mod, make sure that mod isn't already installed and mod package was properly made.", Globals.PROGRAM_EXECUTABLE, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                            }
                        }
                        else
                        {
                            MessageBox.Show($"Mod Installer Can't get access to \"{(string)jsEntry["sourcefile"]}\" file, make sure that specified pak folder path still valid and game isn't running.", Globals.PROGRAM_EXECUTABLE, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        }
                    }
                }
            } else { 
                if (ModPackage != "CANC")
                    MessageBox.Show($"Mod Installer Can't get access to mod package file.", Globals.PROGRAM_EXECUTABLE, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1); 

            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(Globals.REGISTRY_VALUE_PAKSFOLDERPATH))
                return;

            string ModPackage = InitializeModPackage();
            if (ModPackage.Length > 4)
            {
                var JsModPackage = JArray.Parse(ModPackage);
                foreach (JObject jsEntry in JsModPackage)
                {
                    DialogResult askformoduninstall = MessageBox.Show($"Do you want to uninstall \"{(string)jsEntry["modtitle"]}\"?", Globals.PROGRAM_EXECUTABLE, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (askformoduninstall == DialogResult.Yes)
                    {
                        byte[] InitializedFileByteArray = InitializeUnrealFile(Globals.REGISTRY_VALUE_PAKSFOLDERPATH + $"\\{(string)jsEntry["sourcefile"]}");
                        if (InitializedFileByteArray != null)
                        {
                            if (WriteAllBytesToFile(Globals.REGISTRY_VALUE_PAKSFOLDERPATH + $"\\{(string)jsEntry["sourcefile"]}", ReplaceBytes(InitializedFileByteArray, HexToByteArray(((string)jsEntry["changed"]).Replace(" ", "")), HexToByteArray(((string)jsEntry["original"]).Replace(" ", "")))))
                            {
                                MessageBox.Show($"\"{(string)jsEntry["modtitle"]}\" Mod successfully uninstalled!", Globals.PROGRAM_EXECUTABLE, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                            }
                            else
                            {
                                MessageBox.Show($"An error occured when tried to uninstall \"{(string)jsEntry["modtitle"]}\" mod, make sure that mod even installed and mod package was properly made.", Globals.PROGRAM_EXECUTABLE, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                            }
                        }
                        else
                        {
                            MessageBox.Show($"Mod Installer Can't get access to \"{(string)jsEntry["sourcefile"]}\" file, make sure that specified pak folder path still valid and game isn't running.", Globals.PROGRAM_EXECUTABLE, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        }
                    }
                }
            }
            else
            {
                if (ModPackage != "CANC")
                    MessageBox.Show($"Mod Installer Can't get access to mod package file.", Globals.PROGRAM_EXECUTABLE, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

            }
        }




        private string InitializeModPackage()
        {
            try
            {
                using (OpenFileDialog specifymodpackage = new OpenFileDialog())
                {
                    specifymodpackage.RestoreDirectory = true;
                    specifymodpackage.InitialDirectory = Environment.CurrentDirectory;
                    specifymodpackage.Filter = "Json Mod Package|*.json";
                    specifymodpackage.FilterIndex = 1;
                    if (specifymodpackage.ShowDialog() == DialogResult.OK)
                    {
                        StreamReader sr = new StreamReader(specifymodpackage.FileName);
                        string InputFileContent = sr.ReadToEnd();
                        sr.Close(); return InputFileContent;
                    }
                    else return "CANC";
                }
            } catch { return "NONE"; }
        }
        private byte[] InitializeUnrealFile(string fileName)
        {
            try
            {
                byte[] buffer = null;
                using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
                {
                    buffer = new byte[fs.Length];
                    fs.Read(buffer, 0, (int)fs.Length);
                }
                return buffer;
            }
            catch
            {
                return null;
            }
        }
        private bool WriteAllBytesToFile(string fileName, byte[] array)
        {
            try
            {
                File.WriteAllBytes(fileName, array);
                return true;
            }
            catch { return false; }
        }
        public byte[] HexToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }



        public int FindBytes(byte[] source, byte[] find)
        {
            int index = -1;
            int matchIndex = 0;
            for (int i = 0; i < source.Length; i++)
            {
                if (source[i] == find[matchIndex])
                {
                    if (matchIndex == (find.Length - 1))
                    {
                        index = i - matchIndex;
                        break;
                    }
                    matchIndex++;
                }
                else if (source[i] == find[0])
                {
                    matchIndex = 1;
                }
                else
                {
                    matchIndex = 0;
                }

            }
            return index;
        }

        public byte[] ReplaceBytes(byte[] source, byte[] search, byte[] replace)
        {
            byte[] result = null;
            int index = FindBytes(source, search);
            if (index >= 0)
            {
                result = new byte[source.Length - search.Length + replace.Length];
                Buffer.BlockCopy(source, 0, result, 0, index);
                Buffer.BlockCopy(replace, 0, result, index, replace.Length);
                Buffer.BlockCopy(
                    source,
                    index + search.Length,
                    result,
                    index + replace.Length,
                    source.Length - (index + search.Length));
            }
            return result;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog specifypakspath = new FolderBrowserDialog())
            {
                DialogResult selectedfolder = specifypakspath.ShowDialog();
                if (selectedfolder == DialogResult.OK)
                {
                    Registry.SetValue(Globals.REGISTRY_MAIN, "PaksFolderPath", specifypakspath.SelectedPath);
                    textBox1.Text = specifypakspath.SelectedPath;
                }

            }
        }
    }
}
