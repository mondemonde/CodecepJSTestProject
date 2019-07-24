using PuppetSupportLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PuppetSupportLib.Katalon;
using PuppetSupportLib.WebAction;
using PuppetSupportLib.Helpers;
using System.Globalization;

namespace CodeceptSupport
{
   public class Interpreter: KatalonInterpreter
    {
        public List<CodeceptAction> MyActions { get; set; }
        public override StringBuilder Convert(string fullFileName = "")
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

            MyActions = new List<CodeceptAction>();
            var length = sel.selenese.Count();
            for (int i = 0; i < length; i++)
            {
                var t = sel.selenese[i];
                Console.WriteLine(string.Format("{0}  {1}  {2}", t.command, t.target, t.value));

                var script = Codecept.Script(t, this);

                myScript += script;

                //create codeceptActions
                CodeceptAction action = new CodeceptAction
                {
                    target = t.target,
                    command = t.command,
                    value = t.value,
                    Script = script.Trim(),
                    OrderNo = i
                };
                MyActions.Add(action);

            }//end for           

            //LogApplication.Agent.LogInfo(myScript);
            System.Diagnostics.Debug.WriteLine(Environment.NewLine + myScript);
            StringBuilder result = new StringBuilder();
            return result;
        }

        #region Selector 
        public override  string FormatSelector(string target)
        {
            var content = target.ToString();

            List<string> elFilters = new List<string>() { "id=", "id =","name=" };
            foreach(string filter in elFilters)
            {
                if(content.Contains(filter))
                {
                    return FormatAsJson(target);
                }
            }

            //I.clickLink('Logout', '#nav')
            if (content.StartsWith("link="))
                return FormatAsLink(target);

            if (content.StartsWith("xpath="))
                return FormatAsXpath(target);


            return "'"+target+"'";
        }

        public override string FormatValue(string target)
        {
            string result = target;
            var delimiter = "${KEY_";

            if (target.StartsWith(delimiter))
            {
                result = target.Replace(delimiter, "");
                result = result.Replace("}", "");

                // Creates a TextInfo based on the "en-US" culture.
                //TextInfo txtInfo = new CultureInfo("en-US", true).TextInfo;
                result = BaiTextFilterClassLibrary.Helper.FormatProperCase(result);

            }

            return result;
        }

        private  string FormatAsJson(string target)
        {
            //throw new NotImplementedException();
           var split = target.Split('=');
            if (split.Length > 1)
            {
                var attr = split[0].Trim();
                var value = string.Format("'{0}'", split[1]);
                var result = "{" + attr +":"+ value +"}";
                return result;
            }
            else
                return target;
        }

        private string FormatAsLink(string target)
        {
            //throw new NotImplementedException();
            var split = target.Split('=');
            if (split.Length > 1)
            {
                //I.clickLink('Logout', '#nav')
                //var attr = split[0].Trim();

                //link = Puppeteer
                var value = string.Format("'{0}'", split[1]); 
                //'Puppeteer'
                return value;
            }
            else
                return target;
        }

        private string FormatAsXpath(string target)
        {
            // I.seeElement({ xpath: '//div[@class=user]'});
            string[] delimeter = new string[] {"xpath="};
            string[] split = target.Split(delimeter, StringSplitOptions.None);

            if (split.Length > 1)
            {
                var attr = "xpath";
                var value = string.Format("\"{0}\"", split[1]);
                var result = "{" + attr + ":" + value + "}";
                return result;
            }
            else
                return target;

        }


        #endregion
    }
}
