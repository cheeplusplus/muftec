﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Muftec.Lib.CompilerStates
{
    class ConditionalState : ICompilerState
    {
        public ApplicationCore Core { get; set; }

        private FunctionEvaluatorState _evaluator;
        private bool _isFalseSide;
        private readonly ApplicationCore _trueCore;
        private readonly ApplicationCore _falseCore;

        public ConditionalState(ApplicationCore core)
        {
            Core = core;
            _trueCore = new ApplicationCore(null, null, new Queue<MuftecStackItem>());
            _falseCore = new ApplicationCore(null, null, new Queue<MuftecStackItem>());
        }

        public bool EvaluateToken(string token)
        {
            // Start out as the true side
            if (_evaluator == null)
                _evaluator = new FunctionEvaluatorState(_trueCore, true);

            // Evaluate current arguments
            _evaluator.EvaluateToken(token);

            // Get the result if it hit a conditional token
            if (_evaluator.ConditionalStatus != FunctionEvaluatorState.ConditionalStatusType.None)
            {
                if (_evaluator.ConditionalStatus == FunctionEvaluatorState.ConditionalStatusType.Else)
                {
                    if (_isFalseSide)
                        throw new MuftecCompilerException("Encountered else after else", Core.LineNumber);

                    // Switch to false side
                    _evaluator = new FunctionEvaluatorState(_falseCore, true);
                    _isFalseSide = true;
                    return true;
                }
                if (_evaluator.ConditionalStatus == FunctionEvaluatorState.ConditionalStatusType.Then)
                {
                    // Done here, wrap up
                    var container = new ConditionalContainer { TrueQueue = _trueCore.Queue, FalseQueue = _falseCore.Queue };

                    Core.Queue.Enqueue(new MuftecStackItem(container));
                    return false;
                }
            }

            return true;
        }
    }
}