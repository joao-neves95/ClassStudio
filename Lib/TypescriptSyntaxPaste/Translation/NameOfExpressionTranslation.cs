﻿/*
 * Copyright (c) 2019 João Pedro Martins Neves (shivayl) - All Rights Reserved.
 *
 * ClassStudio is licensed under the GNU Lesser General Public License (LGPL),
 * version 3, located in the root of this project, under the name "LICENSE.md".
 *
 */

//using Microsoft.CodeAnalysis;
//using Microsoft.CodeAnalysis.CSharp.Syntax;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace RoslynTypeScript.Translation
//{
//    public class NameOfExpressionTranslation : ExpressionTranslation
//    {
//        public new NameOfExpressionSyntax Syntax
//        {
//            get { return (NameOfExpressionSyntax)base.Syntax; }
//            set { base.Syntax = value; }
//        }

//        public NameOfExpressionTranslation() { }
//        public NameOfExpressionTranslation(NameOfExpressionSyntax syntax, SyntaxTranslation parent) : base(syntax, parent)
//        {
//            Argument = syntax.Argument.Get<ExpressionTranslation>(this);
//        }

//        public ExpressionTranslation Argument { get; set; }

//        protected override string InnerTranslate()
//        {
            
//            //return Syntax.ToString();
//            return $"'{Argument.Translate()}'";
//        }
//    }
//}
