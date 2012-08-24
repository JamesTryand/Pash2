using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Irony.Ast;
using Irony.Parsing;
using Pash.Implementation;
using System.Management.Automation;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace Pash.ParserIntrinsics.Nodes
{
    public class command_elements : _node
    {
        public command_elements(AstContext astContext, ParseTreeNode parseTreeNode)
            : base(astContext, parseTreeNode)
        {
        }

        internal override object GetValue(ExecutionContext context)
        {
            return parseTreeNode.FindTokenAndGetText();
        }
    }
}
