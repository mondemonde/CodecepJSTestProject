using PuppetSupportLib.Helpers;
using PuppetSupportLib.Katalon;
using PuppetSupportLib.WebAction;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuppetSupportLib
{
   public class KatalonInterpreter:IInterpreter
    {
        public string DefaultSourceFolder
        {
            get
            {
                var baseDir = LogApplication.Agent.GetCurrentDir() + "\\Katalon\\";//AppDomain.CurrentDomain.BaseDirectory;
                baseDir = baseDir.Replace("file:\\", "");
                return baseDir;
            }
        }


        public virtual StringBuilder Convert(string fullFileName="")
        {
            //_HACK safe to delete 
            #region---TEST ONLY: Compiler will  automatically erase this in RELEASE mode and it will not run if Global.GlobalTestMode is not set to TestMode.Simulation
#if OVERRIDE || DEBUG

            System.Diagnostics.Debug.WriteLine("HACK-TEST -Convert");

            if (string.IsNullOrEmpty(fullFileName))
            {
                fullFileName = DefaultSourceFolder + "test.xml";
            }

#endif
            #endregion //////////////END TEST

            string xml = File.ReadAllText(fullFileName);
            var catalog1 = xml.ParseXML<TestCase>();

            string myScript = string.Empty;
            //get first
            var sel = catalog1;//.FirstOrDefault();
            foreach (var t in sel.selenese)
            {
                
                    Console.WriteLine(string.Format("{0}  {1}  {2}", t.command,t.target,t.value));
                myScript += Puppet.Script(t,this);
                

            }

            //LogApplication.Agent.LogInfo(myScript);
            System.Diagnostics.Debug.WriteLine(Environment.NewLine + myScript);
            StringBuilder result = new StringBuilder();
            return result;
        }

        public virtual  string FormatSelector(string target)
        {
            throw new NotImplementedException();
        }

        public virtual string FormatValue(string target)
        {
            throw new NotImplementedException();
        }
    }

   public interface IInterpreter
    {
        string FormatSelector(string target);
        string FormatValue(string target);

    }

}
