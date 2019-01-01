﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuaSTGEditorSharp.EditorData.Commands
{
    /// <summary>
    /// <see cref="Command"/> that insert a <see cref="TreeNode"/> as the parent of a <see cref="TreeNode"/>.
    /// </summary>
    public class InsertAsParentCommand : InsertCommand
    {
        /// <summary>
        /// Initializes <see cref="Command"/> by target <see cref="TreeNode"/> 
        /// and <see cref="TreeNode"/> to insert.
        /// </summary>
        /// <param name="toOp">The target <see cref="TreeNode"/>.</param>
        /// <param name="toIns">The <see cref="TreeNode"/> to insert.</param>
        public InsertAsParentCommand(TreeNode toOp, TreeNode toIns) : base(toOp, toIns) { }

        /// <summary>
        /// Method for forward execution like do or redo.
        /// </summary>
        public override void Execute()
        {
            TreeNode parent = _toOperate.Parent;
            parent.InsertChild(_toInsert, parent.Children.IndexOf(_toOperate));
            parent.RemoveChild(_toOperate);
            _toInsert.AddChild(_toOperate);
        }

        /// <summary>
        /// Method for backward execution like undo.
        /// </summary>
        public override void Undo()
        {
            TreeNode parent = _toInsert.Parent;
            parent.InsertChild(_toOperate, parent.Children.IndexOf(_toInsert));
            parent.RemoveChild(_toInsert);
            _toInsert.RemoveChild(_toOperate);
        }
    }
}
