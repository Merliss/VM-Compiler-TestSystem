using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CPDev.Public;
using System.Diagnostics;
using CompileAndRunTests.TestUtils;

namespace CompileAndRunTests.Compilation
{
    public static class GenCompilation
    {
        public static bool DoTypicalCompilation(string program, string fileName, string path, CompObject compobj)
        {
            string fn = System.IO.Path.Combine(path, fileName);
            System.IO.File.WriteAllText(fn, program, System.Text.Encoding.Default);
            string bledy, dcp, xcp;
            string[] args = PrepareArguments(fn, out bledy, out dcp, out xcp,path, compobj);
            RunCompilerProgram(args);
            bool v = CheckAndPrintErrorsIfExists(bledy);
            return v;
            
        }

        public static string[] PrepareArguments(string inFile, out string XErrorFile, out string DCPFile, out string XCPFile,string path, CompObject compobj)
        {
            string LCFFile = null;
            LCFFile = System.IO.Path.Combine(path, "VMxmls", compobj.VMSpec) + ".xml";
            XErrorFile = System.IO.Path.ChangeExtension(inFile, ".err");
            DCPFile = System.IO.Path.ChangeExtension(inFile, ".dcp");
            XCPFile = System.IO.Path.ChangeExtension(inFile, ".xcp");
            //string DCPOutFlags = (CPDev.STComp05.DebugContents.dcIncludeExpandedSource | CPDev.STComp05.DebugContents.dcIncludeSourceInfo).ToString("X");

            //string[] flags =
            //    { "--cf", "2531", "--sf", "B0", "--lof", "1", "--opt", "5" };

            List<string> dt = new List<string>
            {
                "--lcf", LCFFile,
                "--dcp", DCPFile,
                "--out", XCPFile,
                "--cf" , compobj.CF_Flags,
                "--sf" , compobj.SF_Flags,
                "--lof", compobj.LOF_Flags,
                "--opt", compobj.OPT_Flags,
                "--xml-errors", XErrorFile,
                "--dcp-output", compobj.DCP_OUT_Flags,
                "--", inFile
            };


            //foreach (var item in dt)
            //{
            //    Console.WriteLine( item);
            //}

            string[] dtArr = dt.ToArray();
            return dtArr;
        }

        public static void RunCompilerProgram(string[] main_args)
        {
            
            STComp05.Program.Main(main_args);
        }

        public static bool CheckAndPrintErrorsIfExists(string XErrorFile)
        {
            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            doc.Load(XErrorFile);
            System.Xml.XmlNodeList node = doc.SelectNodes(CPDev.SADlg.ConfigManager.ROM.gCPDevRootConst + "/COMPILATION/MESSAGES/ERROR");
            foreach (System.Xml.XmlElement el in node)
            {
                if (el != null)
                    System.Console.Error.WriteLine(el.InnerText);
            }
            return node.Count != 0;
        }
    }
}
