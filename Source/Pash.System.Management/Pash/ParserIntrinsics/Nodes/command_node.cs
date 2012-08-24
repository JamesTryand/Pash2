using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Irony.Ast;
using Irony.Parsing;
using Pash.Implementation;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Collections.ObjectModel;

namespace Pash.ParserIntrinsics.Nodes
{
    public class command_node : _node
    {
        private Collection<PSObject> _results;

        public command_node(AstContext astContext, ParseTreeNode parseTreeNode)
            : base(astContext, parseTreeNode)
        {
        }

        internal override object Execute(ExecutionContext context, ICommandRuntime commandRuntime)
        {
                var commandText = parseTreeNode.FindTokenAndGetText();
                CommandInfo commandInfo = ((LocalRunspace)context.CurrentRunspace).CommandManager.FindCommand(commandText);

                if (commandInfo == null)
                    throw new InvalidOperationException(commandText);

                // MUST: fix this with the commandRuntime
                Pipeline pipeline = context.CurrentRunspace.CreateNestedPipeline();

                // Fill the pipeline with input data
                pipeline.Input.Write(context.inputStreamReader);

                context.PushPipeline(pipeline);

                try
                {
                    // TODO: implement command invoke
                    pipeline.Commands.Add(commandText);
                    return pipeline.Invoke();
                }
                finally
                {
                    context.PopPipeline();
                }

        }
    }
}
