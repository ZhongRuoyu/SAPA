using System;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace SAPA
{
    public partial class MainForm : Form
    {
        enum Mode
        {
            c,
            cpp,
        };
        Mode currentMode = Mode.c;

        bool compiled = false;
        readonly bool builtinCompiler = false;

        string
            path,
            gccPath, gppPath,
            tempPath, tempSourcePath, tempExecPath;
        string sourcePath, inputPath;
        readonly string
            tempSourceFileName = "_sapa_source",
            tempExecFile = "_sapa_exec.exe";

        readonly int execTimeout = 3000;

        private void Initialise(object sender, EventArgs e)
        {
            path = Directory.GetCurrentDirectory();
            tempPath = path + "/_sapa_temp";
            tempExecPath = tempPath + "/" + tempExecFile;
            try
            {
                Directory.CreateDirectory(tempPath);
            }
            catch
            {
                MessageBox.Show(
                    "Temporary path could not be created.",
                    "Error Creating Temporary Path",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                Application.Exit();
            }
            if (builtinCompiler)
            {
                gccPath = path + "/mingw64/bin/gcc.exe";
                gppPath = path + "/mingw64/bin/g++.exe";
                if (!File.Exists(gccPath))
                {
                    MessageBox.Show(
                        "gcc.exe could not be located.",
                        "Error Locating gcc",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    Application.Exit();
                }
                if (!File.Exists(gppPath))
                {
                    MessageBox.Show(
                        "g++.exe could not be located.",
                        "Error Locating g++",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    Application.Exit();
                }
            }
            else
            {
                gccPath = "gcc.exe";
                gppPath = "g++.exe";
            }

        }

        private void TextBoxSource_TextChanged(object sender, EventArgs e)
        {
            compiled = false;
        }

        public MainForm()
        {
            InitializeComponent();
        }

        private void OpenSourceFile(object sender, EventArgs e)
        {
            if (sourceOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    sourcePath = sourceOpenFileDialog.FileName;
                    textBoxSource.Lines = File.ReadAllLines(sourcePath);
                    if (Path.GetExtension(sourcePath) == ".c")
                    {
                        currentMode = Mode.c;
                    }
                    else
                    {
                        currentMode = Mode.cpp;
                    }
                }
                catch
                {
                    MessageBox.Show("File could not be opened.", "Error Opening File",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                // sourceOpen = true;
                compiled = false;
                textBoxOutput.Text = "";
            }
        }

        private void OpenInputFile(object sender, EventArgs e)
        {
            if (inputOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    inputPath = inputOpenFileDialog.FileName;
                    textBoxInput.Lines = File.ReadAllLines(inputPath);
                }
                catch
                {
                    MessageBox.Show("File could not be opened.", "Error Opening File",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool CheckSource()
        {
            /* if (sourceOpen) */ return true;
            /* MessageBox.Show("Please specify a source file first.", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false; */
        }

        private void Submit(object sender, EventArgs e)
        {
            if (!CheckSource()) return;
            MessageBox.Show("Under development.", "SAPA",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Compile(object sender, EventArgs e)
        {
            compiled = false;
            if (!CheckSource()) return;
            tempSourcePath
                = tempPath + "/" + tempSourceFileName
                + ((currentMode == Mode.c) ? ".c" : ".cpp");
            File.WriteAllLines(tempSourcePath, textBoxSource.Lines);
            textBoxOutput.Text = "Compiling...";
            Process compilerProcess = new Process();
            compilerProcess.StartInfo.FileName = (currentMode == Mode.c ? gccPath : gppPath);
            compilerProcess.StartInfo.Arguments = tempSourcePath + " -o " + tempExecPath;
            compilerProcess.StartInfo.CreateNoWindow = true;
            compilerProcess.StartInfo.UseShellExecute = false;
            compilerProcess.StartInfo.RedirectStandardError = true;
            compilerProcess.Start();
            string[] stderr = compilerProcess.StandardError.ReadToEnd().Split('\n');
            int compilerStatus = compilerProcess.ExitCode;
            if (compilerStatus != 0)
            {
                MessageBox.Show(
                    "Compilation failed.\n"
                    + "Compiler returned " + compilerStatus.ToString() + ".",
                    "Failure",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
            else
            {
                MessageBox.Show(
                    "Compilation successful.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                compiled = true;
            }
            textBoxOutput.Lines = stderr;
            compilerProcess.Close();
        }

        private void RunInput(object sender, EventArgs e)
        {
            if (!CheckSource()) return;
            if (!compiled)
            {
                if (MessageBox.Show(
                    "Source file has not been compiled yet or\n"
                    + "has been modified since last compilation.\n"
                    + "Would you like to compile it now?",
                    "Source File Not Compiled",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    Compile(sender, e);
                    if (!compiled) return;
                }
                else
                {
                    return;
                }
            }
            textBoxOutput.Text = "Running input...";
            Process execProcess = new Process();
            execProcess.StartInfo.FileName = tempExecPath;
            execProcess.StartInfo.CreateNoWindow = true;
            execProcess.StartInfo.UseShellExecute = false;
            execProcess.StartInfo.RedirectStandardInput = true;
            execProcess.StartInfo.RedirectStandardOutput = true;
            execProcess.Start();
            foreach (string line in textBoxInput.Lines)
            {
                execProcess.StandardInput.WriteLine(line);
            }
            execProcess.StandardInput.Close();
            if (execProcess.WaitForExit(execTimeout))
            {
                string[] stdout = execProcess.StandardOutput.ReadToEnd().Split('\n');
                textBoxOutput.Lines = stdout;
            }
            else
            {
                execProcess.Kill();
                // MessageBox.Show("Timeout reached.", "Timeout Reached",
                //     MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxOutput.Text = "Timeout reached.";
            }
            execProcess.Close();
        }

        private void ShowAbout(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Simple Automated Programming Assessor (SAPA)\n"
                + "(c) 2020 Zhong Ruoyu\n"
                + "Licensed under the MIT License.",
                "About",
                MessageBoxButtons.OK
            );
        }
    }
}
