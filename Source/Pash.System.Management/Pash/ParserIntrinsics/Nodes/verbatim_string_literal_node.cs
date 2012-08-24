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
using System.Collections.ObjectModel;

namespace Pash.ParserIntrinsics.Nodes
{
    public class verbatim_string_literal_node : _node
    {
        public verbatim_string_literal_node(AstContext astContext, ParseTreeNode parseTreeNode)
            : base(astContext, parseTreeNode)
        {
        }

        internal override object Execute(ExecutionContext context, ICommandRuntime commandRuntime)
        {
            var matches = Regex.Match(parseTreeNode.FindTokenAndGetText(), PowerShellGrammar.Terminals.verbatim_string_literal.Pattern);
            return matches.Groups[PowerShellGrammar.Terminals.verbatim_string_characters.Name].Value;
        }
    }
}
