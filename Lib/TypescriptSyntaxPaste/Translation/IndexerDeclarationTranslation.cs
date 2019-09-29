﻿/*
 * Copyright (c) 2019 João Pedro Martins Neves (shivayl) - All Rights Reserved.
 *
 * ClassStudio is licensed under the GNU Lesser General Public License (LGPL),
 * version 3, located in the root of this project, under the name "LICENSE.md".
 *
 */

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using RoslynTypeScript.Constants;
using System.Linq;
using System.Text;

namespace RoslynTypeScript.Translation
{
    public class IndexerDeclarationTranslation : BasePropertyDeclarationTranslation
    {
        public new IndexerDeclarationSyntax Syntax
        {
            get { return (IndexerDeclarationSyntax)base.Syntax; }
            set { base.Syntax = value; }
        }

        public IndexerDeclarationTranslation() { }
        public IndexerDeclarationTranslation(IndexerDeclarationSyntax syntax, SyntaxTranslation parent) : base( syntax, parent )
        {
            ParameterList = syntax.ParameterList.Get<BracketedParameterListTranslation>( this );
        }

        public BracketedParameterListTranslation ParameterList { get; set; }

        protected override string InnerTranslate()
        {
            if (IsInScope<InterfaceDeclarationTranslation>())
            {
                StringBuilder bd = new StringBuilder();
                if (AccessorList.Accessors.GetEnumerable().Any( f => f.Syntax.Keyword.ToString() == "get" ))
                {
                    bd.Append( $"{TC.IndexerGetName}({ParameterList.Parameters.Translate()}) :{Type.Translate()};" );
                }

                if (AccessorList.Accessors.GetEnumerable().Any( f => f.Syntax.Keyword.ToString() == "set" ))
                {
                    bd.Append( $"{TC.IndexerSetName}({ParameterList.Parameters.Translate()}, value :{Type.Translate()}):void;" );
                }

                return bd.ToString();
            }

            return AccessorList.Translate();
            //}else
            //{
            //    StringBuilder bd = new StringBuilder();
            //    var getAccessor = AccessorList.Accessors.GetEnumerable().FirstOrDefault(f => f.Syntax.Keyword.ToString() == "get");
            //    if (getAccessor != null)
            //    {
            //        bd.Append("\{TC.IndexerGetName}(\{ParameterList.Parameters.Translate()}) :\{Type.Translate()}\n \{getAccessor.Translate()}");
            //    }

            //    var setAccessor = AccessorList.Accessors.GetEnumerable().FirstOrDefault(f => f.Syntax.Keyword.ToString() == "set");

            //    if (setAccessor!=null)
            //    {
            //        bd.Append("\{TC.IndexerSetName}(\{ParameterList.Parameters.Translate()}, value :\{Type.Translate()}):void \{setAccessor.Translate()}");
            //    }
            //}

            //return Syntax.ToString();
        }
    }
}
