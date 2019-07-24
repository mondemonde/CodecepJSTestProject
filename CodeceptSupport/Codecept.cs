using PuppetSupportLib;
using PuppetSupportLib.Katalon;
using PuppetSupportLib.WebAction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeceptSupport
{
   public class Codecept:Puppet
    {
        public new static  string Script(TestCaseSelenese cmd,IInterpreter it)
        {

            string result = string.Empty;

            switch (cmd.command)
            {
                case "open":
                    result = new GoTo(cmd).Script(it);
                    break;

                case "click":
                    result = new Click(cmd).Script(it);
                    break;

                case "type":
                    result = new TypeIn(cmd).Script(it);
                    break;

                case "sendKeys":
                    result = new SendKey(cmd).Script(it);
                    break;


                default:
                    break;
            }

            return result;
        }
    }
}
