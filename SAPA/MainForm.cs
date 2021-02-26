using System;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;

namespace SAPA
{
    public partial class MainForm : Form
    {
        enum Mode
        {
            c = 0,
            cpp,
            java  // TODO
        };
        readonly Dictionary<Mode, string> CompilerFileName = new Dictionary<Mode, string>()
        {
            {Mode.c, "gcc.exe"},
            {Mode.cpp, "g++.exe"},
            {Mode.java, "javac.exe"}
        };
        Dictionary<Mode, string> CompilerPath = new Dictionary<Mode, string>()
        {
            {Mode.c, "gcc.exe"},
            {Mode.cpp, "g++.exe"},
            {Mode.java, "javac.exe"}
        };
        Mode currentMode = Mode.c;

        bool compiled = false;
        readonly bool builtinCompiler = false;

        string
            path,
            gccPath, gppPath, javacPath,
            tempPath, tempSourcePath, tempExecPath;
        string sourcePath, inputPath;
        readonly string
            tempSourceFileName = "sapa_source",
            tempExecFile = "sapa_exec.exe";

        readonly int execTimeout = 3000;

        private void Initialise(object sender, EventArgs e)
        {
            InitialiseWorkingDirectory();
            InitialiseCompiler(builtinCompiler);
        }

        private void InitialiseWorkingDirectory()
        {
            path = Path.GetTempPath();
            tempPath = path + "/sapa";
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
        }

        private void InitialiseCompiler(bool builtinCompiler)
        {
            gccPath = CompilerPath[Mode.c];
            gppPath = CompilerPath[Mode.cpp];
            javacPath = CompilerPath[Mode.java];
        }

        private void TextBoxSource_TextChanged(object sender, EventArgs e)
        {
            compiled = false;
        }

        public MainForm()
        {
            InitializeComponent();
            ChangeMode(Mode.c);
        }

        private void ChangeMode(Mode newMode)
        {
            currentMode = newMode;
            comboBoxMode.SelectedIndex = (int)newMode;
        }

        private void ModeChangedByUser(object sender, EventArgs e)
        {
            currentMode = (Mode)comboBoxMode.SelectedIndex;
        }

        private void OpenSourceFile(object sender, EventArgs e)
        {
            if (sourceOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    sourcePath = sourceOpenFileDialog.FileName;
                    textBoxSource.Lines = File.ReadAllLines(sourcePath);
                    string extension = Path.GetExtension(sourcePath);
                    if (extension == ".c")
                    {
                        ChangeMode(Mode.c);
                    }
                    else if (extension == ".java")
                    {
                        ChangeMode(Mode.java);
                    }
                    else
                    {
                        ChangeMode(Mode.cpp);
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
                textBoxSource.Focus();
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
                textBoxInput.Focus();
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
            ProcessStartInfo startInfo = new ProcessStartInfo()
            {
                FileName = (currentMode == Mode.c ? gccPath : gppPath),
                Arguments = tempSourcePath + " -o " + tempExecPath,
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardError = true
            };
            Process compilerProcess = Process.Start(startInfo);
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
            ProcessStartInfo startInfo = new ProcessStartInfo()
            {
                FileName = tempExecPath,
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardInput = true,
                RedirectStandardOutput = true
            };
            Process execProcess = Process.Start(startInfo);
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
                textBoxOutput.Text = "Timeout reached.";
            }
            execProcess.Close();
        }

        private void ShowAbout(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Simple Automated Programming Assessor (SAPA)\n"
                + "(c) 2020 - 2021 Zhong Ruoyu\n"
                + "Licensed under the MIT License.",
                "About",
                MessageBoxButtons.OK
            );
        }
    }
}
