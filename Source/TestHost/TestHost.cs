﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management.Automation.Host;
using System.Management.Automation.Runspaces;

namespace TestHost
{
    class TestHost : PSHost
    {
        readonly PSHostUserInterface _ui = new TestHostUserInterface();

        public static string Execute(params string[] statements)
        {
            TestHostUserInterface ui = new TestHostUserInterface();

            TestHost host = new TestHost(ui);
            var myRunSpace = RunspaceFactory.CreateRunspace(host);
            myRunSpace.Open();

            foreach (var statement in statements)
            {
                using (var currentPipeline = myRunSpace.CreatePipeline())
                {
                    currentPipeline.Commands.Add(statement);
                    currentPipeline.Commands.Add("Out-Default");
                    currentPipeline.Invoke();
                }
            }

            return ui.Log.ToString();
        }


        public TestHost(TestHostUserInterface ui)
        {
            // TODO: Complete member initialization
            this._ui = ui;
        }

        public override System.Globalization.CultureInfo CurrentCulture
        {
            get { throw new NotImplementedException(); }
        }

        public override System.Globalization.CultureInfo CurrentUICulture
        {
            get { throw new NotImplementedException(); }
        }

        public override Guid InstanceId
        {
            get { throw new NotImplementedException(); }
        }

        public override string Name
        {
            get { throw new NotImplementedException(); }
        }

        public override PSHostUserInterface UI
        {
            get
            {
                return this._ui;
            }
        }

        public override Version Version
        {
            get { throw new NotImplementedException(); }
        }

        public override void EnterNestedPrompt()
        {
            throw new NotImplementedException();
        }

        public override void ExitNestedPrompt()
        {
            throw new NotImplementedException();
        }

        public override void NotifyBeginApplication()
        {
            throw new NotImplementedException();
        }

        public override void NotifyEndApplication()
        {
            throw new NotImplementedException();
        }

        public override void SetShouldExit(int exitCode)
        {
            throw new NotImplementedException();
        }
    }
}
