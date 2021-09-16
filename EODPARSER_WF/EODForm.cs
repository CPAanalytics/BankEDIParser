using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NSlice;

namespace EODPARSER_WF
{
    public partial class EodForm : Form
    {
        private string _filePath;
        private OpenFileDialog _fileDialog;

        public EodForm()
        {
            InitializeComponent();
        }

        private void GetFile_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = @"txt files (*.txt)|*.txt|All files (*.*)|*.*";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    _filePath = openFileDialog.FileName;
                    _fileDialog = openFileDialog;
                }
            }

            FilenameBox.Text = _filePath;
        }

        private void Parse_Click(object sender, EventArgs e)
        {
            using var file = new StreamReader(_fileDialog.FileName);
            using StreamWriter writefile = new("export.csv", true);
            var csvHeader =
                "TransmitDate,ClearDate,CompanyNumber,CompanyName,Debit,Credit";
            writefile.WriteLine(csvHeader);
            {
                string line;
                decimal runningTotal = 0;
                var transmitDate = string.Empty;
                var clearDate = string.Empty;
                while ((line = file.ReadLine()) != null)
                {
                    var prefix = line.Slice(0, 2);
                    if (prefix == "90") break;

                    if (prefix == "52")
                    {
                        transmitDate = "20" + line.Slice(63, 69);
                        clearDate = "20" + line.Slice(69, 75);
                    }

                    if (prefix == "62")
                    {
                        var prAmount = line.Slice(29, 39);
                        var decprAmount = decimal.Parse(prAmount) / 100;
                        var coNumber = line.Slice(39, 44);
                        var compName = line.Slice(54, 75);
                        var csvLine =
                            $"{transmitDate},{clearDate},{coNumber},{compName},{decprAmount}";


                        writefile.WriteLine(csvLine);
                        runningTotal += decprAmount;
                    }

                    if (line.Slice(0, 2) == "82")
                    {
                        var totalAmount = line.Slice(20, 32);
                        var dectotalAmount = decimal.Parse(totalAmount) / 100;
                        if (runningTotal != dectotalAmount) MessageBox.Show(@"Warning Total Does not foot to sum!");
                        var csvLine = $"Total,,,,,{dectotalAmount}";
                        writefile.WriteLine(csvLine);
                    }
                }

                MessageBox.Show(@"Parse Complete.");
            }
        }
    }
}