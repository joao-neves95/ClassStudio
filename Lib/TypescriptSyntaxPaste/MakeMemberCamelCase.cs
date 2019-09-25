﻿/*
 * Copyright (c) 2019 João Pedro Martins Neves (shivayl) - All Rights Reserved.
 *
 * ClassStudio is licensed under the GNU Lesser General Public License (LGPL),
 * version 3, located in the root of this project, under the name "LICENSE.md".
 *
 */


/* Unmerged change from project 'TypescriptSyntaxPaste (net472)'
Before:
using Microsoft.CodeAnalysis.CSharp;
After:
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
*/
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Linq;
/* Unmerged change from project 'TypescriptSyntaxPaste (net472)'
Before:
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
After:
using System.Threading.Tasks;
*/


namespace TypescriptSyntaxPaste
{

    class MemberToCamelCaseRewriter : CSharpSyntaxRewriter
    {
        public override SyntaxNode VisitPropertyDeclaration(PropertyDeclarationSyntax propertySyntax)
        {
            var leadingTrivia = propertySyntax.Identifier.LeadingTrivia;
            var trailingTriva = propertySyntax.Identifier.TrailingTrivia;
            return propertySyntax.ReplaceToken( propertySyntax.Identifier,
                SyntaxFactory.Identifier( leadingTrivia,
                ToCamelCase( propertySyntax.Identifier.ValueText ), trailingTriva ) );
        }

        public override SyntaxNode VisitMethodDeclaration(MethodDeclarationSyntax methodSyntax)
        {
            var leadingTrivia = methodSyntax.Identifier.LeadingTrivia;
            var trailingTriva = methodSyntax.Identifier.TrailingTrivia;
            return methodSyntax.ReplaceToken( methodSyntax.Identifier,
                SyntaxFactory.Identifier( leadingTrivia, ToCamelCase( methodSyntax.Identifier.ValueText ), trailingTriva ) );
        }

        public override SyntaxNode VisitFieldDeclaration(FieldDeclarationSyntax fieldSyntax)
        {
            return fieldSyntax.ReplaceTokens( fieldSyntax.Declaration.Variables.Select( f => f.Identifier ),
                (t1, t2) => SyntaxFactory.Identifier( t1.LeadingTrivia, ToCamelCase( t1.ValueText ), t1.TrailingTrivia ) );

        }

        private static string ToCamelCase(string name)
        {
            return name.Substring( 0, 1 ).ToLower() + name.Substring( 1 );
        }
    }

    public class MakeMemberCamelCase
    {
        public static CSharpSyntaxNode Make(CSharpSyntaxNode syntaxNode)
        {

            var rewriter = new MemberToCamelCaseRewriter();
            return (CSharpSyntaxNode)rewriter.Visit( syntaxNode );
        }


    }
}
