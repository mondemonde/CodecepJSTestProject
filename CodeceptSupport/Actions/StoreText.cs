using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PuppetSupportLib;
using PuppetSupportLib.Katalon;
using PuppetSupportLib.WebAction;

namespace CodeceptSupport
{
    public class StoreText : BaseAction
    {

        public StoreText(TestCaseSelenese katalonxml) : base(katalonxml)
        {

        }

        public override TestCaseSelenese Map(object customAction)
        {
            //throw new NotImplementedException();
            var act = (TestCaseSelenese)customAction;
            //do convettion here..
            //..
            //.


            return act;
        }



        public override string Script(IInterpreter interpreter)
        {
            //await page.click('.container > #mvcforum-nav > .nav > li > .auto-logon')
            /*
             Get text of element (value of text between html tags)
                [Katalon] storeText : Target - element locator | Value - name of variable
                [Codecept] grabTextFrom : Param - element locator 

                [Katalon]
                <selenese>
	                <command>storeText</command>
	                <target><![CDATA[id=some-locator]]></target>
	                <value><![CDATA[var]]></value>
                </selenese>

                [Codecept]
                let var = await I.grabTextFrom('#some-locator');
             */
            var script = string.Format("grabTextFrom({0}, '{1}')", interpreter.FormatSelector(MyAction.target), MyAction.value);
            script = script + Environment.NewLine;

            return script;
        }
    }
}
