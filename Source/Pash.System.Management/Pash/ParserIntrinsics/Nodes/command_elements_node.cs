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
using System.Management.Automation.Runspaces;

namespace Pash.ParserIntrinsics.Nodes
{
    public class command_elements_node : _node
    {
        public command_elements_node(AstContext astContext, ParseTreeNode parseTreeNode)
            : base(astContext, parseTreeNode)
        {
        }

        internal override object GetValue(ExecutionContext context)
        {
            return parseTreeNode.ChildNodes.Select(node => ((_node)node.AstNode).GetValue(context));
        }
    }
}
