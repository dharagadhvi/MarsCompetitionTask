using MarsCompetition.Pages;
using NUnit.Framework;
using System;


namespace MarsCompetition.Test
{
    public class Program
    {
        
        [TestFixture]
        [Category("Sprint1")]
        class User : Global.Base

        {
                      
            [Test]
            public void a_TestAddShareSkill()
            {
                ShareSkill shareSkill = new ShareSkill();
                shareSkill.EnterShareSkill();

            }

        }
    }
}
