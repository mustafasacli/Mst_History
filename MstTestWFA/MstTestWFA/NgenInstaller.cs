using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace MstTestWFA
{
    [RunInstaller(true)]
    public partial class NgenInstaller : System.Configuration.Install.Installer
    {
        public NgenInstaller()
        {
            InitializeComponent();
        }

        public override void Install(IDictionary stateSaver)
        {
            base.Install(stateSaver);

            string runtimeStr = RuntimeEnvironment.GetRuntimeDirectory();
            string ngenStr = Path.Combine(runtimeStr, "ngen.exe");
            Process process = new Process();
            process.StartInfo.FileName = ngenStr;
            string assemblyPath = Context.Parameters["assemblypath"];
            process.StartInfo.Arguments = "install \"" + assemblyPath + "\"";
            process.Start();
            process.WaitForExit();
        }
    }
}
