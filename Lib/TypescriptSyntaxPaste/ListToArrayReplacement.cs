﻿/*
 * Copyright (c) 2019 João Pedro Martins Neves (shivayl) - All Rights Reserved.
 *
 * ClassStudio is licensed under the GNU Lesser General Public License (LGPL),
 * version 3, located in the root of this project, under the name "LICENSE.md".
 *
 */

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Linq;

namespace TypescriptSyntaxPaste
{

    class ListToArrayReplacementRewriter : CSharpSyntaxRewriter
    {

        public bool IsChangeInObjectCreation { get; private set; }

        public ListToArrayReplacementRewriter(bool isChangeInObjectCreation = false)
        {
            IsChangeInObjectCreation = isChangeInObjectCreation;
        }

        public override SyntaxNode VisitGenericName(GenericNameSyntax node)
        {
            if (!IsList( node ))
            {
                return base.VisitGenericName( node );
            }

            return ToArray( node );

        }

        public override SyntaxNode VisitQualifiedName(QualifiedNameSyntax node)
        {
            GenericNameSyntax foundNode = FindListNode( node );
            if (foundNode == null)
            {
                return base.VisitQualifiedName( node );
            }

            return ToArray( foundNode );
            //return node.ReplaceNode(foundNode, arrayNode);
        }


        public override SyntaxNode VisitObjectCreationExpression(ObjectCreationExpressionSyntax node)
        {
            if (IsChangeInObjectCreation)
            {
                return base.VisitObjectCreationExpression( node );
            }

            var found = FindListNode( node );
            if (found == null)
            {
                return base.VisitObjectCreationExpression( node );
            }

            ListToArrayReplacementRewriter rewriter = new ListToArrayReplacementRewriter( true );
            return rewriter.Visit( node );

        }

        private bool IsList(GenericNameSyntax syntax)
        {
            return syntax.Identifier.ValueText == "List" || syntax.Identifier.ValueText == "IList";
        }

        private SyntaxNode ToArray(GenericNameSyntax node)
        {
            if (IsChangeInObjectCreation)
            {
                return node.ReplaceToken( node.Identifier, SyntaxFactory.Identifier( "Array" ) );
            }

            var firstTypeSyntax = node.TypeArgumentList.Arguments.First();
            var typeName = (TypeSyntax)new ListToArrayReplacementRewriter().Visit( firstTypeSyntax );


            return SyntaxFactory.ArrayType( typeName,
                SyntaxFactory.List( new ArrayRankSpecifierSyntax[] { SyntaxFactory.ArrayRankSpecifier() } ) );
        }


        private GenericNameSyntax FindListNode(SyntaxNode node)
        {
            return node.DescendantNodes().Where( f => f is GenericNameSyntax && IsList( (GenericNameSyntax)f ) )
                            .OfType<GenericNameSyntax>()
                            .FirstOrDefault();
        }
    }

    public class ListToArrayReplacement
    {
        public static CSharpSyntaxNode ReplaceList(CSharpSyntaxNode syntaxNode)
        {
            return (CSharpSyntaxNode)new ListToArrayReplacementRewriter().Visit( syntaxNode );

        }
    }
}
